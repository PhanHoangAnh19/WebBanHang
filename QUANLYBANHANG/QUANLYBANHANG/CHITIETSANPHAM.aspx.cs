using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;


namespace QUANLYBANHANG
{
    public partial class CHITIETSANPHAM : System.Web.UI.Page
    {
        ADONET db = new ADONET();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            string id = Request.QueryString["MASANPHAM"];
            if (string.IsNullOrWhiteSpace(id)) return;

            var pr = new[] { new SqlParameter("@MASANPHAM", id) };
            DataTable tbl = db.BANGProcedurce("dbo.psGetTableSANPHAM", pr);
            rptDetail.DataSource = tbl;
            rptDetail.DataBind();

            // gắn event
            rptDetail.ItemCommand += rptDetail_ItemCommand;
        }

        protected void rptDetail_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "AddToCart") return;

            string id = (string)e.CommandArgument;
            var txtQty = (System.Web.UI.WebControls.TextBox)e.Item.FindControl("txtQty");
            int qty = 1; int.TryParse(txtQty?.Text, out qty); if (qty <= 0) qty = 1;

            var pr = new[] { new SqlParameter("@MASANPHAM", id) };
            DataTable t = db.BANGProcedurce("dbo.psGetTableSANPHAM", pr);
            if (t.Rows.Count == 0) return;

            string name = t.Rows[0]["TENSANPHAM"].ToString();
            string img = t.Rows[0]["HINHANH"].ToString();
            decimal price = Convert.ToDecimal(t.Rows[0]["DONGIA"]);

            CART cart = Session["CART"] as CART ?? new CART();
            cart.Add(id, name, img, qty, price);
            Session["CART"] = cart;

            Response.Redirect("pageGIOHANG.aspx");
        }
    }
}
