using InventoryManager.DataObjects;
using InventoryManager.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryManager.Pages
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Page, IFilterable
    {
        public bool Filter { get; set; }

        public string SearchTerm { get; set; }

        public Clients()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            LstVwClients.ItemsSource = null;
            LstVwClients.Items.Clear();

            List<ClientObject> clientList;

            if (Filter)
            {
                //Retrieval of Client List from SQLite DB with search term taken into account
                clientList = InventoryDAL.GetClients(SearchTerm);
                LstVwClients.ItemsSource = clientList;
            }
            else
            {
                //Retrieval of Client List from SQLite DB
                clientList = InventoryDAL.GetClients();
                LstVwClients.ItemsSource = clientList;
            }

        }

        public void SetFilter(string searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                Filter = true;
            }
            else
            {
                Filter = false;
            }

            SearchTerm = searchTerm;
        }

    }



    /// <summary>
    /// Interface for Page objects with the ability to filter
    /// </summary>
    public interface IFilterable
    {
        public bool Filter { get; set; }

        public string SearchTerm { get; set; }

        public void SetFilter(string searchTerm);
    }
}
