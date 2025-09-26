using System;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYBANHANG
{
    public partial class Login : System.Web.UI.Page
    {
        ADONET db = new ADONET();

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string u = txtUser.Text.Trim();
            string p = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p))
            {
                lblMsg.Text = "Vui lòng nhập tài khoản và mật khẩu.";
                return;
            }

            var pr = new[]
            {
                new SqlParameter("@TAIKHOAN", u),
                new SqlParameter("@MATKHAU",  p)
            };

            DataTable t = db.BANGProcedurce("dbo.psLOGIN", pr);

            if (t.Rows.Count == 0)
            {
                lblMsg.Text = "Tài khoản hoặc mật khẩu không đúng.";
                return;
            }

            // Lưu thông tin đăng nhập vào Session
            Session["USER_ID"] = t.Rows[0]["MAKH"].ToString();
            Session["USER_NAME"] = t.Rows[0]["HOTEN"].ToString();
            Session["USER_ACC"] = t.Rows[0]["TAIKHOAN"].ToString();
            // Nếu có VAITRO: Session["ROLE"] = t.Rows[0]["VAITRO"].ToString();

            // Về trang trước hoặc về danh sách
            Response.Redirect("Danhsachsanpham.aspx");
        }
    }
}
