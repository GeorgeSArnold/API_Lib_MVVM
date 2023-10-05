using API_Lib;
using API_Lib.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace TicketUI.ViewModels
{
    public class EditViewModel : Screen
    {
        // props
        // input < UI
        private int ticketId;

        // ticket fields
        private int id;
        private int number;
        private string title;
        private List<int> article_ids;
        private string articleIdsString;

        // articleId > UI
        private int articleId;
        
        // richtxtBox
        private string body;

        // input < UI
        public int TicketId
        {
            get { return ticketId; }
            set
            {
                ticketId = value;
                NotifyOfPropertyChange(() => TicketId);
            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                NotifyOfPropertyChange(() => Number);
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        // output > UI
        private List<ArticleModel> articles;
        // output < api
        public List<int> Article_ids
        {
            get { return article_ids; }
            set
            {
                article_ids = value;
                NotifyOfPropertyChange(() => Article_ids);
            }
        }
        // output > UI
        public string ArticleIdsString
        {
            get { return articleIdsString; }
            set
            {
                articleIdsString = value;
                NotifyOfPropertyChange(() => ArticleIdsString);
            }
        }
        // output < api
        public List<ArticleModel> Articles
        {
            get { return articles; }
            set
            {
                articles = value;
                NotifyOfPropertyChange(() => Articles);
            }
        }
        // input < UI
        public int ArticleId
        {
            get { return articleId; }
            set
            {
                articleId = value;
                NotifyOfPropertyChange(() => ArticleId);
            }
        }

        // richtxtB < body < article
        public string Body
        {
            get { return body; }
            set
            {
                body = value;
                NotifyOfPropertyChange(() => Body);
            }
        }

        // article methods
        // article_ids > string
        private void UpdateArticleIdsString()
        {
            ArticleIdsString = string.Join(", ", Article_ids);
        }
        // update int > string
        public void UpdateArticleIds(List<int> articleIds)
        {
            Article_ids = articleIds;
            UpdateArticleIdsString();
        }

        // selected ticket obj
        public TicketModel SelectedTicket
        {
            get { return selectedTicket; }
            set
            {
                selectedTicket = value;
                NotifyOfPropertyChange(() => SelectedTicket);

                if (selectedTicket != null) 
                {
                    TicketId = selectedTicket.Id;
                    LoadLatestArticle(TicketId);
                }
            }
        }

        //public void LoadLatestArticleManually()
        //{
        //    if (SelectedTicket != null)
        //    {
        //        TicketId = SelectedTicket.Id;
        //        LoadLatestArticle(TicketId);
        //    }
        //}

        private TicketModel selectedTicket;

        public EditViewModel(TicketModel ticket)
        {
            SelectedTicket = ticket;
        }

        // methods
        // load articles
        private async Task LoadLatestArticle(int ticketId)
        {
            try
            {
                List<ArticleModel> articles = await LoadArticlesForTicket(ticketId);

                if (articles != null)
                {
                    Articles = new List<ArticleModel>(articles);
                    ArticleModel latestArticle = GetLatestArticle(articles);
                    Body = GetBodyfromArticle(latestArticle);

                    // Aktualisierung der articleIdsString
                    ArticleIdsString = string.Join(", ", articles.Select(a => a.Id));

                    // Aktualisierung der Article_ids
                    Article_ids = articles.Select(a => a.Id).ToList();

                    ArticleId = latestArticle.Id;
                    Console.WriteLine($"Latest Article Id: {latestArticle.Id}");
                    await Console.Out.WriteLineAsync($"# Body: {Body}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Laden der Artikel: " + ex.Message);
            }
        }

        private async Task<List<ArticleModel>> LoadArticlesForTicket(int ticketId)
        {
            try
            {
                TicketProcessor ticketProcessor = TicketProcessor.Instance;
                ConnectionViewModel cvm = new ConnectionViewModel();

                string serverIP = cvm.GetServerIp();
                string zammadToken = cvm.GetZammadToken();

                return await ticketProcessor.LoadArticles(ticketId, serverIP, zammadToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Laden der Artikel: " + ex.Message);
                return null;
            }
        }

        // methods
        public ArticleModel GetLatestArticle(List<ArticleModel> articles)
        {
            if (articles == null)
            {
                return null;
            }
            return articles.OrderByDescending(a => a.Id).FirstOrDefault();
        }

        // get body
        public string GetBodyfromArticle(ArticleModel latestArticle)
        {
            if (latestArticle == null)
            {
                return null;
            }
            string cleanedBody = RemoveHtmlTags(latestArticle.Body);

            return cleanedBody;
        }

        // remove tags
        private string RemoveHtmlTags(string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
}
