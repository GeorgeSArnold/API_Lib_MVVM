using API_Lib;
using API_Lib.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TicketUI.Views;
using TicketUI.Utilitys;

namespace TicketUI.ViewModels
{
    public class TableViewModel : Screen
    {
        // datagrid
        private DataGrid myDataGrid;
        public DataGrid MyDataGrid
        {
            get { return myDataGrid; }
            set { myDataGrid = value; }
        }

        // ticket list
        public BindableCollection<TicketModel> TicketList
        {
            get { return ticketList; }
            set 
            { 
                ticketList = value;
                NotifyOfPropertyChange(() => TicketList);
            }
        }
        private BindableCollection<TicketModel> ticketList;

        //const
        public TableViewModel()
        {
            MyDataGrid = new DataGrid();
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

        // selected Ticket > EditView
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
        // obj
        public TicketModel GetSelectedTicket()
        {
            return SelectedTicket;
        }
        
        // open > Window
        public void EditTicket()
        {
            Console.WriteLine("# Bearbeiten geklickt");

            TicketModel selectedTicket = SelectedTicket;

            if (selectedTicket != null)
            {
                EditViewModel editViewModel = new EditViewModel(selectedTicket);
                EditView ev = new EditView(selectedTicket);
                ev.DataContext = editViewModel;
                ev.Show();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie ein Ticket aus.");
            }
        }
    }
}
