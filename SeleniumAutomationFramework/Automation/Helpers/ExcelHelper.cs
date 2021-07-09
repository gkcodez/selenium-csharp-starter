using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace Automation.Helpers
{
	public static class ExcelHelper
	{
		private static string filepath = "";
		private static OleDbConnection connection = null;
		public static bool headerSet = false;

		public static void EstablishConnection(string filePath, string fileName)
		{
			filepath = filePath;
			connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
		}

		public static DataTable ConvertExcelToDataTable(string sheetName = "")
		{
			DataTable dataTable = new DataTable();
			OleDbCommand cmd = new OleDbCommand();
			OleDbDataAdapter oleda = new OleDbDataAdapter();
			DataSet dataSet = new DataSet();
			DataTable dtTablesList = default(DataTable);
			int totalSheet = 0;
			connection.Open();
			dtTablesList = connection.GetSchema("TABLES");
			dtTablesList = (from dataRow in dtTablesList.AsEnumerable()
							where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
							select dataRow).CopyToDataTable();
			totalSheet = dtTablesList.Rows.Count;

			if (string.IsNullOrEmpty(sheetName))
			{
				sheetName = dtTablesList.Rows[0]["TABLE_NAME"].ToString();
			}
			dtTablesList.Clear();
			dtTablesList.Dispose();
			cmd.Connection = connection;
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
			oleda = new OleDbDataAdapter(cmd);
			oleda.Fill(dataSet, "excelData");
			dataTable = dataSet.Tables["excelData"];
			connection.Close();
			connection.Dispose();

			#region FormatExcelDataTable

			//dataTable.Columns.Remove(dataTable.Columns[0]);
			//dataTable.Columns.Remove(dataTable.Columns[dataTable.Columns.Count - 1]);

			//List<DataRow> rowsToDelete = new List<DataRow>();

			//foreach (DataRow row in dataTable.Rows)
			//{
			//	if (row.ItemArray[0].ToString().Contains("Emp"))
			//	{
			//		if (headerSet == false)
			//		{
			//			headerSet = true;
			//			break;
			//		}
			//		else
			//		{
			//			rowsToDelete.Add(row);
			//			break;
			//		}
			//	}
			//	rowsToDelete.Add(row);
			//}
			//foreach (DataRow row in rowsToDelete)
			//{
			//	dataTable.Rows.Remove(row);
			//}

			#endregion FormatExcelDataTable

			return dataTable;
		}

		#region SetFirstRowAsColumnName

		public static void SetFirstRowAsColumnName(DataTable dataTable)
		{
			foreach (DataColumn column in dataTable.Columns)
			{
				string cName = dataTable.Rows[0][column.ColumnName].ToString();
				if (!dataTable.Columns.Contains(cName) && cName != "")
				{
					column.ColumnName = cName;
				}
			}
			dataTable.Rows.Remove(dataTable.Rows[0]);
		}

		#endregion SetFirstRowAsColumnName
	}
}