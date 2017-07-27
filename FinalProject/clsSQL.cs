using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject

{
    /// <summary>
    /// Class to hold all the SQL statements for accessing the database
    /// </summary>
    public class clsSQL
    {
        public clsSQL() {

        }

        /// <summary>
        /// Select all values of all invoices from Invoices table
        /// </summary>
        /// <returns></returns>
        public string SelectAllInvoices()
        {
            return "SELECT * FROM Invoices";
        }

        /// <summary>
        /// Select all values of invoice with specified invoice num
        /// </summary>
        /// <param name="sInvoiceID">Desired invoice number</param>
        /// <returns></returns>
        public string SelectInvoice(string sInvoiceID)
        {
            return "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceID;
        }

        /// <summary>
        /// Select all values of all invoices with specified total charge
        /// </summary>
        /// <param name="sTotalCharge">total invoice charge</param>
        /// <returns></returns>
        public string SelectInvoiceByTotalCharge(string sTotalCharge)
        {
            return "SELECT * FROM Invoices WHERE TotalCharge = " + sTotalCharge;
        }

        /// <summary>
        /// Select all values of all invoices from the specified day
        /// </summary>
        /// <param name="sDate">Invoice date as string</param>
        /// <returns></returns>
        public string SelectInvoiceByDate(string sDate)
        {
            return "SELECT * FROM Invoices WHERE InvoiceDate = #" + sDate + "#";
        }

        /// <summary>
        /// Select all values for all Item Definition from ItemDesc table
        /// </summary>
        /// <returns></returns>
        public string SelectAllItems()
        {
            return "SELECT * FROM ItemDesc";
        }
    }

}
