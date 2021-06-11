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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Page, IFilterable,IRefreshableList
    {
        public bool Filter { get; set; }

        public string SearchTerm { get; set; }

        public Employee()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        public void RefreshList()
        {
            //List<ClientObject> clientList;
            //clientList = InventoryDAL.GetClients();

            //if (clientList != null)
            //{
            //    LstVwClients.ItemsSource = null;
            //    LstVwClients.Items.Clear();
            //    LstVwClients.ItemsSource = clientList;
            //}
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
}
