using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn;
        
        

        cn = new SqlConnection("Data Source=.;Initial Catalog=sample;Integrated Security=True"); ;
        cn.Open();
        int flag = 0;
        SqlParameter p1 = new SqlParameter();
        p1.ParameterName = "@uname";
        p1.SqlDbType = SqlDbType.VarChar;
        p1.Direction = ParameterDirection.Input;
        SqlParameter p2 = new SqlParameter();
        p2.ParameterName = "@pwd";
        p2.SqlDbType = SqlDbType.VarChar;
        p2.Direction = ParameterDirection.Input;
        //string str="select * from reg where userid='" + textboix1.text +"' and password='" +textbox2.text +"'";
        string str = "select * from reg where userid=@uname and password=@pwd";
        p1.Value = TextBox1.Text;
        p2.Value = TextBox2.Text;
        SqlCommand cb = new SqlCommand(str, cn);
        cb.Parameters.Add(p1);
        cb.Parameters.Add(p2);
        SqlDataReader dr = cb.ExecuteReader();
        while(dr.Read())
        {
            if (dr[0].Equals(TextBox1.Text) && dr[1].Equals(TextBox2.Text))
            {
                flag = 1;
                break;
            }
        
        }
        if (flag == 1)
            Response.Redirect("http://wwww.yahoo.com");
        else
            Label1.Text = "invalid userid and passsword";
    }
}