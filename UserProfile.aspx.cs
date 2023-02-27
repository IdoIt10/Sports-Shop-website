using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Project_Web_Final
{
    public partial class UserProfile : System.Web.UI.Page
    {
        private static OleDbConnection con = null;

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
        protected string img_name = "";
        protected string user_name = "";
        protected string password = "";
        protected string Email = "";
        protected string firstName = "";
        protected string lastName = "";
        protected string phone = "";
        protected string age = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "";
            string username = Session["username"].ToString();
            string dtPass;
            string dtUserName;
            string dtEmail, dtfirstName, dtlastName, dtphone, dtage, dtimg;

            sql = "Select * from [TB_USERS] where userName='" + username + "'";

            dt = GetData(new OleDbCommand(sql), "TB_USERS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));
            dtUserName = dt.Rows[0][0].ToString();
            dtPass = dt.Rows[0][1].ToString();
            dtEmail = dt.Rows[0][2].ToString();
            dtfirstName = dt.Rows[0][3].ToString();
            dtlastName = dt.Rows[0][4].ToString();
            dtphone = dt.Rows[0][5].ToString();
            dtage = dt.Rows[0][6].ToString();
            dtimg = dt.Rows[0][8].ToString();



            user_name = dtUserName;
            password = dtPass;
            Email = dtEmail;
            firstName = dtfirstName;
            lastName = dtlastName;
            phone = dtphone;
            age = dtage;
            img_name = dtimg;
        }

        protected void toUpdatePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateUserDetails.aspx");
        }

        protected void BtnAdmin1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NavAdmin.aspx");
        }
    }
}