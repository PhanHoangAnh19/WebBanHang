using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace QUANLYBANHANG
{
    public class ADONET
    {
        SqlConnection con;
        public ADONET()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbQUANLYBANHANG";
        }
        private void MoKetNoi()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        private void DongKetNoi()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public DataTable BANGSQL(String SQL)
        {
            DataTable tb = null;
            try
            {
                this.MoKetNoi();
                SqlDataAdapter adp = new SqlDataAdapter(SQL, con);
                tb = new DataTable();
                adp.Fill(tb);
            }
            catch (Exception ex)
            { }
            finally
            {
                this.DongKetNoi();
            }
            return tb;
        }
        public DataTable BANGProcedurce(String nameprocedurce, SqlParameter[] pr)
        {
            DataTable tb = null;
            try
            {
                this.MoKetNoi();
                tb = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nameprocedurce;
                if (pr != null)
                    cmd.Parameters.AddRange(pr);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(tb);
            }
            catch (Exception ex)
            { }
            finally
            {
                this.DongKetNoi();
            }
            return tb;
        }

        /// <summary>
        /// Đối tượng command thực thi lệnh SQL
        /// </summary>
        /// <param name="SQL">SQL:insert, update, Delete</param>
        /// <returns>K(<>0, =0) trong đó <>0 thành công và =0 lỗi khi thực thi </returns>
        public int ExeCuteSQL(string SQL)
        {
            int k = 0; ;
            try
            {
                this.MoKetNoi();
                SqlCommand cmd = new SqlCommand(SQL, this.con);
                k = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { }
            finally
            {
                this.DongKetNoi();
            }
            return k;
        }
        public int ExeCuteProcedurce(String nameprocedurce, SqlParameter[] pr)
        {
            int k = 0;
            try
            {
                this.MoKetNoi();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nameprocedurce;
                if (pr != null) cmd.Parameters.AddRange(pr);
                k = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            {
                this.DongKetNoi();
            }
            return k;
        }
    }
}