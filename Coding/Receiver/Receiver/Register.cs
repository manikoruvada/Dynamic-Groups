using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Receiver
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Secretkey sk = new Secretkey();
            string a = sk.Generate(8, 8);
            MessageBox.Show("Secret Key is : "+a.ToString());
            textBox3.Text = a.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int ex = valid();
                if (ex == 1)
                {
                    if ((MessageBox.Show("Give Valid Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK))
                    {
                        Application.UseWaitCursor.ToString();
                    }
                }
                if (ex == 0)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;Initial Catalog=quantumkey;Integrated Security=True;Pooling=False");
                    con.Open();
                    SqlCommand cb = new SqlCommand("insert into recreg values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + lbl_regdate.Text + "','" + lbl_RegTime.Text + "')", con);
                    //db.insert("insert into recreg values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + lbl_regdate.Text + "','" + lbl_RegTime.Text + "')");
                    cb.ExecuteNonQuery();
                    MessageBox.Show("Values Are Inserted Successfully");
                    Login lgn = new Login();
                    lgn.Show();
                }
            }
            catch (Exception ex)
            {
                String ee = ex.Message;
                MessageBox.Show(ee);
            }           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime ss1 = DateTime.Now;
            string dat = ss1.ToString("D");
            lbl_regdate.Text = dat.ToString();
            string tim = ss1.ToString("T");
            lbl_RegTime.Text = tim.ToString();
        }

        public int valid()
        {
            string aa = textBox2.Text;
            int i = 0;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Username Should not Be Empty");
                i = 1;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Password Should not Be Empty");
                i = 1;
            }
            else if ((aa.Length < 6) || (aa.Length > 10))
            {
                MessageBox.Show("Password Length Should be >6 & <10");
                i = 1;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Secret Key Should not be Empty");
                i = 1;
            }
            return i;

        }

    }
}