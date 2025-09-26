<%@ Page Title="Đăng nhập" Language="C#" AutoEventWireup="true"
    MasterPageFile="~/MasterPageUser.Master"
    CodeBehind="Login.aspx.cs" Inherits="QUANLYBANHANG.Login" %>

<asp:Content ID="c1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="border_box" style="max-width:400px;padding:16px">
    <h2>Đăng nhập</h2>

    <asp:ValidationSummary ID="vs" runat="server" CssClass="error" />

    <div>Tài khoản</div>
    <asp:TextBox ID="txtUser" runat="server" CssClass="newsletter_input" />

    <div style="margin-top:8px">Mật khẩu</div>
    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="newsletter_input" />

    <div style="margin-top:12px">
      <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />
    </div>

    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
  </div>
</asp:Content>
