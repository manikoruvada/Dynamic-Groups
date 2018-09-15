using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace qunatumkey
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lbl_syslogdate.Text = DateTime.Now.ToLongTimeString();
            comboBox1.Items.Clear();
            string constr = @"Data Source=(LocalDb)\v11.0;Initial Catalog=quantumkey;Integrated Security=True;Pooling=False";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select uname from reg", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            
        }

        //Login Button
        string a, b;
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
                    cmd = new SqlCommand("select pwd,secret from reg where uname='" + comboBox1.SelectedItem.ToString() + "'", con);
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
                        MessageBox.Show("Pass Word & Secret Key Mismatch");
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
                            //Give the IP Address of Trusted Center's 
                            Server1 = new TcpClient("localhost", 7000);
                        }
                        catch (SocketException)
                        {
                            MessageBox.Show("Unable to connect Main Server...");
                            return;
                        }

                        NetworkStream ns = Server1.GetStream();                        
                        input = comboBox1.SelectedItem.ToString();
                        MessageBox.Show("input is " + input);
                        string flag="send";
                        if (input != "exit")
                        {
                            MessageBox.Show("inside if condtion");
                            ns.Write(Encoding.ASCII.GetBytes(flag), 0, flag.Length);
                            MessageBox.Show("writing once");
                            ns.Write(Encoding.ASCII.GetBytes(b), 0, b.Length);
                            MessageBox.Show("writing twice");
                            ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
                                                
                            recv = ns.Read(data, 0, data.Length);
                            MessageBox.Show("reading once");
                            strdata = Encoding.ASCII.GetString(data, 0, recv);
                            Int32 aa = Convert.ToInt32(strdata);
                            MessageBox.Show("converted");
                            int y = strdata.Length;

                            long t = hashing(aa, y);
                            MessageBox.Show("Quantum Key : " + t);

                            //SqlCommand cmd1 = new SqlCommand("insert into qkey values("+t+"),con");
                            //cmd1.ExecuteNonQuery();
                            SendData sd = new SendData(t.ToString());
                            sd.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
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
            lbl_syslogdate.Text = dat.ToString();
            string tim = ss1.ToString("T");
            lbl_syslogtime.Text = tim.ToString(); 
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
                //Random rnd1 = new Random();
                Int16 aa = 52;
                //Random rnd2=new Random();
                Int16 bb = 3232;
                QK = y * aa * bb;
                string q = QK.ToString();
                if (q.Length == 8)
                {
                    return QK;
                }
                else
                {
                x: for (int i = 0; i <= q.Length; i++)
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
