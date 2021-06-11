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
        public static MainWindow Instance;

        public string SearchTerm { get { return TxtBxSearch.Text.ToLower(); } }

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

        /// <summary>
        /// 
        /// </summary>
        private void InitialSetup()
        {
            //Singleton Pattern
            Instance = this;

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

            //TODO: REMOVE BEFORE PUBLISHING
            ////Dummy Data
            //SQLHandler.InsertIntoDB(@"C:\Users\ronan\Documents\Test\", SQLConverter.InsertStatement("ClientTable",new ClientObject(0,"ANS","Mark","Cassidy","mc@gmail.com","+353 086 236 0189","Test Address")));
            //SQLHandler.InsertIntoDB(@"C:\Users\ronan\Documents\Test\", SQLConverter.InsertStatement("ClientTable",new ClientObject(0,"Nano Studios","Ronan","Cassidy","rc@gmail.com","+353 434 236 0189","Yes Address")));
        }

        /// <summary>
        /// Event triggered when rail menu tabs are selected, navigates to page without filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        LoadPage(inventoryPage, string.Empty);
                        break;

                    case "TbItmEmployee":
                        LoadPage(employeePage, string.Empty);
                        break;

                    case "TbItmClient":
                        LoadPage(clientPage, string.Empty);
                        break;

                    case "TbItmJobs":
                        LoadPage(jobsPage, string.Empty);
                        break;
                }
            }
        }


        /// <summary>
        /// Key Down Handler for Search Textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            //When Enter is hit and textbox is focused
            if (e.Key == Key.Enter)
            {
                string selection = CmbBxSearchType.SelectedValue.ToString();
                switch (CmbBxSearchType.SelectedValue.ToString())
                {
                    case "Employee":
                        SearchLoad(inventoryPage, 2, TxtBxSearch.Text);
                        break;

                    case "Equipment":
                        SearchLoad(inventoryPage, 1, TxtBxSearch.Text);
                        break;

                    case "Clients":
                        SearchLoad(clientPage, 3, TxtBxSearch.Text);
                        break;

                    case "Jobs":
                        SearchLoad(jobsPage, 4, TxtBxSearch.Text);
                        break;
                }
            }
        }


        /// <summary>
        /// Loads the passed in page in the main frame and passes the term in the search bar as a filter
        /// </summary>
        /// <param name="page"></param>
        /// <param name="filter"></param>
        private void LoadPage(Page page, string filter)
        {
            (page as IFilterable).SetFilter(filter); 
            FrmViews.Navigate(page);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="railIndex"></param>
        /// <param name="filter"></param>
        private void SearchLoad(Page page,int railIndex,string filter)
        {
            if (MainRailMenu.SelectedIndex != railIndex)
            {
                MainRailMenu.SelectedIndex = railIndex;
                LoadPage(page, filter);
            }
            else
            {
                (page as IFilterable).SetFilter(filter);
                (page as IRefreshableList).RefreshList();
            }
        }
    }
}
