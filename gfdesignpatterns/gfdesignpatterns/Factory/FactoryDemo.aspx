<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="FactoryDemo.aspx.cs" Inherits="gfdesignpatterns.Factory.FactoryDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h1>The Factory</h1>
    <asp:DropDownList ID="selectType" class="btn btn-default margin" runat="server">
        <asp:ListItem Text="Short" Value="0"></asp:ListItem>
        <asp:ListItem Text="Movie" Value="1"></asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Button ID="load" Text="Generate" class="btn btn-success margin" runat="server" OnClick="load_Click" />
    <br />
    <br />
    <br />
    <h3>
        <asp:Label ID="lbltitle" runat="server"></asp:Label>


    </h3>
    <h2>
        <asp:Label ID="lblname" runat="server"></asp:Label>
        <br />
    </h2>
    <h3>
        <asp:Label ID="lblyear" runat="server"></asp:Label>
    </h3>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
