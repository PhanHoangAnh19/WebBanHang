<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="Danhsachsanpham.aspx.cs" Inherits="QUANLYBANHANG.Danhsachsanpham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
    <ItemTemplate>
        <div class="prod_box">
            <div class="top_prod_box"></div>
            <div class="center_prod_box">
                <div class="product_title">
                    <a href='<%# "CHITIETSANPHAM.aspx?MASANPHAM=" + Eval("MASANPHAM") %>' 
                       class="prod_details">
                        <%# Eval("TENSANPHAM") %>
                    </a>
                </div>
                                <div class="product_img">
                    <a href='<%# "CHITIETSANPHAM.aspx?MASANPHAM=" + Eval("MASANPHAM") %>'>
                        <img src='images/<%# Eval("HINHANH") %>' alt='<%# Eval("TENSANPHAM") %>' 
                             border="0" width="150" height="150" />
                    </a>
                </div>
                <div class="prod_price">
                    <span class="reduce">350$</span>
                    <span class="price"><%# Eval("DONGIA") %>$</span>
                </div>
            </div>
            <div class="bottom_prod_box"></div>
        </div>
    </ItemTemplate>
</asp:DataList>
</asp:Content>
