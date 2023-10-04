using API_Lib.Models;
using API_Lib;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;
using System.Text.RegularExpressions;

namespace TicketUI.ViewModels
{
    public class ArticleViewModel : Screen
    {
        #region Ticket props + display methods

        // input
        private int ticketId;

        // ticket fields
        private int id;
        private int number;
        private string title;
        private List<int> article_ids;
        private string articleIdsString;
        
        // articleId > Input
        private int articleId;

        // input > UI
        public int TicketId
        {
            get { return ticketId; }
            set
            {
                ticketId = value;
                NotifyOfPropertyChange(() => TicketId);
            }
        }

        // ticket output
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

        // display methods
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
        // method
        // load ticket 
        public async Task LoadTicketAndPrint(int ticketId)
        {
            try
            {
                if (ticketId == 0)
                {
                    MessageBox.Show("please insert ticket id...");
                    return;
                }
                // load connection
                TicketProcessor ticketProcessor = TicketProcessor.Instance;

                ConnectionViewModel cvm = new ConnectionViewModel();

                string serverIP = cvm.GetServerIp();
                string zammadToken = cvm.GetZammadToken();

                // load ticket
                TicketModel ticket = await ticketProcessor.LoadTicket(ticketId, serverIP, zammadToken);

                // check loaded ticket
                if (ticket != null)
                {
                    Id = ticket.Id;
                    Number = ticket.Number;
                    Title = ticket.Title;

                    Article_ids = ticket.Article_ids;

                    ArticleIdsString = string.Join(", ", Article_ids);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid ticket id... " + ex.Message);
            }
        }

        #endregion

        private List<ArticleModel> articles;
        private string body;

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

        // body < article
        public string Body
        {
            get { return body; }
            set
            {
                body = value;
                NotifyOfPropertyChange(() => Body);
            }
        }

        // load articles
        public async Task LoadLatestArticle(int ticketId)
        {
            try
            {
                // articles
                List<ArticleModel> articles = new List<ArticleModel>();

                // latest article
                ArticleModel latestArticle = new ArticleModel();

                // load connection
                TicketProcessor ticketProcessor = TicketProcessor.Instance;
                ConnectionViewModel cvm = new ConnectionViewModel();

                // get connection
                string serverIP = cvm.GetServerIp();
                string zammadToken = cvm.GetZammadToken();

                // load article
                articles = await ticketProcessor.LoadArticles(ticketId, serverIP, zammadToken);

                // check loaded ticket
                if (articles != null)
                {
                    // get latest article
                    Articles = new List<ArticleModel>(articles);
                    latestArticle = GetLatestArticle(articles);
                    // get body > latest article > Body > UI
                    Body = GetBodyfromArticle(latestArticle);
                    ArticleId = latestArticle.Id;

                    // check
                    await Console.Out.WriteLineAsync($"# Body: {Body}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid article id... " + ex.Message);
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
