using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for DataSourceBinding.
	/// </summary>
	public partial class DataSourceBinding : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// resolve the address to the Access database
			string fileNameString = this.MapPath(".");
			fileNameString += @"..\..\..\..\data\chartdata.mdb";

			// initialize a connection string	
            string myConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileNameString;
			
			// define the database query	
			string mySelectQuery="SELECT * FROM REPS;";

			// create a database connection object using the connection string	
			OleDbConnection myConnection = new OleDbConnection(myConnectionString);
			
			// create a database command on the connection using query	
			OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);

            myConnection.Open();

            // set chart data source - the data source must implement IEnumerable
            Chart1.DataSource = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

			// set series members names for the X and Y values 
			Chart1.Series["Series 1"].XValueMember = "Name";
			Chart1.Series["Series 1"].YValueMembers = "Sales";

			// data bind to the selected data source
			Chart1.DataBind();

			myCommand.Dispose();
			myConnection.Close();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		
	}
}
