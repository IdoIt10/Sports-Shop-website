using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;


namespace Project_Web_Final.App_Code
{
    public class DbActions
    {
        private static OleDbConnection con = null;

        private static void Connect_Me(string db_path)
        {
            string full_st = @"provider=microsoft.jet.oledb.4.0;Data Source="+db_path;

            con = new OleDbConnection(full_st);
        }
        //-----------------------------------------
        public static DataTable GetData(OleDbCommand cmd,string tableName, string db_path)
        {
            Connect_Me(db_path);
            
            cmd.Connection = con;

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds, tableName);
           
            return ds.Tables[0];
        }
        //-----------------------------------------
        public static void Change_Db(OleDbCommand cmd, string db_path)
        {
            Connect_Me(db_path);

            cmd.Connection = con;

            con.Open();

            cmd.ExecuteNonQuery(); // insert,update,delete

            con.Close();
        }


    }
}