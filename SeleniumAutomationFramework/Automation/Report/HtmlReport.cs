using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Automation.Base;
using Automation.Enums;
using Automation.Helpers;

namespace Automation.Report
{
	public class HtmlReport
	{
		private static StringBuilder htmlBuilder = new StringBuilder();
		private static int serialNo = 1;
		private static string featureName = string.Empty;

		private HtmlReport()
		{
			Initialize();
		}

		private static void Initialize()
		{
			if (Config.ReportEnabled)
			{
				string styleSheet = FileHelper.ReadFileFromDll("Automation.NGReport", "Report.css");
				htmlBuilder.AppendLine("<html>");
				htmlBuilder.AppendLine("<head>");
				htmlBuilder.AppendLine("<title>SELENIUM AUTOMATION FRAMEWORK</title>");
				htmlBuilder.AppendLine("<link href = \"https://fonts.googleapis.com/css?family=Roboto\" rel = \"stylesheet\">");
				htmlBuilder.AppendLine("<style>");
				htmlBuilder.AppendLine(styleSheet);
				htmlBuilder.AppendLine("</style>");
				htmlBuilder.AppendLine("</head>");
				htmlBuilder.AppendLine("<body>");
				htmlBuilder.AppendLine("<div class =\"header\">");
				htmlBuilder.AppendLine("<h1 class=\"ribbon-banner\"><span>NG REPORTS</span></h1>");
				htmlBuilder.AppendLine("<h4 id=\"subtitle\">Automated Selenium Reporting Framework</h4>");
				htmlBuilder.AppendLine("</div>");
				htmlBuilder.AppendLine("<table class=\"summary\">");
				htmlBuilder.AppendLine("<tr>");
				htmlBuilder.AppendLine($"<th>EXECUTED BY</th>");
				htmlBuilder.AppendLine($"<th>STARTED AT</th>");
				htmlBuilder.AppendLine("</tr>");
				htmlBuilder.AppendLine("<tr>");
				htmlBuilder.AppendLine($"<td>{Environment.MachineName}</td>");
				htmlBuilder.AppendLine($"<td>{DateTime.Now.ToString("dd-MM-yyyy")}</td>");
				htmlBuilder.AppendLine("</tr>");
				htmlBuilder.AppendLine("</table>");
				htmlBuilder.AppendLine("</div>");
				htmlBuilder.AppendLine("<button id = \"expandtoggle\">EXPAND TOGGLE</button>");
				htmlBuilder.AppendLine("<h4 id=\"detailstitle\">BUILD DETAILS</h4>");
			}
		}

		public static void CreateTest(string testName)
		{
			if (Config.ReportEnabled)
			{
				List<string> columnNames = new List<string>();
				columnNames.Add("S.No");
				columnNames.Add("App Name");
				columnNames.Add("Feature Name");
				columnNames.Add("Step Description");
				columnNames.Add("Result");
				columnNames.Add("Screenshot");
				columnNames.Add("Exception");
				htmlBuilder.AppendLine("<button id=\"test\" class=\"testcase\">");
				htmlBuilder.AppendLine("TEST NAME : " + testName.ToUpper());
				htmlBuilder.AppendLine("</button>");
				htmlBuilder.AppendLine("<div class=\"panel\">");
				htmlBuilder.AppendLine("<table>");
				htmlBuilder.AppendLine("<tr>");

				foreach (var columnName in columnNames)
				{
					switch (columnName.ToLower().ExecuteRegex("[a-z]"))
					{
						case "sno":
							htmlBuilder.AppendLine("<th width=\"5%\">");
							break;

						case "appname":
							htmlBuilder.AppendLine("<th width=\"10%\">");
							break;

						case "featurename":
							htmlBuilder.AppendLine("<th width=\"10%\">");
							break;

						case "stepdescription":
							htmlBuilder.AppendLine("<th width=\"45%\">");
							break;

						case "result":
							htmlBuilder.AppendLine("<th width=\"5%\">");
							break;

						case "screenshot":
							htmlBuilder.AppendLine("<th width=\"10%\">");
							break;

						case "exception":
							htmlBuilder.AppendLine("<th width=\"15%\">");
							break;

						default:
							break;
					}
					htmlBuilder.AppendLine(columnName);
					htmlBuilder.AppendLine("</th>");
				}
				htmlBuilder.AppendLine("</tr>");
				featureName = testName;
			}
		}

		public static void WriteLine(string description, Result result, Bitmap screenshot = null, Exception exception = null)
		{
			if (Config.ReportEnabled)
			{
				htmlBuilder.AppendLine("<tr>");
				CreateCell(serialNo.ToString());
				CreateCell(Config.AppName);
				CreateCell(featureName);
				CreateCell(description);
				CreateCell(result);
				CreateCell(screenshot);
				CreateCell(exception);
				serialNo++;
			}
		}

		private static void CreateCell(string cellValue)
		{
			htmlBuilder.AppendLine("<td>");
			htmlBuilder.AppendLine(cellValue);
			htmlBuilder.AppendLine("</td>");
		}

		private static void CreateCell(Result result)
		{
			switch (result)
			{
				case Result.Passed:
					htmlBuilder.AppendLine("<td class=\"resultpass\">");
					break;

				case Result.Info:
					htmlBuilder.AppendLine("<td class=\"resultinfo\">");
					break;

				case Result.Failed:
					htmlBuilder.AppendLine("<td class=\"resultfail\">");
					break;

				default:
					break;
			}
			htmlBuilder.AppendLine(result.ToString());
			htmlBuilder.AppendLine("</td>");
		}

		private static void CreateCell(Bitmap screenshot)
		{
			htmlBuilder.AppendLine("<td>");

			if (screenshot != null)
			{
				htmlBuilder.AppendLine("<a class=\"screenshot\" href=\"#image\">");
				htmlBuilder.AppendLine($"<img src =\"{ScreenshotHelper.Screenshot}\">");
				htmlBuilder.AppendLine("</a>");
				htmlBuilder.AppendLine("<div class=\"screenshot-target\" id=\"image\">");
				htmlBuilder.AppendLine($"<img src =\"{ScreenshotHelper.Screenshot}\"/>");
				htmlBuilder.AppendLine("<a class=\"screenshot-close\" href=\"#\"></a>");
				htmlBuilder.AppendLine("</div>");
			}
			else
			{
				htmlBuilder.AppendLine("");
			}
			htmlBuilder.AppendLine("</td>");
		}

		private static void CreateCell(Exception exception)
		{
			htmlBuilder.AppendLine("<td>");

			if (exception != null)
			{
				htmlBuilder.AppendLine(exception.Message);
			}
			else
			{
				htmlBuilder.AppendLine("");
			}
			htmlBuilder.AppendLine("</td>");
		}

		public static void FinishTest()
		{
			if (Config.ReportEnabled)
			{
				htmlBuilder.AppendLine("</tr>");
				htmlBuilder.AppendLine("</table>");
				htmlBuilder.AppendLine("</div>");
			}
		}

		public static void Flush()
		{
			if (Config.ReportEnabled)
			{
				htmlBuilder.AppendLine("<script>");
				htmlBuilder.AppendLine("var acc = document.getElementsByClassName(\"testcase\"); var i; for (i = 0; i < acc.length; i++) { acc[i].onclick = myFunction } function myFunction(){ this.classList.toggle(\"active\"); var panel = this.nextElementSibling; if (panel.style.maxHeight) { panel.style.maxHeight = null; } else { panel.style.maxHeight = panel.scrollHeight + \"px\";}}");
				htmlBuilder.AppendLine("var toggle = document.getElementById(\"expandtoggle\"); toggle.onclick=expandToggle; function expandToggle(){ var i; for (i = 0; i < acc.length; i++) { acc[i].classList.toggle(\"active\");} var panel = document.getElementsByClassName(\"panel\"); var i; for (i = 0; i < panel.length; i++) if (panel[i].style.maxHeight) { panel[i].style.maxHeight = null; } else { panel[i].style.maxHeight = panel[i].scrollHeight + \"px\";}}");
				htmlBuilder.AppendLine("</script>");
				htmlBuilder.AppendLine("</body>");
				htmlBuilder.AppendLine("</html>");
				string htmlReport = Path.Combine(Config.ReportPath, NameHelper.FullNameWithFormat(FileFormat.Html));
				File.Create(htmlReport).Close();
				File.WriteAllText(htmlReport, htmlBuilder.ToString());
				htmlBuilder.Clear();
				serialNo = 1;
			}
		}
	}
}