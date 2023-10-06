using API_Lib.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using TicketUI.ViewModels;

namespace TicketUI.Views
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl
    {
        public TableView()
        {
            InitializeComponent();
            DataContext = new TableViewModel();
        }
    }
}
