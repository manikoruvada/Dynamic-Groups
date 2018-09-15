using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace qunatumkey
{
    public partial class SendData : Form
    {
        string str;
        public SendData(string s)
        {
            str = s;
            InitializeComponent();
        }
        public SendData()
        {
            InitializeComponent();
        }
        private string currentFileName = "Untitled";	
	
        // Browse a File from anywhere in System
        //Accepts only Text File        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select File";
            ofd.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            ofd.Filter = "Text Files (*.*)|*.*|Text Files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_file.Text = ofd.FileName;
            }
            inputTextBox.Text = File.ReadAllText(txt_file.Text);
          }

        private string GetFileName(string fileName)
        {
            string[] fileParts = fileName.Split("\\".ToCharArray());
            return fileParts[fileParts.Length - 1];
        }
       
       string Key;
       int IV;
        private string openFile(string title, string filterString)
        {
            openFileDialog.FileName = "";
            openFileDialog.Title = title;
            openFileDialog.Filter = filterString;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName, true);
                    string fileString = streamReader.ReadToEnd();
                    streamReader.Close();
                   // cr.Calc(DateTime.Now);
                    if (fileString.Length >= inputTextBox.MaxLength)
                    {
                        MessageBox.Show("ERROR: \nThe file you are trying to open is too big for the text editor to display properly.\nPlease open a smaller document!\nOperation Aborted!");
                        return null;
                    }
                    if (fileString != null)
                    {
                        this.Text = GetFileName(openFileDialog.FileName);
                        currentFileName = openFileDialog.FileName;
                        txt_file.Text = currentFileName;
                    }
                    return fileString;
                }
            }
            return null;
        } 
     
        //send
        private void button2_Click(object sender, EventArgs e)
        {
            //string myhost = Dns.GetHostName();
            //System.Net.IPHostEntry ipentry=Dns.GetHostEntry(myhost);
            //IPAddress myadd=ipentry.AddressList[0];
            //txt_IPAdd.Text = myadd.ToString();
            string h= txt_IPAdd.Text.ToString();
            if (txt_IPAdd.Text == "" || txt_file.Text == "")
            {
                MessageBox.Show("Please Fill up All Text Boxes");
            }
            else
            {
                byte[] data = new byte[1024];
                string input, strdata;
                TcpClient Server1;
                int recv;
                try
                {
                    Server1 = new TcpClient(txt_IPAdd.Text, 7777);
                }
                catch (SocketException)
                {
                    MessageBox.Show("Unable to connect Main Server...");
                    return;
                }

                NetworkStream ns = Server1.GetStream();                
                string flagvalue1="";
                NetworkStream ns1 = null;
                NetworkStream ns2 = null;
               // cr.Calc(DateTime.Now);
                
                string file_name = en_file;
                if (after_enc_Text!= null)
                 {
                        //Sending IP Address                        
                        ns.Write(Encoding.ASCII.GetBytes(h),0,h.Length);
                        recv = ns.Read(data, 0, data.Length);
                        string flagvalue = Encoding.ASCII.GetString(data, 0, recv);
                        if (flagvalue == "get")
                        {
                            //Sending selected FileName                            
                            ns1 = Server1.GetStream();
                            ns1.Write(Encoding.ASCII.GetBytes(file_name), 0, file_name.Length);
                            recv = ns.Read(data, 0, data.Length);
                            flagvalue1 = Encoding.ASCII.GetString(data, 0, recv);                
                        }
                        if (flagvalue1 == "get1")
                        {
                            //Sending Text of the File                             
                            ns2 = Server1.GetStream();
                            ns2.Write(Encoding.ASCII.GetBytes(after_enc_Text), 0, after_enc_Text.Length);
                        }
                        ns.Flush(); 
                        ns1.Flush();
                       // ns2.Flush();
                        ns.Close();
                        ns1.Close();
                        //ns2.Close();                       
                        MessageBox.Show("Sent Successfully...");
                        ns.Close();               
                     
                    }
                    else
                    {
                        MessageBox.Show("Disconnecting from Server...");
                        //break;
                    }              

                ns.Close();
                Server1.Close();           
            }
        }

        //For Encryption
        public string en_file;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {        
                string keys, files;
                keys = txt_QKey.Text;
                files = txt_file.Text;
                encrypt er = new encrypt();
                en_file=er.crypt(keys,files);
                btn_After.Visible = true;
                button3.Enabled = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured " + ex.ToString());
            }
         }

        //Load Page
        private void Form1_Load(object sender, EventArgs e)
        {
           // txt_QKey.Text = str.ToString();
            btn_After.Visible = false;
            linkLabel1.Visible = true;
            button2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false; 
            label4.Visible = false;
            inputTextBox.Visible = false;
            txt_file.Visible = false;
            txt_IPAdd.Visible = false;
            txt_QKey.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            
        }
        string after_enc_Text;
        private void btn_After_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = File.ReadAllText(en_file);
            after_enc_Text = inputTextBox.Text;
            button2.Visible = true;
        }
        Cryptopad.Crypt cr = new Cryptopad.Crypt();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            //cr.Calc(DateTime.Now);
            linkLabel1.Visible = false;
            button2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            inputTextBox.Visible = true;
            txt_file.Visible = true;
            txt_IPAdd.Visible = true;
            txt_QKey.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
            txt_QKey.Text = str;
        }
       
    }
}