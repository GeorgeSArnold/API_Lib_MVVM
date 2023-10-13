using API_Lib.Models;
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


        public ChatGptEditViewModel(TicketModel ticket, ObservableCollection<ArticleModel> articles)
        {
            SelectedTicket = ticket;
            articlesForTickets = articles;
            LoadLastArticleBody();
        }

        private ObservableCollection<ArticleModel> articlesForTickets; // set Collection

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

    }
}
