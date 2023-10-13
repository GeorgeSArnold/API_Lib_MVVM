using API_Lib.Models;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TicketUI.Utilitys;
using System.Linq;
using System;
using System.Windows;
using TicketUI.Views;

namespace TicketUI.ViewModels
{
    public class ChatGptViewModel : Screen
    {
        // article list
        private ObservableCollection<ArticleModel> articlesForTickets;

        // datagrid
        private ObservableCollection<TicketModel> ticketList;
        public ObservableCollection<TicketModel> TicketList
        {
            get { return ticketList; }
            set
            {
                ticketList = value;
                NotifyOfPropertyChange(() => TicketList);
            }
        }

        // const
        public ChatGptViewModel()
        {
            // init ticketlist > datagrid
            TicketList = new ObservableCollection<TicketModel>();

            // load dummys
            LoadDummyTickets();

            // generate articles
            articlesForTickets = GenerateArticleModels(TicketList);

            // load article bodys
            LoadArticleBodys();

            DisplayGeneratedArticles();
        }

        // bind EditTicket() > UI
        private ICommand editTicketCommand;
        public ICommand EditTicketCommand
        {
            get
            {
                if (editTicketCommand == null)
                    editTicketCommand = new RelayCommand(param => EditTicket());
                return editTicketCommand;
            }
        }

        // selected Ticket > ChatGptEditView
        private TicketModel selectedTicket;
        public TicketModel SelectedTicket
        {
            get { return selectedTicket; }
            set
            {
                selectedTicket = value;
                NotifyOfPropertyChange(() => SelectedTicket);
            }
        }

        // txtboxes (body, responseText) data > UI 
        private string body;
        public string Body
        {
            get { return body; }
            set
            {
                body = value;
                NotifyOfPropertyChange(() => Body);
            }
        }
        private string responseText;
        public string ResponseText
        {
            get { return responseText; }
            set
            {
                responseText = value;
                NotifyOfPropertyChange(() => ResponseText);
            }
        }

        // methods
        public ObservableCollection<ArticleModel> GenerateArticleModels(ObservableCollection<TicketModel> tickets)
        {
            ObservableCollection<ArticleModel> articles = new ObservableCollection<ArticleModel>();

            foreach (var ticket in tickets)
            {
                foreach (var articleId in ticket.Article_ids)
                {
                    articles.Add(new ArticleModel
                    {
                        Id = articleId,
                        Ticket_id = ticket.Id,
                        Body = $"Artikel-Body für Ticket {ticket.Number}, Artikel ID {articleId}"
                    });
                }
            }

            return articles;
        }
        public void LoadDummyTickets()
        {
            ObservableCollection<TicketModel> tickets = new ObservableCollection<TicketModel>
    {
        new TicketModel
        {
            Id = 1,
            Number = 101,
            Title = "Dummy Ticket 1",
            Group = "Gruppe A",
            State = "Offen",
            Priority = "Hoch",
            Created_at = "2023-10-10",
            Article_ids = new List<int> { 1, 2, 3 }
        },
        new TicketModel
        {
            Id = 2,
            Number = 102,
            Title = "Dummy Ticket 2",
            Group = "Gruppe B",
            State = "In Bearbeitung",
            Priority = "Mittel",
            Created_at = "2023-10-11",
            Article_ids = new List<int> { 4 }
        },
        new TicketModel
        {
            Id = 3,
            Number = 103,
            Title = "Dummy Ticket 3",
            Group = "Gruppe C",
            State = "Geschlossen",
            Priority = "Niedrig",
            Created_at = "2023-10-12",
            Article_ids = new List<int> { 5, 6 }
        }
    };

            TicketList = tickets;
        }
        public void UpdateArticleBody(int articleId, string newBody)
        {
            var article = articlesForTickets.FirstOrDefault(a => a.Id == articleId);
            if (article != null)
            {
                article.Body = newBody;
            }
        }
        public void DisplayGeneratedArticles()
        {
            Console.WriteLine("# Generated Article Models:");

            foreach (var article in articlesForTickets)
            {
                Console.WriteLine($"--> Article ID: {article.Id}, Ticket ID: {article.Ticket_id}, Body: {article.Body}");
            }

        }
        public void LoadArticleBodys()
        {
            // Beispielaufruf zum Aktualisieren des Body für Artikel mit ID 1
            UpdateArticleBody(1, "Neuer Body für Artikel 1");

            // Beispielaufruf zum Aktualisieren des Body für Artikel mit ID 2
            UpdateArticleBody(2, "Neuer Body für Artikel 2");

            // Beispielaufruf zum Aktualisieren des Body für Artikel mit ID 3
            UpdateArticleBody(3, "Neuer Body für Artikel 3");

            // Beispielaufruf zum Aktualisieren des Body für Artikel mit ID 4
            UpdateArticleBody(4, "Neuer Body für Artikel 4");

            // Beispielaufruf zum Aktualisieren des Body für Artikel mit ID 5
            UpdateArticleBody(5, "Neuer Body für Artikel 5");

            // Beispielaufruf zum Aktualisieren des Body für Artikel mit ID 6
            UpdateArticleBody(6, "Neuer Body für Artikel 6");
        }
        public void EditTicket()
        {
            Console.WriteLine("---> edit btn clicked <---");

            TicketModel selectedTicket = SelectedTicket;

            if (selectedTicket != null)
            {
                ChatGptEditViewModel chatGpteditViewModel = new ChatGptEditViewModel(selectedTicket, articlesForTickets);
                ChatGptEditView ev = new ChatGptEditView(selectedTicket, articlesForTickets); // Übergebe articlesForTickets hier
                ev.DataContext = chatGpteditViewModel;
                ev.Show();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie ein Ticket aus.");
            }
        }
        public string GetLastArticleBody()
        {
            if (SelectedTicket != null)
            {
                int lastArticleId = SelectedTicket.Article_ids.Any() ? SelectedTicket.Article_ids.Max() : 0;
                ArticleModel lastArticle = articlesForTickets.FirstOrDefault(article => article.Id == lastArticleId);

                if (lastArticle != null)
                {
                    return lastArticle.Body;
                }
            }

            return "Kein Artikel gefunden.";
        }
    }
}
