<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPass.aspx.cs" Inherits="Login_Module.EditPass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


h2
{
    font-size: 1.5em;
    font-weight: 600;
}

h1, h2, h3, h4, h5, h6
{
    font-size: 1.5em;
    color: #666666;
    font-variant: small-caps;
    text-transform: none;
    font-weight: 200;
    margin-bottom: 0px;
}

p
{
    margin-bottom: 10px;
    line-height: 1.6em;
}


    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h2>
        &nbsp;</h2>
        <p>
            <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="UserName" runat="server" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
    </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Contact"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="E-mail"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </p>
        <p>
            <asp:Label ID="Success" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Height="26px" onclick="Button1_Click" 
                Text="Edit" Width="70px" />
    </p>
    
    </div>
    </form>
</body>
</html>
