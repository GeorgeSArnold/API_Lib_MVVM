using API_Lib.Models;
using Microsoft.SqlServer.Server;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicketUI.ViewModels;

namespace TicketUI.Views
{
    /// <summary>
    /// Interaction logic for ChatGptView.xaml
    /// </summary>
    public partial class ChatGptView : UserControl
    {
        public ChatGptView()
        {
            InitializeComponent();
            DataContext = new ChatGptViewModel();
        }
    }
}
