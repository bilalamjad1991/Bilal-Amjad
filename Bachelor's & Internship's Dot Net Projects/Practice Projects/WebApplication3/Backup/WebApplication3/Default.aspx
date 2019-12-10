<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ItemName" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ItemName" HeaderText="ItemName" ReadOnly="True" 
                    SortExpression="ItemName" />
                <asp:BoundField DataField="Salt" HeaderText="Salt" SortExpression="Salt" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" 
                    SortExpression="CompanyName" />
                <asp:BoundField DataField="MfgDate" HeaderText="MfgDate" 
                    SortExpression="MfgDate" />
                <asp:BoundField DataField="ExpDate" HeaderText="ExpDate" 
                    SortExpression="ExpDate" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConflictDetection="CompareAllValues" 
            ConnectionString="<%$ ConnectionStrings:MedicinesConnectionString2 %>" 
            DeleteCommand="DELETE FROM [MedTable] WHERE [ItemName] = @original_ItemName AND [Salt] = @original_Salt AND [CompanyName] = @original_CompanyName AND [MfgDate] = @original_MfgDate AND [ExpDate] = @original_ExpDate" 
            InsertCommand="INSERT INTO [MedTable] ([ItemName], [Salt], [CompanyName], [MfgDate], [ExpDate]) VALUES (@ItemName, @Salt, @CompanyName, @MfgDate, @ExpDate)" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT * FROM [MedTable]" 
            UpdateCommand="UPDATE [MedTable] SET [Salt] = @Salt, [CompanyName] = @CompanyName, [MfgDate] = @MfgDate, [ExpDate] = @ExpDate WHERE [ItemName] = @original_ItemName AND [Salt] = @original_Salt AND [CompanyName] = @original_CompanyName AND [MfgDate] = @original_MfgDate AND [ExpDate] = @original_ExpDate">
            <DeleteParameters>
                <asp:Parameter Name="original_ItemName" Type="String" />
                <asp:Parameter Name="original_Salt" Type="String" />
                <asp:Parameter Name="original_CompanyName" Type="String" />
                <asp:Parameter Name="original_MfgDate" Type="String" />
                <asp:Parameter Name="original_ExpDate" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ItemName" Type="String" />
                <asp:Parameter Name="Salt" Type="String" />
                <asp:Parameter Name="CompanyName" Type="String" />
                <asp:Parameter Name="MfgDate" Type="String" />
                <asp:Parameter Name="ExpDate" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Salt" Type="String" />
                <asp:Parameter Name="CompanyName" Type="String" />
                <asp:Parameter Name="MfgDate" Type="String" />
                <asp:Parameter Name="ExpDate" Type="String" />
                <asp:Parameter Name="original_ItemName" Type="String" />
                <asp:Parameter Name="original_Salt" Type="String" />
                <asp:Parameter Name="original_CompanyName" Type="String" />
                <asp:Parameter Name="original_MfgDate" Type="String" />
                <asp:Parameter Name="original_ExpDate" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
