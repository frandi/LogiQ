<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="LogiQ.Admin.Quizes.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <fieldset>
        <legend>Edit Quiz Item</legend>
        <dl>
            <dt>Title</dt>
            <dd>
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>Question</dt>
            <dd>
                <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Rows="6"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt>Right Answer</dt>
            <dd>
                <asp:TextBox ID="txtRightAnswer" runat="server"></asp:TextBox>
            </dd>
        </dl>
        <dl>
            <dt></dt>
            <dd>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </dd>
        </dl>
    </fieldset>
    <p><a href="Default.aspx">Back to Quiz Item List</a></p>
</asp:Content>
