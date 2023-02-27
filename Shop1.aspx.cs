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
    public partial class Shop1 : System.Web.UI.Page
    {
        //הגדרת משתנים
        private DataTable dt = null;
        private static OleDbConnection con = null;
        private static DataTable dtstock = null;
        private static DataTable dtorder = new DataTable();
        private static int total = 0;
        private static ArrayList list = new ArrayList();//list_id_of_selected_products
        private static ArrayList listQuantity = new ArrayList();//list_quantity_of_selected_products
        private static OrderCart order = new OrderCart(RndStr(), "", "");
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
            dtstock = DbActions.GetData(new OleDbCommand(sql), "TB_PRODUCTS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));

            dtlproducts.DataSource = dtstock;

            dtlproducts.DataBind();
        }

        private static string RndStr()//random_value_function
        {
            string RndStr = "";

            Random rnd = new Random();
            RndStr += ((char)rnd.Next(65, 91)).ToString();
            RndStr += rnd.Next(1, 1000001).ToString();

            return RndStr;
        }
        private ArrayList Search_Delete(string item, ArrayList list)//search_and_delete_value_from_list
        {
            bool found = false;
            int index = 0;

            while (index < list.Count && found == false)
            {
                if (list[index].ToString().Equals(item) == true)
                {
                    list.RemoveAt(index);
                    found = true;
                }
                else
                    index++;
            }

            return list;
        }
        private int Search_Delete_index(string item, ArrayList list)//search_find_index_suppossed_to_delete_value_in_list
        {
            bool found = false;
            int index = 0;

            while (index < list.Count && found == false)
            {
                if (list[index].ToString().Equals(item) == true)
                {
                    return index;
                }
                else
                    index++;
            }

            return index;
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




        //בטעינת העמוד
        protected void Page_Load(object sender, EventArgs e)//page_load
        {
            if (Page.IsPostBack == false)
            {
                total = 0;
                if (Session["userName"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                string sql = "Select * from TB_PRODUCTS";

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

        //רשימת התצוגה של המוצרים
        protected void dtlproducts_SelectedIndexChanged(object sender, EventArgs e)//selected_product
        {
            int index = dtlproducts.SelectedIndex;

            dtlproducts.EditItemIndex = index;

            string sql = "Select * from TB_PRODUCTS";

            GetTable(sql);
        }

        protected void dtlproducts_CancelCommand(object source, DataListCommandEventArgs e)//cancel_product
        {

            dtlproducts.EditItemIndex = -1;

            string sql = "Select * from TB_PRODUCTS";

            GetTable(sql);

        }

        protected void dtlproducts_UpdateCommand(object source, DataListCommandEventArgs e)//update_product_in_recipt
        {
            string id = ((Label)dtlproducts.Items[dtlproducts.SelectedIndex].FindControl("lblid")).Text;
            string name = ((Label)dtlproducts.Items[dtlproducts.SelectedIndex].FindControl("lblpname")).Text;
            int quantity = int.Parse(((DropDownList)dtlproducts.Items[dtlproducts.SelectedIndex].FindControl("drpqua")).Text);
            int price = int.Parse(((Label)dtlproducts.Items[dtlproducts.SelectedIndex].FindControl("lblprice")).Text);

            total += quantity * price;

            string sqlProd = "Select * from TB_PRODUCTS where ID='" + id + "'";
            dt = GetData(new OleDbCommand(sqlProd), "TB_PRODUCTS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));
            order.SetNameCostumer(Session["userName"].ToString());
            list.Add(id);
            listQuantity.Add(quantity);
            order.SetProducts(list);
            order.SetTotalPrice(order.GetTotalPrice() + price);
            Session["ShoppingCart"] = order;

            int size = dtorder.Rows.Count;
            bool found = false;
            int i = 0;

            while (i < size && found == false)
            {
                string myid = dtorder.Rows[i][0].ToString();

                if (id.Equals(myid))
                {
                    int myqua = int.Parse(dtorder.Rows[i][2].ToString());
                    myqua += quantity;

                    dtorder.Rows[i][2] = myqua;

                    found = true;
                }
                else
                    i++;
            }


            if (found == false)
            {
                DataRow dr;

                dr = dtorder.NewRow();

                dr[0] = id;
                dr[1] = name;
                dr[2] = quantity;
                dr[3] = price;

                dtorder.Rows.Add(dr);
            }


            grdorder.DataSource = dtorder;
            grdorder.DataBind();

            lbltotal.Text = total.ToString();
        }
        //סיום רשימת המוצרים





        //קבלה
        protected void grdorder_SelectedIndexChanged(object sender, EventArgs e)//delete_product_from_recipt
        {
            int index = grdorder.SelectedIndex;

            int value = int.Parse(dtorder.Rows[index][2].ToString()) * int.Parse(dtorder.Rows[index][3].ToString());

            int mytotalvalue = int.Parse(lbltotal.Text) - value;

            total = mytotalvalue;
            lbltotal.Text = mytotalvalue.ToString();

            order.SetTotalPrice(total);

            

            dtorder.Rows.RemoveAt(index);

            grdorder.DataSource = dtorder;
            grdorder.DataBind();
        }
        //סיום הקבלה



        
        //חיפוש
        protected void SearchButton_Click(object sender, ImageClickEventArgs e)//search_product_in_stock
        {
            string searchResultId = SearchBox.Text;

            string sql = "";

            string dtId;
            string dttitle;
            string dtprice, dtcolor, dtquantity, dtimgx, dtdate;

            sql = "Select * from [TB_PRODUCTS] where ID='" + searchResultId + "'";

            dt = GetData(new OleDbCommand(sql), "TB_USERS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));
            

            if (dt.Rows.Count != 0)
            {
                dtId = dt.Rows[0][0].ToString();
                dtimgx = dt.Rows[0][1].ToString();
                dtdate = dt.Rows[0][2].ToString();
                dtprice = dt.Rows[0][3].ToString();
                dttitle = dt.Rows[0][4].ToString();
                dtcolor = dt.Rows[0][5].ToString();
                dtquantity = dt.Rows[0][6].ToString();


                dtlSearch.DataSource = dt;

                dtlSearch.DataBind();
            }
            if (dt.Rows.Count == 0)
            {
                dtlSearch.DataSource = dt;

                dtlSearch.DataBind();
            }
            
        }
        //תצוגת חיפוש
        protected void dtlSearch_SelectedIndexChanged(object sender, EventArgs e)//select_searched_product
        {
            int index = dtlSearch.SelectedIndex;

            dtlSearch.EditItemIndex = index;

            string sql = "Select * from TB_PRODUCTS";

            GetTable(sql);
        }

        protected void dtlSearch_CancelCommand(object source, DataListCommandEventArgs e)//cancel_searched_product
        {

            dtlSearch.EditItemIndex = -1;

            string sql = "Select * from TB_PRODUCTS";

            GetTable(sql);

        }

        protected void dtlSearch_UpdateCommand(object source, DataListCommandEventArgs e)//update_searched_product_in_recipt
        {
            string id = ((Label)dtlSearch.Items[dtlSearch.SelectedIndex].FindControl("lblid")).Text;
            string name = ((Label)dtlSearch.Items[dtlSearch.SelectedIndex].FindControl("lblpname")).Text;
            int quantity = int.Parse(((DropDownList)dtlSearch.Items[dtlSearch.SelectedIndex].FindControl("drpqua")).Text);
            int price = int.Parse(((Label)dtlSearch.Items[dtlSearch.SelectedIndex].FindControl("lblprice")).Text);

            total += quantity * price;


            int size = dtorder.Rows.Count;
            bool found = false;
            int i = 0;

            while (i < size && found == false)
            {
                string myid = dtorder.Rows[i][0].ToString();

                if (id.Equals(myid))
                {
                    int myqua = int.Parse(dtorder.Rows[i][2].ToString());
                    myqua += quantity;

                    dtorder.Rows[i][2] = myqua;

                    found = true;
                }
                else
                    i++;
            }


            if (found == false)
            {
                DataRow dr;

                dr = dtorder.NewRow();

                dr[0] = id;
                dr[1] = name;
                dr[2] = quantity;
                dr[3] = price;

                dtorder.Rows.Add(dr);
            }


            grdorder.DataSource = dtorder;
            grdorder.DataBind();

            lbltotal.Text = total.ToString();
        }
        //סיום תצוגת חיפוש
        //סיום החיפוש


        //כפתור הזמנה
        protected void Order_btn_Click1(object sender, EventArgs e)
        {
            order.SetId(RndStr());
            string orderId = order.GetId();
            string clientid = order.GetNameCostumer();
            string date = DateTime.Today.ToShortDateString();
            string total1 = lbltotal.Text;
            string DBlink = Server.MapPath("App_Data/Db_Project_Feb.mdb");

            string sql = "INSERT INTO [ORDER] Values('" + orderId + "','" + clientid + "','" + total1 + "','" + date + "')";
            string sqlUpdateQuantity = "";
            string sqlCurrentQuantity = "";
            Change_Db(new OleDbCommand(sql), DBlink);

            for (int i = 0; i < grdorder.Rows.Count; i++)
            {
                string prodid = grdorder.Rows[i].Cells[1].Text;
                int quantity = int.Parse(grdorder.Rows[i].Cells[3].Text);

                sql = "INSERT INTO [ORDER_PRODUCT] Values('" + orderId + "','" + prodid + "','" + quantity + "')";
                DbActions.Change_Db(new OleDbCommand(sql), DBlink);
                int currentQuantity = 0;
                sqlCurrentQuantity = "Select quantity from TB_PRODUCTS where ID='" + prodid + "'";
                String TBname = "TB_PRODUCTS";
                DataTable currentProdQuantity = DbActions.GetData(new OleDbCommand(sqlCurrentQuantity), TBname, DBlink);
                currentQuantity = int.Parse(currentProdQuantity.Rows[0][0].ToString());
                Response.Write(currentQuantity);
                currentQuantity = currentQuantity - quantity;
                sqlUpdateQuantity = "UPDATE TB_PRODUCTS SET TB_PRODUCTS.[quantity] =" + "'" + currentQuantity + "'" + "WHERE((ID =" + "'" + prodid + "'" + "))";
                Response.Write(currentQuantity);
                DbActions.Change_Db(new OleDbCommand(sqlUpdateQuantity), DBlink);
                dtorder.Rows.RemoveAt(0);
            }
            
            grdorder.DataSource = dtorder;
            grdorder.DataBind();
            total = 0;
            lbltotal.Text = total.ToString();
            Response.Redirect("Shop1.aspx");
        }
        //סיום כפתור ההזמנה
    }
}