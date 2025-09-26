using System;

namespace QUANLYBANHANG
{
    public partial class pageGIOHANG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            BindCart();
        }

        private void BindCart()
        {
            var cart = Session["CART"] as CART;
            if (cart == null || cart.Items.Count == 0)
            {
                gvCart.DataSource = null; gvCart.DataBind();
                lblTotal.Text = "0";
                return;
            }

            gvCart.DataSource = cart.ToDataTable();
            gvCart.DataBind();
            lblTotal.Text = cart.Total().ToString("N0");
        }

        protected void gvCart_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            // Lấy mã sản phẩm từ CommandArgument
            string id = e.CommandArgument as string;
            if (string.IsNullOrEmpty(id)) return;

            var cart = Session["CART"] as CART;
            if (cart == null) return;

            switch (e.CommandName)
            {
                case "Remove":      // XÓA HẲN
                    cart.Remove(id);
                    break;

                case "Return":      // TRẢ HÀNG = GIẢM 1, nếu =0 thì xóa
                    if (cart.Items.TryGetValue(id, out var it))
                        cart.Update(id, it.SOLUONG - 1);
                    break;
            }

            Session["CART"] = cart;   // lưu lại
            BindCart();               // cập nhật lưới & tổng tiền
        }
    }
}
