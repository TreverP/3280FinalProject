using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Data;
=======
>>>>>>> aee3c0d483f4aa48222cf8024c1f3189b452b72a
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
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
        /// Update an individual Line Item
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <param name="iLineItemNum"></param>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public string UpdateInvoiceLineItem(string sInvoiceID, string sLineItemNum, string sItemCode)
        {
            return "UPDATE LineItems SET ItemCode = " + sItemCode + "WHERE InvoiceNum = " + sInvoiceID + " AND LineItemNum = " + sLineItemNum;
            
        }

        /// <summary>
        /// Create new line item for an invoice
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <param name="iLineItemNum"></param>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public string CreateInvoiceLineItem(string sInvoiceID, string sLineItemNum, string sItemCode)
        {
            return "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) VALUES (" + sInvoiceID + ", " + sLineItemNum + ", " + sItemCode;
        }

        /// <summary>
        /// Delete a single line item for an invoice
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <param name="sLineItemNum"></param>
        /// <returns></returns>
        public string DeleteInvoiceLineItem(string sInvoiceID, string sLineItemNum)
        {
            return "DELETE FROM LineItems WHERE InvoiceID = " + sInvoiceID + " AND LineItemNum = " + sLineItemNum;
        }

        /// <summary>
        /// Select all values for all Item Definition from ItemDesc table
        /// </summary>
        /// <returns></returns>
        public string SelectAllItems()
        {
            return "SELECT * FROM ItemDesc";
        }

        /// <summary>
        /// Update specific Item Def
        /// </summary>
        /// <param name="sItemDesc"></param>
        /// <param name="sItemCode"></param>
        /// <param name="sItemCost"></param>
        /// <returns></returns>
        public string UpdateItem(string sItemDesc, string sItemCode, string sItemCost)
        {
            return "UPDATE ItemDesc SET ItemCode = "+ sItemCode + ", ItemDesc = " + sItemDesc + ", Cost = " + sItemCost;
        }

        /// <summary>
        /// Create a new Item def
        /// </summary>
        /// <param name="sItemDesc"></param>
        /// <param name="sItemCode"></param>
        /// <param name="sItemCost"></param>
        /// <returns></returns>
        public string CreateItem(string sItemDesc, string sItemCode, string sItemCost)
        {
            return "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) VALUES (" + sItemCode + ", " + sItemDesc + ", " + sItemCost + ")";
        }

        /// <summary>
        /// Select Item def by ItemCode
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns></returns>
        public string SelectItemByCode(string sItemCode)
        {
            return "SELECT * FROM ItemDesc WHERE ItemCode = " + sItemCode;
        }
        
    }
=======
namespace CS3280GP

{
	/// <summary>
	/// Class to hold all the SQL statements for accessing the database
	/// </summary>
	class clsSQL
	{
		public clsSQL()
		{

		}
	}
>>>>>>> aee3c0d483f4aa48222cf8024c1f3189b452b72a

}
