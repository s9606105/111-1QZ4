using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace _111_1QZ4
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s_ConnI = 
                "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=Test;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False;" +
                "User ID = sa; Password = 12345;";

            try 
            {
                SqlConnection o_Conn = new SqlConnection(s_ConnI); // 先連線
                SqlCommand o_Com = new SqlCommand("SELECT * FROM Users", o_Conn); // 輸入SQL指令
                o_Conn.Open(); // 開啟資料庫
                SqlDataReader o_Dr = o_Com.ExecuteReader(); // 取得資料庫搜尋的資料
                for (; o_Dr.Read();) // 讀取資料庫內部資料，前後不用參數
                {
                    for (var i_Col = 0; i_Col < o_Dr.FieldCount; i_Col ++) // run資料列的資料數目
                    {
                        Response.Write("&nbsp;&nbsp" + o_Dr[i_Col].ToString());
                    }
                    Response.Write("<br />");
                }
                o_Conn.Close();
            }
            catch (Exception et)
            {
                Response.Write(et.ToString());
            }
            finally
            {
            }
        }
    }
}