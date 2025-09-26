using QUANLYBANHANG;
using System;
using System.Data;
using System.Data.SqlClient;
namespace QUANLYBANHANG
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        ADONET db = new ADONET();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            DataTable dm = db.BANGProcedurce("dbo.psGetDANHMUC", null);
            rptCategories.DataSource = dm;
            rptCategories.DataBind();
        }
    }
}