<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="pioneer._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <br />
    </p>
    <p>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1">
            <EditItemTemplate>
                FirstName:
                <asp:TextBox ID="FirstNameTextBox" runat="server" 
                    Text='<%# Bind("FirstName") %>' />
                <br />
                MiddleName:
                <asp:TextBox ID="MiddleNameTextBox" runat="server" 
                    Text='<%# Bind("MiddleName") %>' />
                <br />
                LastName:
                <asp:TextBox ID="LastNameTextBox" runat="server" 
                    Text='<%# Bind("LastName") %>' />
                <br />
                YearsExperience:
                <asp:TextBox ID="YearsExperienceTextBox" runat="server" 
                    Text='<%# Bind("YearsExperience") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
            <InsertItemTemplate>
                FirstName:
                <asp:TextBox ID="FirstNameTextBox" runat="server" 
                    Text='<%# Bind("FirstName") %>' />
                <br />
                MiddleName:
                <asp:TextBox ID="MiddleNameTextBox" runat="server" 
                    Text='<%# Bind("MiddleName") %>' />
                <br />
                LastName:
                <asp:TextBox ID="LastNameTextBox" runat="server" 
                    Text='<%# Bind("LastName") %>' />
                <br />
                YearsExperience:
                <asp:TextBox ID="YearsExperienceTextBox" runat="server" 
                    Text='<%# Bind("YearsExperience") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                FirstName:
                <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Bind("FirstName") %>' />
                <br />
                MiddleName:
                <asp:Label ID="MiddleNameLabel" runat="server" 
                    Text='<%# Bind("MiddleName") %>' />
                <br />
                LastName:
                <asp:Label ID="LastNameLabel" runat="server" Text='<%# Bind("LastName") %>' />
                <br />
                YearsExperience:
                <asp:Label ID="YearsExperienceLabel" runat="server" 
                    Text='<%# Bind("YearsExperience") %>' />
                <br />

            </ItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CandidatesConnectionString %>" 
            SelectCommand="SELECT * FROM [CANDIDATES]"></asp:SqlDataSource>
    </p>
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
    <p>
    </p>
</asp:Content>
