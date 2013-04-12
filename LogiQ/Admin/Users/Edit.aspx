<%@ Page Title="Admin: Edit User" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="LogiQ.Admin.Users.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <fieldset>
        <legend><asp:Label ID="lblTitle" runat="server" Text="New User"></asp:Label></legend>
        <dl id="dlUserId" runat="server" visible="false">
            <dt>User ID</dt>
            <dd>
                <asp:Label ID="lblUserId" runat="server"></asp:Label>
            </dd>
        </dl>
        <dl>
            <dt>Username</dt>
            <dd>
                <asp:TextBox ID="txtUsername" runat="server" ReadOnly='<%# dlUserId.Visible %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" Display="Dynamic"
                    Text="*" ErrorMessage="Username cannot empty" ValidationGroup="EditUser"></asp:RequiredFieldValidator>
            </dd>
        </dl>
        <dl>
            <dt>First Name</dt>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        </dl>
        <dl>
            <dt>Last Name</dt>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        </dl>
        <dl>
            <dt>Email</dt>
            <dd>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                    Text="*" ErrorMessage="Email cannot empty" ValidationGroup="EditUser"></asp:RequiredFieldValidator>
            </dd>
        </dl>
        <dl>
            <dt>Phone</dt>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </dl>
        <dl id="dlPassword" runat="server" visible='<%# !dlUserId.Visible %>'>
            <dt>Password</dt>
            <dd>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic"
                    Text="*" ErrorMessage="Password cannot empty" ValidationGroup="EditUser" Enabled='<%# dlPassword.Visible %>'></asp:RequiredFieldValidator>
            </dd>
        </dl>
        <dl id="dlConfirmPassword" runat="server" visible='<%# !dlUserId.Visible %>'>
            <dt>Confirm Password</dt>
            <dd>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                    Display="Dynamic" Text="*" ErrorMessage="Password must match" ValidationGroup="EditUser" Enabled='<%# dlConfirmPassword.Visible %>'></asp:CompareValidator>
            </dd>
        </dl>
        <dl>
            <dt>Roles</dt>
            <dd><asp:CheckBoxList ID="chkRoles" runat="server"></asp:CheckBoxList>
                <%--<asp:Repeater ID="rptRoles" runat="server" SelectMethod="rptRoles_GetData">
                    <HeaderTemplate><ul></HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:CheckBox ID="chkRole" runat="server" Text='<%# Eval("Role") %>' Checked='<%# Eval("IsUserInRole") %>' />
                        </li>
                    </ItemTemplate>
                    <FooterTemplate></ul></FooterTemplate>
                </asp:Repeater>--%>
            </dd>
        </dl>
        <dl>
            <dt></dt>
            <dd>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="EditUser" />
            </dd>
        </dl>
    </fieldset>
    <p><a href="~/Admin/Users" runat="server">Back to User List</a></p>
</asp:Content>
