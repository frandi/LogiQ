<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="LogiQ.Admin.Users.Role" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <asp:DataGrid ID="dgRole" runat="server" AutoGenerateColumns="false" DataKeyField="RoleId"
        OnEditCommand="dgRole_EditCommand" OnCancelCommand="dgRole_CancelCommand"
        OnUpdateCommand="dgRole_UpdateCommand" OnDeleteCommand="dgRole_DeleteCommand">
        <Columns>
            <asp:BoundColumn DataField="RoleName" HeaderText="Role"></asp:BoundColumn>
            <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update"></asp:EditCommandColumn>
            <asp:ButtonColumn CommandName="Delete" Text="Delete"></asp:ButtonColumn>
        </Columns>
    </asp:DataGrid>
    <table>
        <tr>
            <td>Add new role :</td>
            <td>
                <asp:TextBox ID="txtNewRole" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewRole" runat="server" ControlToValidate="txtNewRole"
                    Display="Dynamic" Text="*" ValidationGroup="newRole"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="newRole" />
            </td>
        </tr>
    </table>
</asp:Content>
