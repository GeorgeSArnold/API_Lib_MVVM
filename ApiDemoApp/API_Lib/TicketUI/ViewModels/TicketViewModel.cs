using API_Lib;
using API_Lib.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace TicketUI.ViewModels
{
    public class TicketViewModel : Screen
    {
        #region props

        // input
        private int ticketId;

        // ticket fields
        private int id;
        private int number;
        private string title;
        private string group;
        private string state;
        private string priority;
        private string created_at;
        private List<int> article_ids;
        private string articleIdsString;

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

        public string Group
        {
            get { return group; }
            set
            {
                group = value;
                NotifyOfPropertyChange(() => Group);
            }
        }

        public string State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyOfPropertyChange(() => State);
            }
        }

        public string Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                NotifyOfPropertyChange(() => Priority);
            }
        }

        public string Created_at
        {
            get { return created_at; }
            set
            {
                created_at = value;
                NotifyOfPropertyChange(() => Created_at);
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
        #endregion

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
                    Console.WriteLine($"# input Id:{ticketId} ");
                    Console.WriteLine($"# Id: {ticket.Id}");
                    Console.WriteLine($"# Number: {ticket.Number}");
                    Console.WriteLine($"# Title: {ticket.Title}");
                    Console.WriteLine($"# Group: {ticket.Group}");
                    Console.WriteLine($"# State: {ticket.State}");
                    Console.WriteLine($"# Priority: {ticket.Priority}");
                    Console.WriteLine($"# Created_ad: {ticket.Created_at}");
                    Console.WriteLine($"# Article_ids: {ticket.Article_ids.ToString()}");

                    Id = ticket.Id;
                    Number = ticket.Number;
                    Title = ticket.Title;
                    Group = ticket.Group;
                    State = ticket.State;
                    Priority = ticket.Priority;
                    Created_at = ticket.Created_at;
                    Article_ids = ticket.Article_ids;

                    // Update ArticleIdsString
                    ArticleIdsString = string.Join(", ", Article_ids);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid ticket id... " + ex.Message);
            }
        }
    }
}
