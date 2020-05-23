<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Anders_Scoreboard_Challenge._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <center>
        <h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Anders Scoreboard Challenge</h2>
        <p class="lead">&nbsp;</p>
        
        <p class="lead">Name:&nbsp; <asp:TextBox ID="txtName" runat="server" Width="142px"></asp:TextBox>
&nbsp;&nbsp; Score:&nbsp; <asp:TextBox ID="txtScore" runat="server" Width="142px"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="btnAddScore" runat="server" OnClick="Button1_Click" Text="Add Score" Width="127px" />
        </p>
        <p class="lead">High Score:&nbsp; <asp:TextBox ID="txtHighScore" runat="server" BackColor="#CCCCCC" ReadOnly="True" Width="142px"></asp:TextBox>
        </p>
        <p class="lead">&nbsp;</p>
        <p>
           
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowSorting="true" OnSorting="GridView1_Sorting" Height="73px"  Width="121px">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
          
        </p>
        <p>&nbsp;</p>
        </center>
    </div>

    <div class="row">
        <div class="col-md-4">
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
            <h2>&nbsp;</h2>
            <p>
                &nbsp;</p>
        </div>
        <div class="col-md-4">
            <h2>&nbsp;</h2>
            <p>
                &nbsp;</p>
        </div>
    </div>

</asp:Content>
