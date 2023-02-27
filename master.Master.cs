using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Db
{
    public partial class Design : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["status"].ToString() == "2")
                ManagerPageRef.Visible = true;
            else
                ManagerPageRef.Visible = false;
        }
    }
}