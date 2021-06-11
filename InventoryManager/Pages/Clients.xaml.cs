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
    public partial class Clients : Page, IFilterable, IRefreshableList
    {
        public bool Filter { get; set; }

        public string SearchTerm { get; set; }

        public Clients()
        {
            InitializeComponent();

            TrnClient.SelectedIndex = 0;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
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

            TrnClient.SelectedIndex = 0;
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

        /// <summary>
        /// Refresh Button OnClick event which triggers a refresh of the list based on the current filter settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefreshClients_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        /// <summary>
        /// View Client Button OnClick event which takes the selected item from the list view and changes to the viewing mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnViewClient_Click(object sender, RoutedEventArgs e)
        {
            TrnClient.SelectedIndex = 1;
        }

        /// <summary>
        /// Add Client Button OnClick event which shows the UI for adding a new client to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            TrnClient.SelectedIndex = 2;
        }

        /// <summary>
        /// Edit Client Button OnClick event which shows the UI for editing the selected list view item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            TrnClient.SelectedIndex = 3;
        }

        private void BtnClientList_Click(object sender, RoutedEventArgs e)
        {
            TrnClient.SelectedIndex = 0;
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

    /// <summary>
    /// 
    /// </summary>
    public interface IRefreshableList
    {
        public void RefreshList();
    }
}
