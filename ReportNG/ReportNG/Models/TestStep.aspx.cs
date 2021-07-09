using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;

namespace ReportNG.Models
{
	public partial class TestStep : System.Web.UI.Page
	{
		public string testCaseId { get; private set; }

		protected int totalCount = 0;
		protected int passCount = 0;
		protected int failCount = 0;

		private static string[,] ClassNames = { { "PASSED", "DARKSEAGREEN" }, { "FAILED", "INDIANRED" } };

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.QueryString["testCaseId"] != null)
			{
				testCaseId = Request.QueryString["testCaseId"];
			}
		}

		protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
		{
			string className = e.Row.Cells[3].Text.Trim();
			string backColor = "TRANSPARENT";
			string foreColor = "WHITE";

			for (int i = 0; i <= ClassNames.GetUpperBound(0); i++)
			{
				if (ClassNames[i, 0] == className)
				{
					if (className.Equals("FAILED"))
					{
						failCount++;
						//e.Row.Cells[4].Text = string.Format("<img src='{0}'/>", e.Row.Cells[4].Text);
					}
					else
					{
						passCount++;
					}
					totalCount++;
					backColor = ClassNames[i, 1];
					e.Row.Cells[3].BackColor = Color.FromName(backColor);
					e.Row.Cells[3].ForeColor = Color.FromName(foreColor);
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
		}
	}
}