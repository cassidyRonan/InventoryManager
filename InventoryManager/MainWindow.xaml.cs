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

            SQLHandler.CreateNewDB(@"C:\Users\ronan\Documents\Test\");
        }

        private void MainRailMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.Source is TabControl)
            {
                TabItem selectedTab = e.AddedItems[0] as TabItem;

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
    }
}
