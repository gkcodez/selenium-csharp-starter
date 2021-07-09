using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace ReportNG.Models
{
	public partial class Index : System.Web.UI.Page
	{
		private static string[,] ClassNames = { { "PASSED", "DARKSEAGREEN" }, { "FAILED", "INDIANRED" } };

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
		{
			string className = e.Row.Cells[4].Text.Trim();
			string backColor = "TRANSPARENT";
			string foreColor = "WHITE";

			for (int i = 0; i <= ClassNames.GetUpperBound(0); i++)
			{
				if (ClassNames[i, 0] == className)
				{
					backColor = ClassNames[i, 1];
					e.Row.Cells[4].BackColor = Color.FromName(backColor);
					e.Row.Cells[4].ForeColor = Color.FromName(foreColor);
					break;
				}
			}
		}

		protected void OnDataBound(object sender, EventArgs e)
		{
			//DataTable dt = new DataTable();
			//dt.Columns.AddRange(new DataColumn[3] { new DataColumn("TOTAL"), new DataColumn("PASSED"), new DataColumn("FAILED") });
			//dt.Rows.Add(totalCount.ToString(), passCount.ToString(), failCount.ToString());
			//GridView2.DataSourceID = BuildSummary.ToString();
			//GridView2.DataBind();
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
			int buildId = Convert.ToInt32(e.CommandArgument);
			Response.Redirect("Testcase.aspx?buildId=" + buildId);
		}
	}
}