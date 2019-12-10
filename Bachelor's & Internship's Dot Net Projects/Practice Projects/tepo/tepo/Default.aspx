<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="tepo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1" 
        AllowPaging="True" CellPadding="4" ForeColor="#333333" 
        onpageindexchanging="FormView1_PageIndexChanging">
        <EditItemTemplate>
            Fname:
            <asp:TextBox ID="FnameTextBox" runat="server" Text='<%# Bind("Fname") %>' />
            <br />
            Lname:
            <asp:TextBox ID="LnameTextBox" runat="server" Text='<%# Bind("Lname") %>' />
            <br />
            SID:
            <asp:TextBox ID="SIDTextBox" runat="server" Text='<%# Bind("SID") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <InsertItemTemplate>
            Fname:
            <asp:TextBox ID="FnameTextBox" runat="server" Text='<%# Bind("Fname") %>' />
            <br />
            Lname:
            <asp:TextBox ID="LnameTextBox" runat="server" Text='<%# Bind("Lname") %>' />
            <br />
            SID:
            <asp:TextBox ID="SIDTextBox" runat="server" Text='<%# Bind("SID") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            Fname:
            <asp:Label ID="FnameLabel" runat="server" Text='<%# Bind("Fname") %>' />
            <br />
            Lname:
            <asp:Label ID="LnameLabel" runat="server" Text='<%# Bind("Lname") %>' />
            <br />
            SID:
            <asp:Label ID="SIDLabel" runat="server" Text='<%# Bind("SID") %>' />
            <br />

        </ItemTemplate>
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
</asp:FormView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:StudentConnectionString %>" 
    SelectCommand="SELECT * FROM [Sinfo]" onselecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
