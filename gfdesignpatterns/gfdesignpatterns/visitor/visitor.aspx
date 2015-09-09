<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="visitor.aspx.cs" Inherits="gfdesignpatterns.visitor.visitor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <table class="table">
        <tr>
            <td class="span4 text-center">
                <h3>Convert From</h3>
                <asp:DropDownList ID="namefrom" class="btn btn-default margin" runat="server">
                    <asp:ListItem Text="A113" Value="A113"></asp:ListItem>
                    <asp:ListItem Text="Pizza Planet Trucks" Value="Pizza Planet Trucks"></asp:ListItem>
                    <asp:ListItem Text="EACs" Value="EACs"></asp:ListItem>
                    <asp:ListItem Text="Piston Cups" Value="Piston Cups"></asp:ListItem>
                    <asp:ListItem Text="BnLs" Value="BnLs"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="span4 text-center">
                <h3>Convert To</h3>
                <asp:DropDownList ID="nameto" class="btn btn-default margin" runat="server">
                    <asp:ListItem Text="A113" Value="A113"></asp:ListItem>
                    <asp:ListItem Text="Pizza Planet Trucks" Value="Pizza Planet Trucks"></asp:ListItem>
                    <asp:ListItem Text="EACs" Value="EACs"></asp:ListItem>
                    <asp:ListItem Text="Piston Cups" Value="Piston Cups"></asp:ListItem>
                    <asp:ListItem Text="BnLs" Value="BnLs"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="span4 text-center">
                <h3>How Many</h3>
                <asp:TextBox ID="pixarHowMany" runat="server" CssClass="form-control input-sm" />
                <h3></h3>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="text-center">
                <asp:Button ID="load" Text="Generate" class="btn btn-primary margin text-center " runat="server" OnClick="pixarClick" />
                <h3>
                    <asp:Label ID="results" runat="server" CssClass="center-block text-center"></asp:Label>
                </h3>
                <br />
            </td>
        </tr>
        <tr>
            <td class="span4 text-center">
                <h3>Convert From</h3>
                <asp:DropDownList ID="realList1" class="btn btn-default margin" runat="server">
                    <asp:ListItem Text="inches" Value="inches"></asp:ListItem>
                    <asp:ListItem Text="feet" Value="feet"></asp:ListItem>
                    <asp:ListItem Text="cms" Value="cms"></asp:ListItem>
                    <asp:ListItem Text="miles" Value="miles"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="span4 text-center">
                <h3>Convert To</h3>
                <asp:DropDownList ID="realList2" class="btn btn-default margin" runat="server">
                    <asp:ListItem Text="inches" Value="inches"></asp:ListItem>
                    <asp:ListItem Text="feet" Value="feet"></asp:ListItem>
                    <asp:ListItem Text="cms" Value="cms"></asp:ListItem>
                    <asp:ListItem Text="miles" Value="miles"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="span4 text-center">
                <h3>How Many</h3>
                <asp:TextBox ID="realHowMany" runat="server" CssClass="form-control input-sm" />
                <h3></h3>
            </td>
        </tr>
        <tr>
            <td colspan="3" class=" text-center">
                <asp:Button ID="realWorld" Text="Generate" class="btn btn-primary margin text-center " runat="server" OnClick="realWorld_Click" />
                <h3>
                    <asp:Label ID="realresults" runat="server" CssClass="center-block text-center"></asp:Label>

                </h3>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
