using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QUANLYBANHANG
{
    public partial class Danhsachsanpham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ADONET ado = new ADONET();
                string SQL = "SELECT * FROM tbSANPHAM";
                System.Data.DataTable tb = ado.BANGSQL(SQL);

                DataList1.DataSource = tb;
                DataList1.DataBind();
            }
        }
    }
}