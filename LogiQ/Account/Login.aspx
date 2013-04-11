<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LogiQ.Account.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="validSummary" runat="server" DisplayMode="List" ValidationGroup="login" />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <fieldset>
        <legend>Login</legend>
        <dl>
            <dt>Username</dt>
            <dd>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" Display="Dynamic"
                    Text="*" ErrorMessage="Username cannot empty" ValidationGroup="register"></asp:RequiredFieldValidator>
            </dd>
        </dl>
        <dl>
            <dt>Password</dt>
            <dd>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic"
                    Text="*" ErrorMessage="Password cannot empty" ValidationGroup="register"></asp:RequiredFieldValidator>
            </dd>
        </dl>
        <dl>
            <dt></dt>
            <dd>
                <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember Me" />
            </dd>
        </dl>
        <dl>
            <dt></dt>
            <dd>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" ValidationGroup="login" />
            </dd>
        </dl>
    </fieldset>
    <p>Need account? <a href="~/Account/Register" runat="server">Register</a></p>
</asp:Content>
