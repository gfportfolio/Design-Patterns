<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="SingletonDemo.aspx.cs" Inherits="gfdesignpatterns.singleton.SingletonDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
        <asp:Button  runat="server" OnClick="carsClick" class="btn btn-success" text="Add Cars to the List"/>
    <asp:Button  runat="server" OnClick="birdsClick" class="btn btn-success" text="Add for the birds to the List"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
