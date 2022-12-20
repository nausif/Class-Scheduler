namespace Class_Scheduler_By_Nausif_AND_Mohsin
{
    partial class Form1
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtb_login = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RBAdmin = new System.Windows.Forms.RadioButton();
            this.RBuser = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtb_Pass = new System.Windows.Forms.TextBox();
            this.RBGuest = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Black;
            this.btnLogin.BackgroundImage = global::Class_Scheduler_By_Nausif_AND_Mohsin.Properties.Resources.NextBtn1;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(322, 346);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(39, 35);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtb_login
            // 
            this.txtb_login.BackColor = System.Drawing.Color.Black;
            this.txtb_login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtb_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_login.ForeColor = System.Drawing.Color.LightGray;
            this.txtb_login.Location = new System.Drawing.Point(93, 292);
            this.txtb_login.MaxLength = 15;
            this.txtb_login.Multiline = true;
            this.txtb_login.Name = "txtb_login";
            this.txtb_login.Size = new System.Drawing.Size(268, 35);
            this.txtb_login.TabIndex = 1;
            this.txtb_login.Text = "Enter name";
            this.txtb_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtb_login.Click += new System.EventHandler(this.txtb_login_Click);
            this.txtb_login.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtb_login_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Class_Scheduler_By_Nausif_AND_Mohsin.Properties.Resources.classScheduler;
            this.pictureBox2.Location = new System.Drawing.Point(41, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(340, 147);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::Class_Scheduler_By_Nausif_AND_Mohsin.Properties.Resources.UserIcon;
            this.pictureBox1.Location = new System.Drawing.Point(58, 292);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // RBAdmin
            // 
            this.RBAdmin.AutoSize = true;
            this.RBAdmin.BackColor = System.Drawing.Color.Transparent;
            this.RBAdmin.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.RBAdmin.Checked = true;
            this.RBAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBAdmin.Location = new System.Drawing.Point(169, 247);
            this.RBAdmin.Name = "RBAdmin";
            this.RBAdmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RBAdmin.Size = new System.Drawing.Size(54, 17);
            this.RBAdmin.TabIndex = 6;
            this.RBAdmin.TabStop = true;
            this.RBAdmin.Text = "Admin";
            this.RBAdmin.UseVisualStyleBackColor = false;
            this.RBAdmin.CheckedChanged += new System.EventHandler(this.RBAdmin_CheckedChanged);
            // 
            // RBuser
            // 
            this.RBuser.AutoSize = true;
            this.RBuser.BackColor = System.Drawing.Color.Transparent;
            this.RBuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBuser.Location = new System.Drawing.Point(229, 247);
            this.RBuser.Name = "RBuser";
            this.RBuser.Size = new System.Drawing.Size(47, 17);
            this.RBuser.TabIndex = 7;
            this.RBuser.Text = "User";
            this.RBuser.UseVisualStyleBackColor = false;
            this.RBuser.CheckedChanged += new System.EventHandler(this.RBAdmin_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Login As:";
            // 
            // txtb_Pass
            // 
            this.txtb_Pass.BackColor = System.Drawing.Color.Black;
            this.txtb_Pass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtb_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_Pass.ForeColor = System.Drawing.Color.LightGray;
            this.txtb_Pass.Location = new System.Drawing.Point(58, 346);
            this.txtb_Pass.MaxLength = 20;
            this.txtb_Pass.Multiline = true;
            this.txtb_Pass.Name = "txtb_Pass";
            this.txtb_Pass.Size = new System.Drawing.Size(265, 35);
            this.txtb_Pass.TabIndex = 10;
            this.txtb_Pass.Text = "Password";
            this.txtb_Pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtb_Pass.Click += new System.EventHandler(this.txtb_Pass_Click);
            // 
            // RBGuest
            // 
            this.RBGuest.AutoSize = true;
            this.RBGuest.BackColor = System.Drawing.Color.Transparent;
            this.RBGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBGuest.Location = new System.Drawing.Point(282, 247);
            this.RBGuest.Name = "RBGuest";
            this.RBGuest.Size = new System.Drawing.Size(53, 17);
            this.RBGuest.TabIndex = 11;
            this.RBGuest.Text = "Guest";
            this.RBGuest.UseVisualStyleBackColor = false;
            this.RBGuest.CheckedChanged += new System.EventHandler(this.RBAdmin_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = global::Class_Scheduler_By_Nausif_AND_Mohsin.Properties.Resources.background_uni;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(426, 441);
            this.Controls.Add(this.RBGuest);
            this.Controls.Add(this.txtb_Pass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RBuser);
            this.Controls.Add(this.RBAdmin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtb_login);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtb_login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtb_Pass;
        public System.Windows.Forms.RadioButton RBAdmin;
        public System.Windows.Forms.RadioButton RBuser;
        public System.Windows.Forms.RadioButton RBGuest;
    }
}

