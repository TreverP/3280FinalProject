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
		clsSQL mydb = new clsSQL();
		DataTable dt;

        private ItemsWindow itemsWindow; // ItemsWindow obj
		
        public MainWindow()
        {
            InitializeComponent();
			db = new clsDataAccess();
            

			string sSQL; //Holds a SQL statement.
			DataSet ds = new DataSet(); //Holds invoice data.

			//Automatic load of drop-down menu for editing an existing invoice.
			//Try catch for error handling.
			try
			{ 
				int iRet = 0; //Return values.
				//ds = DataSet.ExecuteSQLStatement("SELECT InvoiceNum from Invoices", ref iRet); //SQL Statement to get values.
				for (int i = 0; i < iRet; i++)
				{
					//InvoiceNumberComBx.Items.Add(ds.Tables[0].Rows[i][0].ToString()); //Adds the invoice numbers into the combo box.
				}

			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}

			///Automatically load drop-down menu for Invoice Date.
			try
			{
				int iRet = 0; //Return Values.
				ds = db.ExecuteSQLStatement("SELECT InvoiceDate FROM Invoices", ref iRet); //Get all values from the Invoice Date table.
				for (int i = 0; i < iRet; i++)
				{
					//InvoiceDateComBx.Items.Add(ds.Tables[0].Rows[i][0]).ToString();//Add Invoice Dates to the drop-down box.
				}
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}

			///Automatically load drop-down menu for Invoice Total.
			try
			{
				int iRet = 0; //Return values.
				ds = db.ExecuteSQLStatement("SELECT TotalCharge FROM Invoices", ref iRet); //Get all values from the Invoice Total.

				for (int i = 0; i < iRet; i++)
				{
					//InvoiceTotalComBx.Items.Add(ds.Tables[0].Rows[i][0].ToString()); //Add Invoice total to the drop-down box.
				}
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		/// <summary>
		/// When the Search For Invoice Button is clicked, it will open up the Search Window.
		/// With try catch error handling.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SearchForInvoiceBtn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				SearchWindow search = new SearchWindow(db, mydb);
                this.Hide(); //Hide the main window.
                search.ShowDialog(); //Bring search window up to the front.
                this.Show();
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
			
			}
			catch (Exception ex)
			{
				throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}


		/// <summary>
		/// Allows the user to update a definition table by opening the form.
		/// Currently disabled.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateDefTableBtn_Click(object sender, RoutedEventArgs e)
		{
		    try
		    {
		        itemsWindow = new ItemsWindow(db, mydb);
		        this.Hide();
		        itemsWindow.ShowDialog();
		        this.Show();
		    }
		    catch (Exception ex)
		    {
		        throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
		    }
        }


		/// <summary>
		/// Make the Item Price TextBox Read only to display price.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemPriceTxtBx_TextChanged(object sender, TextChangedEventArgs e)
		{
			ItemPriceTxtBx.IsReadOnly = true;
		}

		/// <summary>
		/// Make the Invoice Total TextBox read only so the total cannot be edited.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TotalTxtBx_TextChanged(object sender, TextChangedEventArgs e)
		{
			TotalTxtBx.IsReadOnly = true;
		}

		/// <summary>
		/// When drop down is selected will populate with Invoice ID's.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InvoiceNumberComBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}

		/// <summary>
		/// When drop-down is selected it will populate with data.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemDropDownBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
