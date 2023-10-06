using API_Lib.Models;
using System.Windows;
using TicketUI.ViewModels;

namespace TicketUI.Views
{
    /// <summary>
    /// Interaction logic for EditView.xaml
    /// </summary>
    public partial class EditView : Window
    {
        public TicketModel SelectedTicket { get; set; }
        public EditView(TicketModel selectedTicket)
        {
            InitializeComponent();
            SelectedTicket = selectedTicket;
            DataContext = new EditViewModel(SelectedTicket);
        }
    }
}
