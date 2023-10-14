using API_Lib.Models;
using Bot_Lib.Services;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TicketUI.Utilitys;
using TicketUI.Views;

namespace TicketUI.ViewModels
{
    public class ChatGptEditViewModel : Screen
    {
        private int ticketId;
        // ticket fields
        private int id;
        private int number;
        private string title;
        private string articleIdsString;
        // articleId > UI
        private string articleId;
        // ticket props
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
        public string ArticleIdsString
        {
            get { return articleIdsString; }
            set
            {
                articleIdsString = value;
                NotifyOfPropertyChange(() => ArticleIdsString);
            }
        }
        public string CurrentArticleId
        {
            get { return articleId; }
            set
            {
                articleId = value;
                NotifyOfPropertyChange(() => CurrentArticleId);
            }
        }
        
        // collection
        private ObservableCollection<ArticleModel> articlesForTickets; // set Collection

        // selected object <--- const
        private TicketModel selectedTicket;
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
                }
            }
        }

        // const
        public ChatGptEditViewModel(TicketModel ticket, ObservableCollection<ArticleModel> articles)
        {
            SelectedTicket = ticket;
            articlesForTickets = articles;
            LoadLastArticleBody();
        }

        // input <--- article body 
        private string lastArticleBody;
        public string LastArticleBody
        {
            get { return lastArticleBody; }
            set
            {
                lastArticleBody = value;
                NotifyOfPropertyChange(() => LastArticleBody);
            }
        }
        // output ---> responseBody  
        private string responseBody;
        public string ResponseBody 
        {
            get { return responseBody; }
            set
            {
                responseBody = value;
                NotifyOfPropertyChange(() => ResponseBody);
            }
        }

        // relaycom > btn
        private ICommand getsuggestCommand;
        public ICommand GetSuggestCommand
        {
            get
            {
                if (getsuggestCommand == null)
                    getsuggestCommand = new RelayCommand(param => GetSuggest(LastArticleBody));
                return getsuggestCommand;
            }
        }

        // relay clear btn
        private ICommand clearRTxtBCommand;
        public ICommand ClearRTxtBCommand
        {
            get
            {
                if (clearRTxtBCommand == null)
                    clearRTxtBCommand = new RelayCommand(param => ClearRTxtB());
                return clearRTxtBCommand;
            }
        }

        // methods
        public void ClearRTxtB()
        {
            Console.WriteLine("---> clear txt btn clicked <---");
            if (ResponseBody != null)
            {
                ResponseBody = string.Empty;
            }
        }

        //TODO: undo btn relaycom

        // methods
        private void LoadLastArticleBody()
        {
            if (SelectedTicket != null && articlesForTickets != null)
            {
                int lastArticleId = SelectedTicket.Article_ids.Any() ? SelectedTicket.Article_ids.Max() : 0;
                ArticleModel lastArticle = articlesForTickets.FirstOrDefault(article => article.Id == lastArticleId);

                if (lastArticle != null)
                {
                    LastArticleBody = lastArticle.Body;
                    CurrentArticleId = lastArticle.Id.ToString(); // set CurrentArticleId
                }
                else
                {
                    LastArticleBody = "no article found";
                    CurrentArticleId = "N/A";
                }
            }
            else
            {
                LastArticleBody = "no article found";
            }
        }

        // latest article body > chatgpt > response body
        public async Task GetSuggest(string LastArticleBody)
        {
            await Console.Out.WriteLineAsync("---> send btn clicked <---");
            try
            {
                ConnectionViewModel cvm = new ConnectionViewModel();
                string apiToken = cvm.GetGptToken();
                OpenAiService openAiService = OpenAiService.GetInstance(apiToken);

                await Console.Out.WriteLineAsync("---> sending promt <---");
                string completion = await openAiService.GetCompletions(LastArticleBody);
                await Console.Out.WriteLineAsync("---> get completion <---");

                Console.WriteLine("Response: " + completion);

                await Console.Out.WriteLineAsync("---> complation > Response prop <---");
                ResponseBody = completion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
