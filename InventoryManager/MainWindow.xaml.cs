using InventoryManager.DataObjects;
using InventoryManager.Pages;
using InventoryManager.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Application Pages
        Clients clientPage;
        Dashboard dashboardPage;
        Employee employeePage;
        Inventory inventoryPage;
        Jobs jobsPage;

        public MainWindow()
        {
            InitializeComponent();
            InitialSetup();
        }

        private void InitialSetup()
        {
            //Initialisation of application pages.
            clientPage = new Clients();
            dashboardPage = new Dashboard();
            employeePage = new Employee();
            inventoryPage = new Inventory();
            jobsPage = new Jobs();

            //Default page navigation
            FrmViews.Navigate(dashboardPage);

            //Create new sqlite database if one doesn't already exist
            SQLHandler.CreateNewDB(@"C:\Users\ronan\Documents\Test\");
        }

        private void MainRailMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Ensures that sellection changed source is a tab control
            if(e.Source is TabControl)
            {
                //Cast source as TabItem to get header
                TabItem selectedTab = e.AddedItems[0] as TabItem;

                //Take in Header name and use for deciding frame navigation destination
                switch (selectedTab.Name)
                {
                    default:
                    case "TbItmDashboard":
                        FrmViews.Navigate(dashboardPage);
                        break;

                    case "TbItmInventory":
                        FrmViews.Navigate(inventoryPage);
                        break;

                    case "TbItmEmployee":
                        FrmViews.Navigate(employeePage);
                        break;

                    case "TbItmClient":
                        FrmViews.Navigate(clientPage);
                        break;

                    case "TbItmJobs":
                        FrmViews.Navigate(jobsPage);
                        break;
                }
            }
        }

        /// <summary>
        /// On Key Down Handler for 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                //On Enter Hit
            }
        }
    }
}
