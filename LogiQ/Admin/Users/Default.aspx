<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LogiQ.Admin.Users.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptUsers" runat="server" SelectMethod="rptUsers_GetData">
        <HeaderTemplate>
            <table>
                <tr>
                    <%--<td>ID</td>--%>
                    <td>UserName</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <%--<td><%# Eval("UserId") %></td>--%>
                <td><a href='Edit.aspx?u=<%# Eval("UserName") %>'><%# Eval("UserName") %></a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
