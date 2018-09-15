using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace Receiver
{
    public partial class Login : Form
    {
       
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string constr = @"Data Source=(LocalDb)\v11.0;Initial Catalog=quantumkey;Integrated Security=True;Pooling=False;";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select uname from recreg", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            
        }

        //Login Module
        string a, b;
        string input;
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
                    SqlCommand cmd;
                    con.Open();
                    cmd = new SqlCommand("select pwd,secret from recreg where uname='" + comboBox1.SelectedItem.ToString() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        a = dr[0].ToString();
                        b = dr[1].ToString();
                    }

                    if (comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Please Fill up All Text Boxes");
                    }
                    else if (textBox1.Text != a || textBox2.Text != b)
                    {
                        MessageBox.Show("User Name & PassWord Mismatch");
                    }
                    else if (textBox1.Text == a && textBox2.Text == b)
                    {
                        //SendData sd = new SendData();
                        //sd.Show();
                        byte[] data = new byte[1024];
                        string input, strdata;
                        TcpClient Server1;

                        int recv;
                        try
                        {
                            Server1 = new TcpClient("localhost", 6666);
                        }
                        catch (SocketException)
                        {
                            MessageBox.Show("Unable to connect Main Server...");
                            return;
                        }

                        NetworkStream ns = Server1.GetStream();
                        input = comboBox1.SelectedItem.ToString();
                        string flag1 = "recv";
                        if (input != "exit")
                        {
                            ns.Write(Encoding.ASCII.GetBytes(flag1),0,flag1.Length);
                            ns.Write(Encoding.ASCII.GetBytes(b), 0, b.Length);
                            ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);                            
                            
                            recv = ns.Read(data, 0, data.Length);
                            strdata = Encoding.ASCII.GetString(data, 0, recv);
                            Int32 aa = Convert.ToInt32(strdata);
                            int y = strdata.Length;
                            long t = hashing(aa, y);
                            MessageBox.Show("Quantum Key : " + t);
                            ReceiveData sd = new ReceiveData(t.ToString());
                            sd.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }               
                   
                }
            }
            catch(Exception ex)
            {
                string ss = ex.Message;
                MessageBox.Show(ss);
            }

        }

        public int valid()
        {
            string aa = textBox1.Text;
            int i = 0;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Password Should not Be Empty");
                i = 1;
            }
            else if ((aa.Length < 6) || (aa.Length > 10))
            {
                MessageBox.Show("Password Length Should be >6 & <10");
                i = 1;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Secret Key Should not be Empty");
                i = 1;
            }
            return i;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime ss1 = DateTime.Now;
            string dat = ss1.ToString("D");
            lbl_logdate.Text = dat.ToString();
            string tim = ss1.ToString("T");
            lbl_logtime.Text = tim.ToString();     
        }

        //Hashing Function to Convert Quantum Key into 8 digit
        public long hashing(int a, int y)
        {
            Int64 QK;
            Int64 ins = Convert.ToInt64(y);
            if (y == 0)
            {
                Random ee = new Random();
                y = ee.Next(100);
            }
           
            Int16 aa = 52;
           
            Int16 bb = 3232;
            QK = y * aa * bb;
            string q = QK.ToString();
            if (q.Length == 8)
            {
                return QK;
            }
            else
            {
            x:
                for (int i = 0; i <= q.Length; i++)
                {
                    if (q.Length > 8)
                    {
                        q = q.Substring(0, 8);
                        ins = Convert.ToInt64(q);
                    }
                    if (q.Length == 8)
                    {
                        return ins;
                    }
                    if (q.Length == 7)
                    {
                        QK = ins * aa * bb * 7;
                        q = QK.ToString();
                        ins = Convert.ToInt64(QK);
                    }
                    if (q.Length == 6)
                    {
                        QK = ins * aa * bb * 9;
                        q = QK.ToString();
                        ins = Convert.ToInt64(QK);
                    }
                    if (q.Length == 5)
                    {
                        QK = ins * aa * bb * 11;
                        q = QK.ToString();
                        ins = Convert.ToInt64(QK);
                    }
                    if (q.Length == 4)
                    {
                        QK = ins * aa * bb * 13;
                        q = QK.ToString();
                        ins = Convert.ToInt64(QK);
                    }
                    if (q.Length == 3)
                    {
                        QK = ins * aa * bb * 15;
                        q = QK.ToString();
                        ins = Convert.ToInt64(QK);
                    }
                    if (q.Length == 2)
                    {
                        QK = ins * aa * bb * 17;
                        q = QK.ToString();
                        ins = Convert.ToInt64(QK);
                    }

                }
                if (q.Length == 8)
                {
                    return ins;
                }
                else
                {
                    goto x;
                }
            }
            return ins;
        }       
    }
}