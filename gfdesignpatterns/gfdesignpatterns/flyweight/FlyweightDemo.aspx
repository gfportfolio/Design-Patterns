<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="FlyweightDemo.aspx.cs" Inherits="gfdesignpatterns.flyweight.FlyweightDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h4>Fight the evil enemy and win the game.  Choose who to send to battle.
    <br />
    The computer will choose a evil enemy who you will battle.</h4>
    <div class="btn-group btn-group-justified">
        <div class="btn-group" role="group">
            <asp:Button ID="Button0" runat="server" OnClick="playerButton_Click" class="btn btn-success" Text="Attacker 1" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button ID="Button1" runat="server" OnClick="playerButton_Click" class="btn btn-success" Text="Attacker 2" />

        </div>
        <div class="btn-group" role="group">
            <asp:Button ID="Button2" runat="server" OnClick="playerButton_Click" class="btn btn-success" Text="Attacker 3" />

        </div>
        <div class="btn-group" role="group">
            <asp:Button ID="Button3" runat="server" OnClick="playerButton_Click" class="btn btn-success" Text="Attacker 4" />

        </div>
        <div class="btn-group" role="group">
            <asp:Button ID="Button4" runat="server" OnClick="playerButton_Click" class="btn btn-success" Text="Attacker 5" />

        </div>
    </div>
    <div id="manualGLAndProductionInputControls" ng-app="main" ng-controller="Ctrl">
        <div style="float: left; width: 50%">
            <h1>Good</h1>
            <div ng-repeat="player in goodPlayers">
                <h3>
              
                    <img ng-src="{{player.image}}" class="flighweight_image_small img-circle" />
                    {{player.name}}: Life {{player.life}} :Strength {{player.strength}}</h3>
            </div>
        </div>
        <div style="float: left; width: 50%">

            <h1>Evil</h1>
            <div ng-repeat="player in badPlayers">
                <h3>
                    <img ng-src="{{player.image}}" class="flighweight_image_small img-circle" />
                    {{player.name}}: Life {{player.life}} :Strength {{player.strength}}</h3>
            </div>
        </div>
    </div>
    <div style="clear: both"></div>
   <h3><asp:Label ID="log" runat="server"></asp:Label></h3> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script type="text/javascript">

        var good = <%=JsonGoodPlayers%>;
        var bad = <%=JsonBadPlayers%>;

        var app = angular.module('main', [])
        .controller('Ctrl', function ($scope, $http)
        {
            $scope.goodPlayers = good;
            $scope.badPlayers = bad;
        });
    </script>
</asp:Content>
