<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="Lab_25_ASP_First_Website.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="Label1" runat="server" Text="Label">This is a Label</asp:Label>
    <h1>Hello World</h1>
    <ul>
        <li>One</li>
        <li>Two</li>
    </ul>
    
    <asp:TextBox ID="TextBox1" runat="server">This is a Text Box</asp:TextBox>

    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

    <form method="get" action="processdata.cs">
        First Name <input type="text" placeholder="type here" name="firstname" />
        <button type="submit">Submit</button>

    </form>

</asp:Content>
