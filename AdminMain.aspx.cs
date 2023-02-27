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
using System.Collections;
using Project_Web_Final.App_Code;

namespace Project_Web_Final
{
    public partial class AdminMain : System.Web.UI.Page
    {

        private static DataTable dtUsersCopy = new DataTable();

        public static void Change_Db(OleDbCommand cmd, string db_path)
        {
            Connect_Me(db_path);

            cmd.Connection = con;

            con.Open();

            cmd.ExecuteNonQuery(); // insert,update,delete

            con.Close();
        }

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
        private DataTable dt = null, dtall = null;
        private void ShowAllTable()
        {
            string sql = "Select * from TB_USERS";

            dtall = GetData(new OleDbCommand(sql), "TB_USERS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));

            grdclients.DataSource = dtall;

            grdclients.DataBind();

        }

        protected void grdclients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grdclients.SelectedIndex;

            string id = grdclients.Rows[index].Cells[1].Text;


            //DELETE * FROM TB_USERS WHERE(((TB_USERS.userName) = "KJking"));
            string sql = "Delete from [TB_USERS] where userName='" + id + "'";

            Change_Db(new OleDbCommand(sql), Server.MapPath("App_Data/Db_Project_Feb.mdb"));

            ShowAllTable();
        }



        private DataTable dtdt = null;
        protected string img_name = "";
        protected string user_name = "";
        protected string password = "";
        protected string Email = "";
        protected string firstName = "";
        protected string lastName = "";
        protected string phone = "";
        protected string age = "";
        protected void SearchButton_Click(object sender, ImageClickEventArgs e)
        {
            string searchResultId = SearchBox.Text;

            string sql = "";

            
            string dtPass;
            string dtUserName;
            string dtEmail, dtfirstName, dtlastName, dtphone, dtage, dtimg;

            sql = "Select * from [TB_USERS] where userName='" + searchResultId + "'";

            dtdt = GetData(new OleDbCommand(sql), "TB_USERS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));
            




            if (dtdt.Rows.Count != 0)
            {
                dtUserName = dtdt.Rows[0][0].ToString();
                dtPass = dtdt.Rows[0][1].ToString();
                dtEmail = dtdt.Rows[0][2].ToString();
                dtfirstName = dtdt.Rows[0][3].ToString();
                dtlastName = dtdt.Rows[0][4].ToString();
                dtphone = dtdt.Rows[0][5].ToString();
                dtage = dtdt.Rows[0][6].ToString();
                dtimg = dtdt.Rows[0][8].ToString();


                dtlSearch.DataSource = dtdt;

                dtlSearch.DataBind();
            }
            if (dtdt.Rows.Count == 0)
            {
                dtlSearch.DataSource = dtdt;

                dtlSearch.DataBind();
            }
        }

        






        //---------------



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                ShowAllTable();

            }
        }
        
    }
}