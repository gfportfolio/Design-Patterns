<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ObserverDemo.aspx.cs" Inherits="gfdesignpatterns.observer.ObserverDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="observers" class="col-md-6">
        <h1>Show Times</h1>
        <h3>Screen 1</h3>
        <h4><asp:Label ID="observer1lb" runat="server"></asp:Label></h4>
        <h3>Screen 2</h3>
        <h4><asp:Label ID="observer2lb" runat="server"></asp:Label></h4>
    </div>
    <div id="control " class="col-md-6 btn-group-vertical">
        <asp:Button ID="addCinderella" Text="Add Cinderella" class="btn btn-warning margin pull-left" runat="server" OnClick="addCinderella_Click" /><br />
        <asp:Button ID="addFrozen" Text="Add Frozen" class="btn btn-warning margin pull-left" runat="server" OnClick="addFrozen_Click" /><br />
        <asp:Button ID="startWreckItRalf" Text="Start Wreck It Ralf" class="btn btn-warning margin pull-left" runat="server" OnClick="startWreckItRalf_Click" /><br />
        <asp:Button ID="startFrozen" Text="Start Frozen" class="btn btn-warning margin pull-left" runat="server" OnClick="startFrozen_Click" /><br />
        <asp:Button ID="startInsideOut" Text="Start Inside Out" class="btn btn-warning margin pull-left" runat="server" OnClick="startInsideOut_Click" /><br />
        <asp:Button ID="endFrozen" Text="End Frozen" class="btn btn-warning margin pull-left" runat="server" OnClick="endFrozen_Click" /><br />
        <asp:Button ID="turnOffScreen2" Text="Turn Off Screen 2" class="btn btn-warning margin pull-left" runat="server" OnClick="turnOffScreen2_Click" /><br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
