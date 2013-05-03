<%@ Page Title="Admin: Edit User" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="LogiQ.Admin.Users.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <section class="tabs">
        <ul class="tab-nav">
            <li class="active"><a href="#">Edit Profile</a></li>
            <li runat="server" visible='<%# dlUserId.Visible %>'><a href="#">Change Password</a></li>
        </ul>
        <div class="tab-content active">
            <fieldset>
                <legend><asp:Label ID="lblTitle" runat="server" Text="New User"></asp:Label></legend>
                <ul>
                    <li id="dlUserId" runat="server" class="field" visible="false">
                        <label>User ID</label>
                        <asp:Label ID="lblUserId" runat="server"></asp:Label>
                    </li>
                    <li class="field">
                        <asp:Label ID="lblForUsername" runat="server" Text="Username" AssociatedControlID="txtUsername"></asp:Label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="input text wide" ReadOnly='<%# dlUserId.Visible %>' Enabled='<%# !dlUserId.Visible %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" Display="Dynamic"
                            Text="*" ErrorMessage="Username cannot empty" ValidationGroup="EditUser"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="lblForFirstName" runat="server" Text="First Name" AssociatedControlID="txtFirstName"></asp:Label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="input text wide"></asp:TextBox>
                    </li>
                    <li class="field">
                        <asp:Label ID="lblForLastName" runat="server" Text="Last Name" AssociatedControlID="txtLastName"></asp:Label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="input text wide"></asp:TextBox>
                    </li>
                    <li class="field">
                        <asp:Label ID="lblForEmail" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="input email wide"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic"
                            Text="*" ErrorMessage="Email cannot empty" ValidationGroup="EditUser"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="lblForPhone" runat="server" Text="Phone" AssociatedControlID="txtPhone"></asp:Label>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="input phone wide"></asp:TextBox>
                    </li>
                    <li id="dlPassword" runat="server" class="field" visible='<%# !dlUserId.Visible %>'>
                        <asp:Label ID="lblForPassword" runat="server" Text="Password" AssociatedControlID="txtPassword"></asp:Label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input password wide"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic"
                            Text="*" ErrorMessage="Password cannot empty" ValidationGroup="EditUser" Enabled='<%# dlPassword.Visible %>'></asp:RequiredFieldValidator>
                    </li>
                    <li id="dlConfirmPassword" runat="server" class="field" visible='<%# !dlUserId.Visible %>'>
                        <asp:Label ID="lblForConfirmPassword" runat="server" Text="Confirm Password" AssociatedControlID="txtConfirmPassword"></asp:Label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="input password wide"></asp:TextBox>
                        <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                            Display="Dynamic" Text="*" ErrorMessage="Password must match" ValidationGroup="EditUser" Enabled='<%# dlConfirmPassword.Visible %>'></asp:CompareValidator>
                    </li>
                    <li>
                        <asp:Label ID="lblForRoles" runat="server" Text="Roles" AssociatedControlID="chkRoles"></asp:Label>
                        <asp:CheckBoxList ID="chkRoles" runat="server" CssClass="checkbox"></asp:CheckBoxList>
                    </li>
                    <li>
                        <label></label>
                        <div class="btn primary medium">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="EditUser" />
                        </div>
                    </li>
                </ul>
            </fieldset>
        </div>
        <div class="tab-content">
            <fieldset>
                <legend>Change Password</legend>
                <ul>
                    <li class="field">
                        <asp:Label ID="lblForOldPassword" runat="server" Text="Old Password" AssociatedControlID="txtOldPassword"></asp:Label>
                        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" CssClass="input password wide"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword" Display="Dynamic"
                            Text="*" ErrorMessage="Old Password cannot empty" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="lblForNewPassword" runat="server" Text="New Password" AssociatedControlID="txtNewPassword"></asp:Label>
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="input password wide"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword" Display="Dynamic"
                            Text="*" ErrorMessage="New Password cannot empty" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="lblForConfirmNewPassword" runat="server" Text="Confirm Password" AssociatedControlID="txtConfirmNewPassword"></asp:Label>
                        <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" CssClass="input password wide"></asp:TextBox>
                        <asp:CompareValidator ID="cvConfirmNewPassword" runat="server" ControlToValidate="txtConfirmNewPassword" ControlToCompare="txtNewPassword"
                            Display="Dynamic" Text="*" ErrorMessage="New Password must match" ValidationGroup="ChangePassword"></asp:CompareValidator>
                    </li>
                    <li>
                        <label></label>
                        <div class="btn primary medium">
                            <asp:Button ID="btnSavePassword" runat="server" Text="Save Password" OnClick="btnSavePassword_Click" ValidationGroup="ChangePassword" />
                        </div>
                    </li>
                </ul>
            </fieldset>
        </div>
    </section>
    <p><a href="~/Admin/Users" runat="server">Back to User List</a></p>
</asp:Content>
