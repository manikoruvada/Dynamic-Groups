using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace qunatumkey
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        //Generate secrete key
        private void button1_Click(object sender, EventArgs e)
        {
            Secretkey sk = new Secretkey();
            string a = sk.Generate(8, 8);
            MessageBox.Show("Secret Key is : "+a.ToString());
            txt_secrete.Text = a.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //int ex = valid();
                //MessageBox.Show(ex.ToString());
                //if (ex == 1)
                //{
                  //  if ((MessageBox.Show("Give Valid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK))
                    //{
                        Application.UseWaitCursor.ToString();
                    //}
                //}
                   //if (ex == 0)
                    //{
                       // qunatumkey.Database db = new qunatumkey.Database();
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;Initial Catalog=quantumkey;Integrated Security=True;Pooling=False");
                        con.Open();
                        SqlCommand cb = new SqlCommand("insert into reg values('" + txt_uname.Text + "','" + txt_pwd.Text + "','" + txt_secrete.Text + "','" + lbl_syslogdate.Text + "','" + lbl_syslogtime.Text + "')", con);
                //db.insert("insert into reg values('" + txt_uname.Text + "','" + txt_pwd.Text + "','" + txt_secrete.Text + "','" + lbl_syslogdate.Text + "','" + lbl_syslogtime.Text + "')");
                        cb.ExecuteNonQuery();       
                MessageBox.Show("Values Are Inserted Successfully");
                        Login lgn = new Login();
                        lgn.Show();
                    //}
               }            
            catch (Exception ex)
            {
                string ee=ex.Message;
                MessageBox.Show(ee);
            } 
        }
        
    // Show System Date & time
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime ss1 = DateTime.Now;
            string dat = ss1.ToString("D");
            lbl_syslogdate.Text = dat.ToString();
            string tim = ss1.ToString("T");
            lbl_syslogtime.Text = tim.ToString();
        }
        private void Register_Load(object sender, EventArgs e)
        {
            
        }
        
        public int valid()
        {
            string aa = txt_pwd.Text;
            int i = 0;
            if (txt_uname.Text == "")
            {
                MessageBox.Show("User Name Should not be Empty");
                i = 1;
            }
            else if (txt_pwd.Text == "")
            {
                MessageBox.Show("Password Should not Be Empty");
                i = 1;
            }
            else if ((aa.Length < 6) || (aa.Length > 10))
            {
                MessageBox.Show("Password Length Should be >6 & <10");
                i = 1;
            }
            else if (txt_secrete.Text == "")
            {
                MessageBox.Show("Secret Key Should not be Empty");
                i = 1;
            }
            return i;

        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Enabled = false;
        }          
    }
}