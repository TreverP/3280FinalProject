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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		/// <summary>
		/// Object creation of type clsDataAccess to access the database.
		/// Hook up when others submit code, verify names.
		/// </summary>
		clsDataAccess db;

        /// <summary>
        /// SQL query obj
        /// </summary>
        private clsSQL sql;

        /// <summary>
        /// Holds the data 
        /// </summary>
		DataTable dt;

        /// <summary>
        /// Holds the query results
        /// </summary>
        private DataSet ds;
        

        /// <summary>
        /// Currently selected invoice. 
        /// This property is passed in to the search window and is set when the user selects an invoice there.
        /// </summary>
        string sInvoiceNum;

        private ItemsWindow itemsWindow; // ItemsWindow obj
		
        public MainWindow()
        {
            InitializeComponent();

            db = new clsDataAccess();
            sql = new clsSQL();

            ItemPriceTxtBx.IsReadOnly = true;
            TotalTxtBx.IsReadOnly = true;

            LoadInvoiceComBx();

		}

        /// <summary>
        /// Internal method for loading drop-down menu for editing an existing invoice.
        /// </summary>
        private void LoadInvoiceComBx()
        {
            try
            {
                int iRet = 0;
                ds = db.ExecuteSQLStatement(sql.SelectAllInvoices(), ref iRet);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    InvoiceNumberComBx.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

		/// <summary>
		/// When the Search For Invoice Button is clicked, it will open up the Search Window.
        /// The sInvoiceNum property is set to the selected invoice in the search window.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SearchForInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				SearchWindow search = new SearchWindow(db, sql);
                this.Hide(); //Hide the main window.
                search.ShowDialog(); //Bring search window up to the front.
                this.Show();
                sInvoiceNum = search.sInvoiceNum;
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		/// <summary>
		/// Allows user to create a new invoice.
		/// Enables fields to create new invoices and save them.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CreateInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
                // When selected the UI will be prepped for invoice creation.
			    UpdateDefMenuItem.IsEnabled = false; // Item def updates not allowed during Invoice creation
			    SaveBtn.IsEnabled = true;
			}
            catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		/// <summary>
		/// Allows user to edit an invoice.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EditInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
			    // When selected the UI will be prepped for invoice editing.
			    UpdateDefMenuItem.IsEnabled = false; // Item def updates not allowed during Invoice editing
			    SaveBtn.IsEnabled = true;
            }
            catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		/// <summary>
		/// Allows user to delete an invoice.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
			    // When selected delete invoice, refresh (clear) UI, repopulate InvoiceNum combobox
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}


		/// <summary>
		/// When drop down is selected will populate with Invoice ID's.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InvoiceNumberComBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		    ComboBox selectedItem = (ComboBox) sender;
            
		    TotalTxtBx.Text = ds.Tables[0].Rows[selectedItem.SelectedIndex][2].ToString();
            InvoiceDatePicker.Text = ds.Tables[0].Rows[selectedItem.SelectedIndex][1].ToString();
            // Load data into data grid for selected invoice
        }

		/// <summary>
		/// When drop-down is selected it will populate with data.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemDropDownBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            // When an item is selected load the price (read-only) text box
		}

        /// <summary>
        /// Allows the user to update a definition table by opening the form.
        /// Currently disabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDefMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                itemsWindow = new ItemsWindow(db, sql);
                this.Hide();
                itemsWindow.ShowDialog();
                this.Show();
                // Update displayed invoice and Items dropdown list
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void SearchInvoiceMenuItem_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchWindow search = new SearchWindow(db, sql);
                this.Hide(); //Hide the main window.
                search.ShowDialog(); //Bring search window up to the front.
                this.Show();
                sInvoiceNum = search.sInvoiceNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
