<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Testcase.aspx.cs" Inherits="ReportNG.Models.Testcase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="summary">
		<h3 class="header">TESTCASE SUMMARY</h3>
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
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="TESTCASEID" DataSourceID="TestCaseDetails" CssClass="text-center" OnRowDataBound="GridView1_OnRowDataBound" OnRowCommand="GridView1_OnRowCommand" OnDataBound="OnDataBound">
			<Columns>
				<asp:BoundField DataField="TESTCASEID" HeaderText="TESTCASEID" SortExpression="TESTCASEID" ItemStyle-Width="10%" />
				<asp:BoundField DataField="TESTNAME" HeaderText="TESTNAME" SortExpression="TESTNAME" ItemStyle-Width="40%" />
				<asp:BoundField DataField="RESULT" HeaderText="RESULT" SortExpression="RESULT" ItemStyle-Width="10%" />
				<asp:BoundField DataField="DURATION" HeaderText="DURATION (IN SEC)" SortExpression="DURATION" ItemStyle-Width="10%" />

				<asp:TemplateField HeaderText="DETAILS" ItemStyle-Width="20%">
					<ItemTemplate>
						<asp:Button ID="ViewDetails" runat="server" CausesValidation="false" CommandName="ViewDetails" CssClass="btn btn-primary"
							Text="VIEW TESTSTEPS" CommandArgument='<%# Eval("TESTCASEID") %>' />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
	</div>
	<asp:SqlDataSource ID="TestCaseDetails" runat="server" ConnectionString="<%$ ConnectionStrings:AUTOMATIONConnectionString %>" SelectCommand="SELECT * FROM [tblTestCaseDetails] WHERE ([BUILDID] = @BUILDID)">
		<SelectParameters>
			<asp:QueryStringParameter Name="BUILDID" QueryStringField="buildId" Type="Int32" />
		</SelectParameters>
	</asp:SqlDataSource>
</asp:Content>
