using API_Lib.Models;
using Caliburn.Micro;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TicketUI.Views;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Text.RegularExpressions;
using API_Lib;
using static API_Lib.TicketProcessor;
using System.Reflection;

namespace TicketUI.ViewModels
{
    public class TicketViewModel : Screen
    {
        // ticket props
        private int id;
        private int number;
        private string title;
        private string group;
        private string state;
        private string priority;
        private string created_at;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public string Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        public string Created_at
        {
            get { return created_at; }
            set { created_at = value; }
        }


        public async Task LoadTicketAndPrint()
        {
            try
            {
                // hardcoded id > user
                int ticketId = 3;

                // instance
                TicketProcessor ticketProcessor = TicketProcessor.Instance;

                ConnectionViewModel cvm = new ConnectionViewModel();
                
                string serverIP = cvm.GetServerIp();
                string zammadToken = cvm.GetZammadToken(); 

                // load t
                TicketModel ticket = await ticketProcessor.LoadTicket(ticketId, serverIP, zammadToken);

                // check loaded ticket
                if (ticket != null)
                {
                    Console.WriteLine("Ticket geladen:");
                    Console.WriteLine($"ID: {ticket.Id}");
                    Id = ticket.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Laden des Tickets: " + ex.Message);
            }
        }


    }
}
