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
    public partial class addProduct : System.Web.UI.Page
    {
        private static OleDbConnection con = null;




        private static void Connect_Me(string db_path)
        {
            string full_st = @"provider=microsoft.jet.oledb.4.0;Data Source=" + db_path;

            con = new OleDbConnection(full_st);
        }



        public static void Change_Db(OleDbCommand cmd, string db_path)
        {
            Connect_Me(db_path);

            cmd.Connection = con;

            con.Open();

            cmd.ExecuteNonQuery(); // insert,update,delete

            con.Close();
        }




        public static void addProductFunc(string title, string price, string color, string id, string date1, string imgx, string DBlink, string quantity)
        {
            string sql = "Insert Into TB_PRODUCTS Values('" + id + "','" + imgx + "','" + date1 + "','" + price + "','" + title + "','" + color + "','" + quantity + "')";
            Change_Db(new OleDbCommand(sql), DBlink);
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string quantity1 = quntity.Text;
            string title = title1.Text;
            string price = price1.Text;
            string id = id1.Text;
            string color = color1.Text;
            string date = Calendar1.SelectedDate.ToShortDateString();
            string imgx = "";
            string DBlink = Server.MapPath("App_Data/Db_Project_Feb.mdb");

            string path = Server.MapPath("images/");
            if (FileUpload1.HasFile)
            {
                string ext = Path.GetExtension(FileUpload1.FileName);
                if (ext == ".JPG" || ext == ".PNG" || ext == ".png" || ext == ".jpg" || ext == ".JPEG")
                {
                    FileUpload1.SaveAs(path + FileUpload1.FileName);
                    imgx = "images/" + FileUpload1.FileName;
                }
            }

            addProductFunc(title, price, color, id, date, imgx, DBlink, quantity1);

            Response.Redirect("NavAdmin.aspx");
        }
    }
}