<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LogiQ.Admin.Quizes.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Quiz Item List</h2>
    <asp:Repeater ID="rptQuiz" runat="server" SelectMethod="rptQuiz_GetData">
        <HeaderTemplate>
            <table>
                <tr>
                    <td>Title</td>
                    <td>Created Date</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href="Edit.aspx?id=<%# Eval("ID") %>"><%# Eval("Title") %></a>
                </td>
                <td>
                    <%# Eval("CreatedDate") %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
