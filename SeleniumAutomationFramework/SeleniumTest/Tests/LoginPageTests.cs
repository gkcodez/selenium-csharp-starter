using System.Collections.Generic;
using System.Data;
using Automation.Base;
using Automation.Helpers;
using Automation.Report;
using NUnit.Framework;
using SeleniumTest.Pages;

namespace SeleniumTest.Tests
{
	internal class LoginPageTests
	{
		[TestCase]
		public void LoginBookTicketsInNewTours()
		{
			NGReport.CreateTest("Login Test");
			Page.Home.LoadApplicationURL();
			Page.Login.LogintoNewTours("gopalakrishnanpv", "krishnaPV93");
			Page.FindFlights.FindFlights();
			Page.SelectFlight.SelectFlights();
			Page.BookFlight.BookTickets();
			NGReport.FinishTest();
		}

		[TestCase]
		public void LoginBookTicketsInNewTours2()
		{
			NGReport.CreateTest("Login Test");
			Page.Home.LoadApplicationURL();
			Page.Login.LogintoNewTours("gopalakrishnanpv", "krishnaPV93");
			Page.FindFlights.FindFlights();
			Page.SelectFlight.SelectFlights();
			Page.BookFlight.BookTickets();
			NGReport.FinishTest();
		}

		[TestCase]
		public void LoginBookTicketsInNewTours3()
		{
			NGReport.CreateTest("Login Test");
			Page.Home.LoadApplicationURL();
			Page.Login.LogintoNewTours("gopalakrishnanpv", "krishnaPV93");
			Page.FindFlights.FindFlights();
			Page.SelectFlight.SelectFlights();
			Page.BookFlight.BookTickets();
			NGReport.FinishTest();
		}

		[TestCase]
		public void LoginBookTicketsInNewTours4()
		{
			NGReport.CreateTest("Login Test");
			Page.Home.LoadApplicationURL();
			Page.Login.LogintoNewTours("gopalakrishnanpv", "krishnaPV93");
			Page.FindFlights.FindFlights();
			Page.SelectFlight.SelectFlights();
			Page.BookFlight.BookTickets();
			NGReport.FinishTest();
		}

		[TestCase]
		public void LoginBookTicketsInNewTours5()
		{
			NGReport.CreateTest("Login Test");
			Page.Home.LoadApplicationURL();
			Page.Login.LogintoNewTours("gopalakrishnanpv", "krishnaPV93");
			Page.FindFlights.FindFlights();
			Page.SelectFlight.SelectFlights();
			Page.BookFlight.BookTickets();
			NGReport.FinishTest();
		}

		[TestCase]
		public void LoginBookTicketsInNewTours6()
		{
			NGReport.CreateTest("Login Test");
			Page.Home.LoadApplicationURL();
			Page.Login.LogintoNewTours("gopalakrishnanpv", "krishnaPV93");
			Page.FindFlights.FindFlights();
			Page.SelectFlight.SelectFlights();
			Page.BookFlight.BookTickets();
			NGReport.FinishTest();
		}

		[TestCase]
		public void LoginBookTicketsInNewTours7()
		{
			NGReport.CreateTest("Login Test");
			Page.Home.LoadApplicationURL();
			Page.Login.LogintoNewTours("gopalakrishnanpv", "krishnaPV93");
			Page.FindFlights.FindFlights();
			Page.SelectFlight.SelectFlights();
			Page.BookFlight.BookTickets();
			NGReport.FinishTest();
		}

		[TestCase]
		public void LoginBookTicketsInNewTours8()
		{
			NGReport.CreateTest("Login Test");
			Page.Home.LoadApplicationURL();
			Page.Login.LogintoNewTours("gopalakrishnanpv", "krishnaPV93");
			Page.FindFlights.FindFlights();
			Page.SelectFlight.SelectFlights();
			Page.BookFlight.BookTickets();
			NGReport.FinishTest();
		}

		[TestCase]
		public void LoginBookTicketsInNewTours9()
		{
			NGReport.CreateTest("Login Test");
			Page.Home.LoadApplicationURL();
			Page.Login.LogintoNewTours("gopalakrishnanpv", "krishnaPV93");
			Page.FindFlights.FindFlights();
			Page.SelectFlight.SelectFlights();
			Page.BookFlight.BookTickets();
			NGReport.FinishTest();
		}

		[TestCase]
		public void LoginBookTicketsInNewTours10()
		{
			NGReport.CreateTest("Login Test");
			Page.Home.LoadApplicationURL();
			Page.Login.LogintoNewTours("gopalakrishnanpv", "krishnaPV93");
			Page.FindFlights.FindFlights();
			Page.SelectFlight.SelectFlights();
			Page.BookFlight.BookTickets();
			NGReport.FinishTest();
		}

		[TestCase]
		public void EmployeeManagement()
		{
			DataTable masterTable = new DataTable();
			string excelFolder = "C:\\Users\\gopala.panchavarnam\\Desktop\\attendance";
			List<string> fileNames = FileHelper.GetFilesFromFolder(excelFolder);
			foreach (var fileName in fileNames)
			{
				ExcelHelper.EstablishConnection(excelFolder, fileName);
				DataTable table = ExcelHelper.ConvertExcelToDataTable();
				masterTable.Merge(table);
			}
			ExcelHelper.SetFirstRowAsColumnName(masterTable);
		}

		[OneTimeTearDown]
		public void OneTearDown()
		{
			Driver.Flush();
			NGReport.Flush();
		}
	}
}