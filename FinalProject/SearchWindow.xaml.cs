using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.Reflection;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
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
        /// Initialize search window
        /// </summary>
        /// <param name="db">DataAccess class for running queries</param>
        /// <param name="sql">SQL class to get query strings</param>
        public SearchWindow(clsDataAccess db, clsSQL sql)
        {
            try
            {
                InitializeComponent();

                this.db = db;
                this.sql = sql;
                FillInvoiceDataGrid();
                FillInvoiceComboBox();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Get all invoices and put them in the datagrid
        /// </summary>
        private void FillInvoiceDataGrid()
        {
            try
            {
                int iRet = 0;
                ds = db.ExecuteSQLStatement(sql.SelectAllInvoices(), ref iRet);

                dgInvoices.ItemsSource = new DataView(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Clear and fill the comboboxes with invoice data currently selected. 
        /// </summary>
        private void FillInvoiceComboBox()
        {
            try
            {
                comboInvoiceCharge.Items.Clear();
                comboInvoiceNum.Items.Clear();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    comboInvoiceNum.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    comboInvoiceCharge.Items.Add(ds.Tables[0].Rows[i][2].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Get invoice by invoice number selected from combo box and fill datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceNumberComBx_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboInvoiceNum.SelectedItem != null)
                {
                    int iRet = 0;
                    ds = db.ExecuteSQLStatement(sql.SelectInvoice((string)comboInvoiceNum.SelectedItem), ref iRet);
                    dgInvoices.ItemsSource = new DataView(ds.Tables[0]);
                    FillInvoiceComboBox();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Get all invoices with the TotalCharge equal to selection from combo box and fill datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceChargeComBx_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboInvoiceCharge.SelectedItem != null)
                {
                    int iRet = 0;
                    ds = db.ExecuteSQLStatement(sql.SelectInvoiceByTotalCharge((string)comboInvoiceCharge.SelectedItem), ref iRet);
                    dgInvoices.ItemsSource = new DataView(ds.Tables[0]);
                    FillInvoiceComboBox();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        /// <summary>
        /// Get all invoices from the same day as selected date and fill datagrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceDatePicker_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateInvoice.SelectedDate != null)
                {
                    int iRet = 0;
                    ds = db.ExecuteSQLStatement(sql.SelectInvoiceByDate(dateInvoice.SelectedDate.ToString()), ref iRet);
                    dgInvoices.ItemsSource = new DataView(ds.Tables[0]);
                    FillInvoiceComboBox();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Enable Select Invoice button when an invoice row is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgInvoices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectInvoiceBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        
        /// <summary>
        /// Currently only shows a message box with the selected invoice num. Should close the form and return the selected Invoice num to main window somehow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectInvoiceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView view = (DataRowView)dgInvoices.SelectedItem;
                MessageBox.Show(view.Row[0].ToString());
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        ///  Clear all search criteria and reset window to inital state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetFormBtn_Click(object sender, EventArgs e)
        {
            try
            {
                FillInvoiceDataGrid();
                FillInvoiceComboBox();
                SelectInvoiceBtn.IsEnabled = false;
                dateInvoice.SelectedDate = null;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// method for handling excpetions
        /// </summary>
        /// <param name="sClass">class from which exception originated</param>
        /// <param name="sMethod">method from which exception originated</param>
        /// <param name="sMessage">exception message</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + ": " + sMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(sClass + "." + sMethod + " (HandleError Exception): " + ex.Message + " " + sMessage);
            }
        }
    }
}
