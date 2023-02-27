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
    public partial class UpdateUserDetails : System.Web.UI.Page
    {
        private static OleDbConnection con = null;

        private static void Connect_Me(string db_path)//פעולה שמתחברת למסד הנתונים
        {
            string full_st = @"provider=microsoft.jet.oledb.4.0;Data Source=" + db_path;

            con = new OleDbConnection(full_st);
        }





        public static DataTable GetData(OleDbCommand cmd, string tableName, string db_path)//פעולה לשאיבת מידע ממסד הנתונים
        {
            Connect_Me(db_path);

            cmd.Connection = con;

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds, tableName);

            return ds.Tables[0];
        }





        public static void Change_Db(OleDbCommand cmd, string db_path)//פעולה לשינוי (מחיקה,הוספה,עדכון) מסד הנתונים
        {
            Connect_Me(db_path);

            cmd.Connection = con;

            con.Open();

            cmd.ExecuteNonQuery(); // insert,update,delete

            con.Close();
        }





        public static void changeUser(string username, string password, string firstName, string lastName, string email, string age, string phone, string nameImg, string DBlink)
        {

            string sql = "UPDATE TB_USERS SET TB_USERS.[password] =" + "'" + password + "', TB_USERS.email=" + "'" + email + "', TB_USERS.firstName =" + "'" + firstName + "', TB_USERS.lastName =" + "'" + lastName + "',TB_USERS.phone =" + "'" + phone + "', TB_USERS.age =" + "'" + age + "', TB_USERS.nameImg =" + "'" + nameImg + "'" + "WHERE((userName =" + "'" + username + "'" + "))";
            Change_Db(new OleDbCommand(sql), DBlink);
        }


        public static void changeUser_noImage(string username, string password, string firstName, string lastName, string email, string age, string phone, string nameImg, string DBlink)
        {

            string sql = "UPDATE TB_USERS SET TB_USERS.[password] =" + "'" + password + "', TB_USERS.email=" + "'" + email + "', TB_USERS.firstName =" + "'" + firstName + "', TB_USERS.lastName =" + "'" + lastName + "',TB_USERS.phone =" + "'" + phone + "', TB_USERS.age =" + "'" + age + "'" + "WHERE((userName =" + "'" + username + "'" + "))";
            Change_Db(new OleDbCommand(sql), DBlink);
        }




        private void Show()//פעולה להציג את פרטי המשתמש הנוכחיים שנלקחים ממסד הנתונים
        {
            if (dt.Rows.Count != 0)
            {
                TextBox2.Text = dt.Rows[0][1].ToString();
                TextBox3.Text = dt.Rows[0][2].ToString();
                TextBox4.Text = dt.Rows[0][3].ToString();
                TextBox5.Text = dt.Rows[0][4].ToString();
                TextBox6.Text = dt.Rows[0][5].ToString();
                TextBox7.Text = dt.Rows[0][6].ToString();


                Image1.ImageUrl = dt.Rows[0][8].ToString();
            }

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
            string userNameSearch = Session["userName"].ToString();
            sql = "Select * from [TB_USERS] where userName='" + userNameSearch + "'";

            dt = GetData(new OleDbCommand(sql), "TB_USERS", Server.MapPath("App_Data/Db_Project_Feb.mdb"));
            if (Page.IsPostBack == false)
            {
                Show();
            }



        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string username = Session["userName"].ToString();
            string password = TextBox2.Text;
            string firstName = TextBox4.Text;
            string lastName = TextBox5.Text;
            string email = TextBox3.Text;
            string age = TextBox7.Text;
            string phone = TextBox6.Text;
            string ProfImg = "";
            string DBlink = Server.MapPath("App_Data/Db_Project_Feb.mdb");

            string path = Server.MapPath("images/");
            if (FileUpload1.HasFile)
            {
                string ext = Path.GetExtension(FileUpload1.FileName);
                if (ext == ".JPG" || ext == ".PNG" || ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                {
                    FileUpload1.SaveAs(Server.MapPath("images/") + FileUpload1.FileName);
                    ProfImg = "images/" + FileUpload1.FileName;
                    Image1.ImageUrl = ProfImg;
                }
            }

            if (ProfImg != "")
            {
                changeUser(username, password, firstName, lastName, email, age, phone, ProfImg, DBlink);
            }
            if (ProfImg == "")
            {
                changeUser_noImage(username, password, firstName, lastName, email, age, phone, ProfImg, DBlink);
            }


            Response.Redirect("UpdateUserDetails.aspx");
        }
    }
}