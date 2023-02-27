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
    public partial class Cart : System.Web.UI.Page
    {
        protected string st = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Page.IsPostBack == false)
            {
                if (Session["ShoppingCart"] != null)
                {
                    OrderCart order = (OrderCart)Session["ShoppingCart"];

                    ArrayList list = order.GetProducts();

                    string StrToCart = "";

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == list.Count - 1)
                        {
                            StrToCart += list[i];
                        }
                        else
                            StrToCart += list[i] + " , ";
                    }

                    Session["ShoppingCartStr"] = StrToCart;
                    IDs.Text = Session["ShoppingCartStr"].ToString();
                }
                
            }
            
        }
    }
}