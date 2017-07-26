using System;
using System.Collections.Generic;
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

namespace CS3280GP
{
	/// <summary>
	/// Interaction logic for SearchWindow.xaml
	/// </summary>
	public partial class SearchWindow : Window
	{
		public SearchWindow()
		{

		}

		/// <summary>
		/// method for handling exceptions
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
