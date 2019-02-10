<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LightBulbs._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:1920px;height:1080px;overflow:auto;">
        <asp:Table ID="Results" runat="server" BorderStyle="Solid"></asp:Table>
    </div>
    <div>
        After the 100th person has left the room, a total of 10 bulbs are on. 
        <p>They are 1, 4, 9, 16, 25, 36, 49, 64, 81 and 100. There are a total of 10 square numbers between 1 and 100</p> 
        <p>Each of the above bulbs are not switchable by any other bulb in the sequence, hence that is why they remain on.</p>
    </div>
</asp:Content>

