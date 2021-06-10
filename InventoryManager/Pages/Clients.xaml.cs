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
    public partial class Clients : Page
    {
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
            List<ClientObject> clientList;
            clientList = InventoryDAL.GetClients();

            if (clientList != null)
            {
                LstVwClients.ItemsSource = null;
                LstVwClients.Items.Clear();
                LstVwClients.ItemsSource = clientList;

                List<string> Companies = new List<string>();
                Companies.Add("Unspecified");
                
                clientList.ForEach(company =>
                {
                    if (!Companies.Contains(company.CompanyName))
                    {
                        Companies.Add(company.CompanyName);
                    }
                });

                CmbBxCompany.ItemsSource = null;
                CmbBxCompany.Items.Clear();
                CmbBxCompany.ItemsSource = Companies;
                CmbBxCompany.SelectedIndex = 0;
            }
        }
    }
}
