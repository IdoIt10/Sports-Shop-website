using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;


namespace Project_Web_Final
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private static OleDbConnection con = null;
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------

        private static void Connect_Me(string db_path)
        {
            string full_st = @"provider=microsoft.jet.oledb.4.0;Data Source=" + db_path;

            con = new OleDbConnection(full_st);
        }

        public static DataTable GetData(OleDbCommand cmd, string tableName, string db_path)
        {
            Connect_Me(db_path);

            cmd.Connection = con;

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds, tableName);

            return ds.Tables[0];
        }

        
        private DataTable dt = null;
        private DataTable dtdt = null;//admin checker
        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = userName.Text;
            string pass = passWord.Text;
            string isDirector = "true";
            string sql = "";
            string sqlAdmin = "";

            sql = "Select * from [TB_USERS] where userName='" + username + "' and password='" + pass + "'";
            sqlAdmin = "Select * from [TB_USERS] where userName='" + username + "' and password='" + pass + "' and isDirector='" + isDirector + "'";
            Session["userName"] = username;
            dt = GetData(new OleDbCommand(sql), "TB_USERS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));
            dtdt = GetData(new OleDbCommand(sqlAdmin), "TB_USERS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));
            if (dtdt.Rows.Count != 0)
            {
                Session["AdminExist"] = "Y";
                Response.Redirect("NavAdmin.aspx");

            }

            else if (dt.Rows.Count != 0)
            {
                Response.Redirect("UserProfile.aspx");
            }
        }
    }
}