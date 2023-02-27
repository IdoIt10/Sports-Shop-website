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
    public partial class Register : System.Web.UI.Page
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


        public static void addUser(string username, string password, string firstname, string lastname, string email, string age, string phone, string imglink, string DBlink)
        {
            string isDirector = "false";
            string sql = "Insert Into TB_USERS Values('" + username + "','" + password + "','" + email + "','" + firstname + "','" + lastname + "','"  + phone + "','" + age + "','" + isDirector + "','" + imglink + "')";
            Change_Db(new OleDbCommand(sql), DBlink);
        }

        protected void regButton_Click(object sender, EventArgs e)
        {
            string username = UserName.Text;
            string password = passWord.Text;
            string firstName = firstname.Text;
            string lastName = lastname.Text;
            string email = Email.Text;
            string age = Age.Text;
            string phone = Phone.Text;
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
                }
            }

            addUser(username, password, firstName, lastName, email, age, phone, ProfImg, DBlink);
            Response.Redirect("Login.aspx");
        }


    }
}




//string sql = "Update [TB_USERS] set userName='" + username + "',password='" + password + "',email='" + email + "',phone='" + phone + "',firstName='" + firstname + "',lastName='" + lastname + "',age='" + age + "',isDirector='" + "'false'" + "',nameImg='" + imglink + "'";//
//שורת עדכון UPDATE//
