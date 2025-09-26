<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="CHITIETSANPHAM.aspx.cs" Inherits="QUANLYBANHANG.CHITIETSANPHAM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Repeater ID="rptDetail" runat="server"
              OnItemCommand="rptDetail_ItemCommand">
  <ItemTemplate>
    <div class="prod_box">
      <div class="top_prod_box"></div>
      <div class="center_prod_box">
        <div class="product_title">
          <a runat="server"><%# Eval("TENSANPHAM") %></a>
        </div>
        <div class="product_img">
          <a runat="server">
            <img src='images/<%# Eval("HINHANH") %>' alt="" border="0" width="100" height="100" />
          </a>
        </div>
        <div class="prod_price">
          <span class="reduce">&#272;&#416;N GIÁ</span>
          <span class="price"><%# Eval("DONGIA") %></span>
        </div>
      </div>
      <div class="bottom_prod_box"></div>
              <div class="prod_details_tab">
            S&#7889; l&#432;&#7907;ng:
            <asp:TextBox ID="txtQty" runat="server" Text="1" Width="40" />
            <asp:LinkButton ID="btnAdd" runat="server" CssClass="prod_buy" 
                Text="Thêm vào gi&#7887;"
                CommandName="AddToCart"
                CommandArgument='<%# Eval("MASANPHAM") %>' />
        </div>
    </div>
  </ItemTemplate>
</asp:Repeater>
</asp:Content>
