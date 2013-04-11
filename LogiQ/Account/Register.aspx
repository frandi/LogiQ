<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LogiQ.Account.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="validSummary" runat="server" DisplayMode="List" ValidationGroup="register" />
    <fieldset>
        <legend>Register</legend>
        <dl>
            <dt>Username</dt>
            <dd>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" Display="Dynamic"
                    Text="*" ErrorMessage="Username cannot empty" ValidationGroup="register"></asp:RequiredFieldValidator>
            </dd>
        </dl>
        <dl>
            <dt>Email</dt>
            <dd>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="efvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                    Text="*" ErrorMessage="Email cannot empty" ValidationGroup="register"></asp:RequiredFieldValidator>
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
            <dt>Confirm Password</dt>
            <dd>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                    Display="Dynamic" Text="*" ErrorMessage="Password must match" ValidationGroup="register"></asp:CompareValidator>
            </dd>
        </dl>
        <dl>
            <dt></dt>
            <dd>
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" ValidationGroup="register" />
            </dd>
        </dl>
    </fieldset>
</asp:Content>
