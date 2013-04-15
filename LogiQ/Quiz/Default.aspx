<%@ Page Title="Quiz Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LogiQ.Quiz.Default" %>
<%@ Import Namespace="LogiQ.Helpers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Quiz Dashoard</h2>
    <asp:Panel ID="pnlQuizFilter" runat="server">
        Filter: 
        <asp:DropDownList ID="ddlQuizFilter" runat="server">
            <asp:ListItem Value="all">All Items</asp:ListItem>
            <asp:ListItem Value="unvisited">Unvisited Items only</asp:ListItem>
            <asp:ListItem Value="visited">Visited Items only</asp:ListItem>
        </asp:DropDownList>
    </asp:Panel>
    <asp:Repeater ID="rptQuiz" runat="server" SelectMethod="rptQuiz_GetData">
        <HeaderTemplate><ul></HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href="Item.aspx?id=<%# Eval("QuizId") %>" class="<%# Eval("Visited").ToString().ToBoolean() ? "visited" : "unvisited" %>">
                    <%# Eval("Question") %>
                </a>
            </li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
</asp:Content>
