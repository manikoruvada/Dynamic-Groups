using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Receiver
{
    public partial class ReceiveData : Form
    {
        string str;
        public ReceiveData(string h)
        {
            str = h;
            InitializeComponent();
        }
        public ReceiveData()
        {
            InitializeComponent();
        }
        private string currentFileName = "Untitled";

        string de_file;
        
        private void button1_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = File.ReadAllText(de_file);
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Title = "Select File";
            //ofd.InitialDirectory = @"c:\";
            //ofd.Filter = "All Files (*.*)|*.*|All Files (*.*)|*.*";
            //ofd.FilterIndex = 2;
            //ofd.RestoreDirectory = true;
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    textBox3.Text = ofd.FileName;
            //}
            //inputTextBox.Text = File.ReadAllText(textBox3.Text);

        }
        
        private string GetFileName(string fileName)
        {
            string[] fileParts = fileName.Split("\\".ToCharArray());
            return fileParts[fileParts.Length - 1];
        }

       
        string Key;
        int IV;
        Cryptopad.Crypt cr = new Cryptopad.Crypt();

        private void button2_Click(object sender, EventArgs e)
        {
            string fitext = inputTextBox.Text;
            linkLabel1.Visible = true;
            string file=txt_file.Text;
            txt_key.Text = str;
            string key = txt_key.Text;
            cr.Calc(DateTime.Now);
            button1.Visible = true;
            Decrypt dr = new Decrypt();
            de_file=dr.crypt(key,file,fitext);
        }           

        
        private void ReceiveData_Load(object sender, EventArgs e)
        {
            linkLabel1.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            inputTextBox.Visible = false;
            txt_file.Visible = false;
            textBox1.Visible = false;
          
            button2.Visible = false;
            txt_key.Visible = false;
            button1.Visible = false;
            
        }

        //Browse a file
        private void btn_Browse_Click(object sender, EventArgs e)
        {  
            ofile.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            ofile.RestoreDirectory = true;
            ofile.Filter = "Text files (*.*)|*.*";
            if (ofile.ShowDialog() == DialogResult.OK)
            {
                txt_file.Text = ofile.FileName;
                inputTextBox.Text = File.ReadAllText(txt_file.Text);
            }
        }

        //Recive Data Link_Lable
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            linkLabel1.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            inputTextBox.Visible = true;
            txt_file.Visible = true;
            textBox1.Visible = true;
            cr.Calc(DateTime.Now);
            button2.Visible = true;
            txt_key.Visible = true;
            button1.Visible = true;
           

            txt_key.Text = str;
            string check = "get";
            byte[] data = new byte[1024];
            byte[] data1 = new byte[1024];
            byte[] data2 = new byte[1024];
            TcpListener newsock = new TcpListener(7777);
            newsock.Start();
            // Console.WriteLine("Waiting For a client Request...");

            TcpClient Client = newsock.AcceptTcpClient();
            NetworkStream ns = Client.GetStream();
            NetworkStream ns1=null;
            NetworkStream ns2 =null;

            //getting IP Address
            int recv = ns.Read(data, 0, data.Length);
            string flagvalue = Encoding.ASCII.GetString(data, 0, recv);
            textBox1.Text = flagvalue;
            ns.Write(Encoding.ASCII.GetBytes(check), 0, check.Length);           
           
            //getting FileName From Sender           
            ns1 = Client.GetStream();
            int recv1 = ns1.Read(data1, 0, data1.Length);
            string file_name = Encoding.ASCII.GetString(data1, 0, recv1);
            txt_file.Text = file_name;
            string check1 = "get1";
            ns1.Write(Encoding.ASCII.GetBytes(check1), 0, check1.Length);
          
            //getting fileText  from Sender            
            ns2 = Client.GetStream();
            int recv2 = ns2.Read(data2, 0, data2.Length);
            string file_text = Encoding.ASCII.GetString(data2, 0, recv2);
           
            ns2.Flush();
            ns.Flush();
            ns1.Flush();
            ns.Close();
            ns1.Close();
            ns2.Close();
            inputTextBox.Text = file_text; 
            button1.Visible = false;     
                      
        }

          

        
       
    }
}
