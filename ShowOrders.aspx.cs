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
    public partial class ShowOrders : System.Web.UI.Page
    {
        //הגדרת משתנים
        private DataTable dt = null;
        private static OleDbConnection con = null;
        private static DataTable dtstock = null;
        private static DataTable dtorder = new DataTable();
        private static int total = 0;
        private static ArrayList list = new ArrayList();//list_id_of_selected_products
        private static ArrayList listQuantity = new ArrayList();//list_quantity_of_selected_products
        //סיום הגדרת משתנים

        //הגדרת פעולות עזר
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

        private void GetTable(string sql)
        {
            dtstock = DbActions.GetData(new OleDbCommand(sql), "ORDER", Server.MapPath("App_Data/Db_Project_Feb.mdb"));

            dtlproducts.DataSource = dtstock;

            dtlproducts.DataBind();
        }

        public static void Change_Db(OleDbCommand cmd, string db_path)//פעולה לשינוי (מחיקה,הוספה,עדכון) מסד הנתונים
        {
            Connect_Me(db_path);

            cmd.Connection = con;

            con.Open();

            cmd.ExecuteNonQuery(); // insert,update,delete

            con.Close();
        }
        //סיום הגדרת פעולות עזר


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                total = 0;
                if (Session["userName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                string sql = "Select * from [ORDER] where nameCostumer='" + Session["UserName"].ToString() +"'";

                GetTable(sql);






                if (dtorder.Columns.Count == 0)
                {
                    DataColumn dc1 = new DataColumn();

                    dc1.ColumnName = "Product Id";

                    dtorder.Columns.Add(dc1);

                    DataColumn dc2 = new DataColumn();

                    dc2.ColumnName = "Product Name";

                    dtorder.Columns.Add(dc2);

                    DataColumn dc3 = new DataColumn();

                    dc3.ColumnName = "Quantity";

                    dtorder.Columns.Add(dc3);

                    DataColumn dc4 = new DataColumn();

                    dc4.ColumnName = "Price";

                    dtorder.Columns.Add(dc4);
                }


            }
        }

        protected void dtlproducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ((Label)dtlproducts.Items[dtlproducts.SelectedIndex].FindControl("lblid")).Text;



            string sqlProd = " SELECT TB_PRODUCTS.imgx, TB_PRODUCTS.ID, TB_PRODUCTS.price, TB_PRODUCTS.title, ORDER_PRODUCT.ORDER_ID, ORDER_PRODUCT.quantity FROM TB_PRODUCTS INNER JOIN ORDER_PRODUCT ON TB_PRODUCTS.[ID] = ORDER_PRODUCT.[PRODUCT_ID] where ORDER_PRODUCT.ORDER_ID='" + id + "'";

            dt = GetData(new OleDbCommand(sqlProd), "ORDER_PRODUCT", Server.MapPath("App_Data/Db_Project_Feb.mdb"));

            
            dtorder = dt;

            grdorder.DataSource = dtorder;
            grdorder.DataBind();

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    string prodId = dt.Rows[i][1].ToString();
            //    string sql2 = "Select * from TB_PRODUCTS where ID='" + prodId + "'";

            //    DataTable dtProd = GetData(new OleDbCommand(sql2), "TB_PRODUCTS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));

            //    DataRow dr;

            //    dr = dtorder.NewRow();
            //    dr = new DataRow(dtProd.Rows[0]);

            //    dtorder.Rows.Add(dr);
            //}

        }

        protected void grdorder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}