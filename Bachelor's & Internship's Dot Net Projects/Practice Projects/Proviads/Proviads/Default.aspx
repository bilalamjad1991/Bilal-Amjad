<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Proviads._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
    <br />
    <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" 
        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        CellSpacing="2" AutoGenerateColumns="False" DataKeyNames="EmpId" 
        DataSourceID="SqlDataSource1" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="EmpId" HeaderText="EmpId" InsertVisible="False" 
                ReadOnly="True" SortExpression="EmpId" />
            <asp:BoundField DataField="Fname" HeaderText="Fname" SortExpression="Fname" />
            <asp:BoundField DataField="Lname" HeaderText="Lname" SortExpression="Lname" />
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Employee2ConnectionString %>" 
        SelectCommand="SELECT [EmpId], [Fname], [Lname] FROM [EmpTable]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Employee2ConnectionString2 %>" 
        DeleteCommand="DELETE FROM [EmpTable] WHERE [EmpId] = @EmpId" 
        InsertCommand="INSERT INTO [EmpTable] ([Fname], [Lname], [Address], [Contact]) VALUES (@Fname, @Lname, @Address, @Contact)" 
        SelectCommand="SELECT * FROM [EmpTable]" 
        
            UpdateCommand="UPDATE [EmpTable] SET [Fname] = @Fname, [Lname] = @Lname, [Address] = @Address, [Contact] = @Contact WHERE [EmpId] = @EmpId">
        <DeleteParameters>
            <asp:Parameter Name="EmpId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Fname" Type="String" />
            <asp:Parameter Name="Lname" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="Contact" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Fname" Type="String" />
            <asp:Parameter Name="Lname" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="Contact" Type="String" />
            <asp:Parameter Name="EmpId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</p>
    <asp:DetailsView ID="DetailsView1" runat="server" BackColor="#DEBA84" 
        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        CellSpacing="2" Height="50px" Width="125px" AutoGenerateRows="False" 
        DataKeyNames="EmpId" DataSourceID="SqlDataSource1" 
        onitemdeleted="DetailsView1_ItemDeleted" 
        oniteminserted="DetailsView1_ItemInserted" 
        onitemupdated="DetailsView1_ItemUpdated">
        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:BoundField DataField="EmpId" HeaderText="EmpId" InsertVisible="False" 
                ReadOnly="True" SortExpression="EmpId" />
            <asp:BoundField DataField="Fname" HeaderText="Fname" SortExpression="Fname" />
            <asp:BoundField DataField="Lname" HeaderText="Lname" SortExpression="Lname" />
            <asp:BoundField DataField="Address" HeaderText="Address" 
                SortExpression="Address" />
            <asp:BoundField DataField="Contact" HeaderText="Contact" 
                SortExpression="Contact" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                ShowInsertButton="True" />
        </Fields>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
    </asp:DetailsView>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
</asp:Content>
