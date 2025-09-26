<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pageGIOHANG.aspx.cs"
    Inherits="QUANLYBANHANG.pageGIOHANG" MasterPageFile="~/MasterPageUser.Master" %>

<asp:Content ID="c1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False"
      DataKeyNames="MASANPHAM"
      OnRowCommand="gvCart_RowCommand">
    <Columns>
      <asp:BoundField DataField="MASANPHAM" HeaderText="Mã" />
      <asp:BoundField DataField="TENSANPHAM" HeaderText="Tên s&#7843;n ph&#7849;m" />
      <asp:ImageField DataImageUrlField="HINHANH" HeaderText="&#7842;nh"
          DataImageUrlFormatString="images/{0}" ControlStyle-Width="80" ControlStyle-Height="80" />
      <asp:BoundField DataField="DONGIA" HeaderText="&#272;&#417;n giá" DataFormatString="{0:N0}" />
      <asp:BoundField DataField="SOLUONG" HeaderText="SL" />
      <asp:BoundField DataField="THANHTIEN" HeaderText="Thành ti&#7873;n" DataFormatString="{0:N0}" />

      <asp:TemplateField HeaderText="Thao tác">
        <ItemTemplate>
          <asp:LinkButton ID="btnReturn" runat="server" CommandName="Return"
              CommandArgument='<%# Eval("MASANPHAM") %>' Text="Tr&#7843; 1" />
          &nbsp;|&nbsp;
          <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove"
              CommandArgument='<%# Eval("MASANPHAM") %>' Text="Xóa" />
        </ItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>

  <div style="margin-top:10px">
    <strong>T&#7893;ng ti&#7873;n: </strong><asp:Label ID="lblTotal" runat="server" />
  </div>
</asp:Content>
