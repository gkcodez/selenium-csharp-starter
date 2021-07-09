<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ReportNG.Models.Index" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="summary">
		<h3 class="header">BUILD SUMMARY</h3>
		<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="BuildSummary" CellPadding="4" CssClass="text-center test">
			<Columns>
				<asp:BoundField DataField="TOTALCOUNT" HeaderText="TOTAL" SortExpression="TOTAL" />
				<asp:BoundField DataField="PASSEDCOUNT" HeaderText="PASSED" SortExpression="PASSED" />
				<asp:BoundField DataField="FAILEDCOUNT" HeaderText="FAILED" SortExpression="FAILED" />
			</Columns>
		</asp:GridView>
	</div>
	<div class="details">
		<h3 class="header">BUILD DETAILS</h3>
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="BUILDID" DataSourceID="BuildDetails" OnRowDataBound="GridView1_OnRowDataBound" OnRowCommand="GridView1_OnRowCommand" OnDataBound="OnDataBound" CssClass="text-center">
			<Columns>
				<asp:BoundField DataField="BUILDID" HeaderText="BUILDID" SortExpression="BUILDID" ItemStyle-Width="10%" />
				<asp:BoundField DataField="EXECUTEDBY" HeaderText="EXECUTED BY" SortExpression="EXECUTEDBY" ItemStyle-Width="20%" />
				<asp:BoundField DataField="EXECUTIONDATE" HeaderText="EXECUTION DATE" SortExpression="EXECUTIONDATE" ItemStyle-Width="15%" />
				<asp:BoundField DataField="EXECUTIONTIME" HeaderText="EXECUTION TIME" SortExpression="EXECUTIONTIME" ItemStyle-Width="15%" />
				<asp:BoundField DataField="RESULT" HeaderText="RESULT" SortExpression="RESULT" ItemStyle-Width="10%" />
				<asp:BoundField DataField="DURATION" HeaderText="DURATION (IN SEC)" SortExpression="DURATION" ItemStyle-Width="10%" />

				<asp:TemplateField HeaderText="DETAILS" ItemStyle-Width="20%">
					<ItemTemplate>
						<asp:Button ID="ViewDetails" runat="server" CausesValidation="false" CommandName="ViewDetails" CssClass="btn btn-primary"
							Text="VIEW TESTCASES" CommandArgument='<%# Eval("BUILDID") %>' />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
	</div>
	<asp:SqlDataSource ID="BuildSummary" runat="server" ConnectionString="<%$ ConnectionStrings:AUTOMATIONConnectionString %>" SelectCommand="SELECT * FROM [tblBuildSummary]"></asp:SqlDataSource>
	<asp:SqlDataSource ID="BuildDetails" runat="server" ConnectionString="<%$ ConnectionStrings:AUTOMATIONConnectionString %>" SelectCommand="SELECT * FROM [tblBuildDetails]"></asp:SqlDataSource>
</asp:Content>