namespace qunatumkey
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_uname = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.txt_secrete = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_Logdate = new System.Windows.Forms.Label();
            this.lbl_logtime = new System.Windows.Forms.Label();
            this.lbl_syslogdate = new System.Windows.Forms.Label();
            this.lbl_syslogtime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_uname
            // 
            this.txt_uname.Location = new System.Drawing.Point(167, 85);
            this.txt_uname.Name = "txt_uname";
            this.txt_uname.Size = new System.Drawing.Size(100, 20);
            this.txt_uname.TabIndex = 0;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pwd.Location = new System.Drawing.Point(167, 121);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '@';
            this.txt_pwd.Size = new System.Drawing.Size(100, 21);
            this.txt_pwd.TabIndex = 1;
            // 
            // txt_secrete
            // 
            this.txt_secrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_secrete.Location = new System.Drawing.Point(167, 163);
            this.txt_secrete.Name = "txt_secrete";
            this.txt_secrete.PasswordChar = '@';
            this.txt_secrete.ReadOnly = true;
            this.txt_secrete.Size = new System.Drawing.Size(100, 21);
            this.txt_secrete.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = " password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = " Secret key";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Pristina", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(98, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = " Registration";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = " Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Register";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_Logdate
            // 
            this.lbl_Logdate.AutoSize = true;
            this.lbl_Logdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Logdate.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Logdate.Location = new System.Drawing.Point(12, 17);
            this.lbl_Logdate.Name = "lbl_Logdate";
            this.lbl_Logdate.Size = new System.Drawing.Size(69, 13);
            this.lbl_Logdate.TabIndex = 9;
            this.lbl_Logdate.Text = "Reg.  Date";
            // 
            // lbl_logtime
            // 
            this.lbl_logtime.AutoSize = true;
            this.lbl_logtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_logtime.ForeColor = System.Drawing.Color.Blue;
            this.lbl_logtime.Location = new System.Drawing.Point(223, 17);
            this.lbl_logtime.Name = "lbl_logtime";
            this.lbl_logtime.Size = new System.Drawing.Size(69, 13);
            this.lbl_logtime.TabIndex = 10;
            this.lbl_logtime.Text = "Reg.  Time";
            // 
            // lbl_syslogdate
            // 
            this.lbl_syslogdate.AutoSize = true;
            this.lbl_syslogdate.Location = new System.Drawing.Point(101, 17);
            this.lbl_syslogdate.Name = "lbl_syslogdate";
            this.lbl_syslogdate.Size = new System.Drawing.Size(0, 13);
            this.lbl_syslogdate.TabIndex = 11;
            // 
            // lbl_syslogtime
            // 
            this.lbl_syslogtime.AutoSize = true;
            this.lbl_syslogtime.Location = new System.Drawing.Point(299, 17);
            this.lbl_syslogtime.Name = "lbl_syslogtime";
            this.lbl_syslogtime.Size = new System.Drawing.Size(0, 13);
            this.lbl_syslogtime.TabIndex = 12;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 266);
            this.Controls.Add(this.lbl_syslogtime);
            this.Controls.Add(this.lbl_syslogdate);
            this.Controls.Add(this.lbl_logtime);
            this.Controls.Add(this.lbl_Logdate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_secrete);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_uname);
            this.Name = "Register";
            this.Text = "Sender_Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_uname;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.TextBox txt_secrete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_Logdate;
        private System.Windows.Forms.Label lbl_logtime;
        private System.Windows.Forms.Label lbl_syslogdate;
        private System.Windows.Forms.Label lbl_syslogtime;
    }
}