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

//לבדוק הערה בטעינת העמוד

namespace Project_Web_Final
{
    public partial class Shop : System.Web.UI.Page
    {

        private static string RndStr()
        {
            string RndStr = "";

            Random rnd = new Random();
            RndStr += ((char)rnd.Next(65, 91)).ToString();
            RndStr += rnd.Next(1, 1000001).ToString();

            return RndStr;
        }
        
        private static ArrayList list = new ArrayList();




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
            string sql = "Select * from TB_PRODUCTS";

            dtall = GetData(new OleDbCommand(sql), "TB_PRODUCTS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));

            GridView_Products.DataSource = dtall;

            DataBind();

        }

        protected void GridView_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView_Products.SelectedIndex;

            string id = GridView_Products.Rows[index].Cells[1].Text;
            


            string sql = "Delete * from TB_PRODUCTS where ID='" + id + "'";

            DbActions.Change_Db(new OleDbCommand(sql), Server.MapPath("App_Data/Db_Project_Feb.mdb"));

            ShowAllTable();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }



        //---------------



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                ShowAllTable();
                if (list != null)
                {
                    list = new ArrayList();//לבדוק את הסשן, סטטיק, משתמשים שונים ולהבין איך לאפס הזמנות בצורה המיטבית
                }
            }
        }

    }
}



