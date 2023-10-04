using API_Lib;
using API_Lib.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketUI.ViewModels
{
    public class TableViewModel : Screen
    {
        private BindableCollection<TicketModel> ticketList;

        public BindableCollection<TicketModel> TicketList
        {
            get { return ticketList; }
            set 
            { 
                ticketList = value;
                NotifyOfPropertyChange(() => TicketList);
            }
        }

        // const
        public TableViewModel()
        {
            LoadDataTable();
        }

        // load data
        public async Task LoadDataTable()
        {
            try
            {
                List<TicketModel> tickets = new List<TicketModel>();
                // load connection
                TicketProcessor ticketProcessor = TicketProcessor.Instance;
                ConnectionViewModel cvm = new ConnectionViewModel();
                
                // get connection
                string serverIP = cvm.GetServerIp();
                string zammadToken = cvm.GetZammadToken();

                // load ticket
                tickets = await ticketProcessor.LoadTickets(serverIP, zammadToken);

                // check loaded ticket
                if (tickets != null)
                {
                    // load tickets > bindableCollection > datagrid UI
                    TicketList = new BindableCollection<TicketModel>(tickets);

                    // display tickets > console
                    DisplayTickets(tickets);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid ticket id... " + ex.Message);
            }
        }

        // methods
        public void DisplayTickets(List<TicketModel> tickets)
        {
            Console.WriteLine("# loaded tickets > table:");
            foreach (TicketModel ticket in tickets)
            {
                Console.WriteLine($@"
# Id:{ticket.Id.ToString()}
# Number:{ticket.Number.ToString()}
# Title:{ticket.Title.ToString()}
# Group:{ticket.Group.ToString()}
# State:{ticket.State.ToString()}
# Priority:{ticket.Priority.ToString()}"
);
            }
        }

        public void RefreshTable(List<TicketModel> tickets)
        {
            Console.WriteLine("# Refreshing TableView");
            TicketList.Clear();
            LoadDataTable();
            NotifyOfPropertyChange(() => TicketList);
        }
    }
}
