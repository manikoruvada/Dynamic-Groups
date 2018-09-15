using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cb;
        cn = new SqlConnection("Data Source=.;Initial Catalog=sample;Integrated Security=True"); ;
        cn.Open();
        da = new SqlDataAdapter("select * from emp", cn);
        ds = new DataSet();
        da.Fill(ds,"e");
        cb = new SqlCommandBuilder(da);
        DataRow dr;
        dr = ds.Tables["e"].NewRow();
        dr[0] = int.Parse(TextBox1.Text);
        dr[1] = TextBox2.Text;
        dr[2] = int.Parse(TextBox3.Text);
        ds.Tables["e"].Rows.Add(dr);
        da.Update(ds,"e");
        Label1.Text = "record isnerted";
        cn.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection cn;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cb;

        cn = new SqlConnection("Data Source=.;Initial Catalog=sample;Integrated Security=True"); ;
        cn.Open();
        da = new SqlDataAdapter("select * from emp", cn);
        ds = new DataSet();
        cb = new SqlCommandBuilder(da);
        da.Fill(ds, "e");
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        cn.Close();
    }
}