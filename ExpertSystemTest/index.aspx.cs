using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExpertSystemTest
{



    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //searchExpertLabel lbl = (Label)Page.Master.FindControl("searchExpert");

            string where = Request.QueryString["searchExpert"]; 
            string conStr = WebConfigurationManager.ConnectionStrings["ExpertConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT [img_URL], [FirstName]+' '+[MiddleName]+' '+[LastName] as name,[College],[Dept],[Specialization],[FS_URL]FROM[Expert_system_data].[dbo].[Fac_Success_Images_facSuc]Where([Specialization] like '% " + where + "%' or[FirstName]like '" + where + "%' or[LastName]like '" + where + "%'or[College]like '" + where + "%') order by[LastName]", con);


            DataTable dt = new DataTable();
            sda.Fill(dt);
            ListView1.DataSource = dt;
            ListView1.DataBind();

        }

        protected void OpenWindow(object sender, EventArgs e)
        {
            string url = "Popup.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

    }
}