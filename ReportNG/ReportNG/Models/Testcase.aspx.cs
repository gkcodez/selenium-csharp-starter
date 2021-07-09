using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;

namespace ReportNG.Models
{
	public partial class Testcase : System.Web.UI.Page
	{
		public string buildId { get; private set; }
		public int testCaseId { get; private set; }

		protected int totalCount = 0;
		protected int passCount = 0;
		protected int failCount = 0;

		private static string[,] ClassNames = { { "PASSED", "DARKSEAGREEN" }, { "FAILED", "INDIANRED" } };

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.QueryString["buildId"] != null)
			{
				buildId = Request.QueryString["buildId"];
			}
		}

		protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
		{
			string className = e.Row.Cells[2].Text.Trim();
			string backColor = "TRANSPARENT";
			string foreColor = "WHITE";

			for (int i = 0; i <= ClassNames.GetUpperBound(0); i++)
			{
				if (ClassNames[i, 0] == className)
				{
					if (className.Equals("FAILED"))
					{
						failCount++;
					}
					else
					{
						passCount++;
					}
					totalCount++;
					backColor = ClassNames[i, 1];
					e.Row.Cells[2].BackColor = Color.FromName(backColor);
					e.Row.Cells[2].ForeColor = Color.FromName(foreColor);
					break;
				}
			}
		}

		protected void OnDataBound(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt.Columns.AddRange(new DataColumn[3] { new DataColumn("TOTAL"), new DataColumn("PASSED"), new DataColumn("FAILED") });
			dt.Rows.Add(totalCount.ToString(), passCount.ToString(), failCount.ToString());
			GridView2.DataSource = dt;
			GridView2.DataBind();
			//SqlDataSource SqlDataSource1 = new SqlDataSource();
			//SqlDataSource1.ID = "BuildSummary";
			//SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings["AUTOMATIONConnectionString"].ConnectionString;
			//SqlDataSource1.SelectCommand = "SELECT * FROM tblBuildSummary";
			//GridView2.DataSource = SqlDataSource1;
			//GridView2.DataBind();
		}

		protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName != "ViewDetails") return;
			testCaseId = Convert.ToInt32(e.CommandArgument);
			Response.Redirect("Teststep.aspx?testCaseId=" + testCaseId);
		}
	}
}