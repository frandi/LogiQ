<%@ Page Title="Admin: User List" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LogiQ.Admin.Users.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>User List</h2>
    <asp:Repeater ID="rptUsers" runat="server" SelectMethod="rptUsers_GetData">
        <HeaderTemplate>
            <table>
                <tr>
                    <%--<td>ID</td>--%>
                    <td>Full Name</td>
                    <td>UserName</td>
                    <td>Email</td>
                    <td>Roles</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <%--<td><%# Eval("UserId") %></td>--%>
                <td><%# Eval("FullName") %></td>
                <td><a href='Edit.aspx?u=<%# Eval("UserName") %>'><%# Eval("UserName") %></a></td>
                <td><%# Eval("Email") %></td>
                <td><%# Eval("Roles") != null ? string.Join(", ", Eval("Roles") as string[]) : "" %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
