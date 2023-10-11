using API_Lib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TicketUI.ViewModels;

namespace TicketUI.Views
{
    /// <summary>
    /// Interaction logic for ChatGptEditView.xaml
    /// </summary>
    public partial class ChatGptEditView : Window
    {
        public TicketModel SelectedTicket { get; set; }

        public ChatGptEditView(TicketModel selectedTicket, ObservableCollection<ArticleModel> articles)
        {
            InitializeComponent();

            SelectedTicket = selectedTicket;
            DataContext = new ChatGptEditViewModel(SelectedTicket, articles);
        }
    }
}
