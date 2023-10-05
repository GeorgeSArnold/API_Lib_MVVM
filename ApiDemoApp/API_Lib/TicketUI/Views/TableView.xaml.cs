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
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            TicketModel selectedTicket = (TicketModel)MyDataGrid.SelectedItem;

            if (selectedTicket != null)
            {
                EditView ev = new EditView();
                EditViewModel editViewModel = new EditViewModel(selectedTicket);
                ev.DataContext = editViewModel;
                ev.Show();
            }
            else
            {
                MessageBox.Show("please choose ticket");
            }
        }
    }
}
