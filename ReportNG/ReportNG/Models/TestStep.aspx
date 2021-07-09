<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TestStep.aspx.cs" Inherits="ReportNG.Models.TestStep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="summary">
		<h3 class="header">TESTSTEP SUMMARY</h3>
		<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="text-center test">
			<Columns>
				<asp:BoundField DataField="TOTAL" HeaderText="TOTAL" SortExpression="TOTAL" />
				<asp:BoundField DataField="PASSED" HeaderText="PASSED" SortExpression="PASSED" />
				<asp:BoundField DataField="FAILED" HeaderText="FAILED" SortExpression="FAILED" />
			</Columns>
		</asp:GridView>
	</div>
	<div class="details">
		<h3 class="header">TESTSTEP DETAILS</h3>
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="TESTSTEPID" DataSourceID="TestStepDetails" CssClass="text-center" OnRowDataBound="GridView1_OnRowDataBound" OnDataBound="OnDataBound">
			<Columns>
				<asp:BoundField DataField="TESTSTEPID" HeaderText="TESTSTEPID" SortExpression="TESTSTEPID" ItemStyle-Width="5%" />
				<asp:BoundField DataField="APPNAME" HeaderText="APPNAME" SortExpression="APPNAME" ItemStyle-Width="10%" />
				<asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" SortExpression="DESCRIPTION" ItemStyle-Width="35%" />
				<asp:BoundField DataField="RESULT" HeaderText="RESULT" SortExpression="RESULT" ItemStyle-Width="5%" />
				<asp:BoundField DataField="SCREENSHOT" HeaderText="SCREENSHOT" SortExpression="SCREENSHOT" ItemStyle-Width="15%" />
				<asp:BoundField DataField="EXCEPTION" HeaderText="EXCEPTION" SortExpression="EXCEPTION" ItemStyle-Width="20%" />
			</Columns>
		</asp:GridView>
	</div>
	<asp:SqlDataSource ID="TestStepDetails" runat="server" ConnectionString="<%$ ConnectionStrings:AUTOMATIONConnectionString %>" SelectCommand="SELECT * FROM [tblTestStepDetails] WHERE ([TESTCASEID] = @TESTCASEID)">
		<SelectParameters>
			<asp:QueryStringParameter Name="TESTCASEID" QueryStringField="testCaseId" Type="Int32" />
		</SelectParameters>
	</asp:SqlDataSource>
</asp:Content>