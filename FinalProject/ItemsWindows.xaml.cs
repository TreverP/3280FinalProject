using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class ItemsWindow : Window
    {

        /// <summary>
        /// class for running queries against database
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// Holds the query results
        /// </summary>
        private DataSet ds;

        /// <summary>
        /// Class with all the SQL query strings
        /// </summary>
        private clsSQL sql;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="db">DataAccess class for running queries</param>
        /// <param name="sql">SQL class to get query strings</param>
        public ItemsWindow(clsDataAccess db, clsSQL sql)
        {
            try
            {
                InitializeComponent();

                this.db = db;
                this.sql = sql;

                // Ensure textboxes are empty
                ItemCodeTB.Text = "";
                ItemDescTB.Text = "";
                ItemCostTB.Text = "";

                PopulateItemsDataGrid();

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }

        // Internal methods
        private void PopulateItemsDataGrid()
        {
            try
            {
                int iRet = 0;
                ds = db.ExecuteSQLStatement(sql.SelectAllItems(), ref iRet);

                ItemDG.ItemsSource = new DataView(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        // Event Methods

        /// <summary>
        /// Delete selected Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Edit selected Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Add new Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Navigate back to Main Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
