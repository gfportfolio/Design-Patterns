<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="SingletonDemo.aspx.cs" Inherits="gfdesignpatterns.singleton.SingletonDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="manualGLAndProductionInputControls" ng-app="main" ng-controller="Ctrl">
        <div style="float: left; width: 50%">
            <h1>Movies</h1>
            <asp:Button runat="server" OnClick="carsClick" class="btn btn-success" Text="Add Cars to the List" />
            <div ng-repeat="movie in moviedata">
                <h3>{{movie.name}}: {{movie.year}}</h3>
            </div>
        </div>
        <div style="float: left; width: 50%">

            <h1>Shorts</h1>
            <asp:Button runat="server" OnClick="birdsClick" class="btn btn-success" Text="Add for the birds to the List" />
            <div ng-repeat="short in shortdata">
                <h3>{{short.name}}: {{short.year}}</h3>
            </div>
        </div>
    </div>
    <div style="clear: both"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script type="text/javascript">

        var movies = <%=JsonMovieData%>;
        var short = <%=JsonShortsData%>;

        var app = angular.module('main', [])
        .controller('Ctrl', function ($scope, $http)
        {
            $scope.moviedata = movies;
            $scope.shortdata = short;
        });
    </script>
</asp:Content>
