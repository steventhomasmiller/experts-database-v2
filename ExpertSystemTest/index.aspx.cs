using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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

            //vars for storing search words

            string whereStr = "%";

            string where1 = "%";

            string where2 = "%";

            string where3 = "%";


            //Search topic text field filter and split

            whereStr = Request.QueryString["searchExpert"];

            if (whereStr != null)
            {
                Regex badWords = new Regex("the ", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                whereStr = badWords.Replace(whereStr, string.Empty);

                //removes rest of filler words
                badWords = new Regex(" and | of | but | the | or ", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                whereStr = badWords.Replace(whereStr, string.Empty + " ");

                string[] temp = whereStr.Split();

                //writes array values to variables for filter

                if (temp.Length >= 1)

                {
                    where1 = temp[0];

                }

                if (temp.Length >= 2)

                {
                    where2 = temp[1];

                }

                if (temp.Length == 3)

                {
                    where3 = temp[2];

                }
            }

            //assigns values to string array

            


            string conStr = WebConfigurationManager.ConnectionStrings["ExpertConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT [img_URL], [FirstName]+' '+[MiddleName]+' '+[LastName] name,[College],[Dept],[Specialization],[FS_URL] FROM[Expert_system_data].[dbo].[Fac_Success_Images_facSuc] Where (([Specialization] like '%" + where1 + "%' and [Specialization] like '%" + where2 + "%' and [Specialization] like '%" + where3 + "%') or ([FirstName]  like '%" + where1 + "%' and [LastName]  like '%" + where2 + "%' and [LastName]  like '%" + where3 + "%') or ([LastName]  like '%" + where1 + "%') or ([Dept] like '%" + where1 + "%' and [Dept] like '%" + where2 + "%' and [Dept] like '%" + where3 + "%')) order by[LastName]", con);

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