namespace Class_Scheduler_By_Nausif_AND_Mohsin
{
    partial class ControlsForm
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
            this.TxtNewPass = new System.Windows.Forms.TextBox();
            this.LblCurrPass = new System.Windows.Forms.Label();
            this.LblNewPass = new System.Windows.Forms.Label();
            this.TxtCurrPass = new System.Windows.Forms.TextBox();
            this.BtnPassUpdate = new System.Windows.Forms.Button();
            this.GBChangePass = new System.Windows.Forms.GroupBox();
            this.BtnControlExit = new System.Windows.Forms.Button();
            this.GBChangePass.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtNewPass
            // 
            this.TxtNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNewPass.Location = new System.Drawing.Point(30, 116);
            this.TxtNewPass.MaxLength = 20;
            this.TxtNewPass.Multiline = true;
            this.TxtNewPass.Name = "TxtNewPass";
            this.TxtNewPass.PasswordChar = '*';
            this.TxtNewPass.Size = new System.Drawing.Size(181, 28);
            this.TxtNewPass.TabIndex = 1;
            // 
            // LblCurrPass
            // 
            this.LblCurrPass.AutoSize = true;
            this.LblCurrPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrPass.Location = new System.Drawing.Point(40, 24);
            this.LblCurrPass.Name = "LblCurrPass";
            this.LblCurrPass.Size = new System.Drawing.Size(158, 17);
            this.LblCurrPass.TabIndex = 2;
            this.LblCurrPass.Text = "Enter Current Password";
            // 
            // LblNewPass
            // 
            this.LblNewPass.AutoSize = true;
            this.LblNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNewPass.Location = new System.Drawing.Point(50, 89);
            this.LblNewPass.Name = "LblNewPass";
            this.LblNewPass.Size = new System.Drawing.Size(138, 17);
            this.LblNewPass.TabIndex = 3;
            this.LblNewPass.Text = "Enter New Password";
            // 
            // TxtCurrPass
            // 
            this.TxtCurrPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCurrPass.Location = new System.Drawing.Point(30, 50);
            this.TxtCurrPass.MaxLength = 20;
            this.TxtCurrPass.Multiline = true;
            this.TxtCurrPass.Name = "TxtCurrPass";
            this.TxtCurrPass.PasswordChar = '*';
            this.TxtCurrPass.Size = new System.Drawing.Size(181, 28);
            this.TxtCurrPass.TabIndex = 4;
            // 
            // BtnPassUpdate
            // 
            this.BtnPassUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPassUpdate.Location = new System.Drawing.Point(56, 165);
            this.BtnPassUpdate.Name = "BtnPassUpdate";
            this.BtnPassUpdate.Size = new System.Drawing.Size(124, 37);
            this.BtnPassUpdate.TabIndex = 5;
            this.BtnPassUpdate.Text = "UPDATE";
            this.BtnPassUpdate.UseVisualStyleBackColor = true;
            this.BtnPassUpdate.Click += new System.EventHandler(this.BtnPassUpdate_Click);
            // 
            // GBChangePass
            // 
            this.GBChangePass.Controls.Add(this.BtnPassUpdate);
            this.GBChangePass.Controls.Add(this.TxtCurrPass);
            this.GBChangePass.Controls.Add(this.LblNewPass);
            this.GBChangePass.Controls.Add(this.LblCurrPass);
            this.GBChangePass.Controls.Add(this.TxtNewPass);
            this.GBChangePass.Location = new System.Drawing.Point(12, 12);
            this.GBChangePass.Name = "GBChangePass";
            this.GBChangePass.Size = new System.Drawing.Size(240, 225);
            this.GBChangePass.TabIndex = 6;
            this.GBChangePass.TabStop = false;
            this.GBChangePass.Text = "Change Pass";
            // 
            // BtnControlExit
            // 
            this.BtnControlExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnControlExit.Location = new System.Drawing.Point(12, 243);
            this.BtnControlExit.Name = "BtnControlExit";
            this.BtnControlExit.Size = new System.Drawing.Size(240, 29);
            this.BtnControlExit.TabIndex = 10;
            this.BtnControlExit.Text = "CLOSE";
            this.BtnControlExit.UseVisualStyleBackColor = true;
            this.BtnControlExit.Click += new System.EventHandler(this.BtnControlExit_Click);
            // 
            // ControlsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 282);
            this.Controls.Add(this.BtnControlExit);
            this.Controls.Add(this.GBChangePass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ControlsForm";
            this.Load += new System.EventHandler(this.ControlsForm_Load);
            this.GBChangePass.ResumeLayout(false);
            this.GBChangePass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox TxtNewPass;
        public System.Windows.Forms.TextBox TxtCurrPass;
        public System.Windows.Forms.GroupBox GBChangePass;
        public System.Windows.Forms.Label LblCurrPass;
        public System.Windows.Forms.Label LblNewPass;
        public System.Windows.Forms.Button BtnPassUpdate;
        public System.Windows.Forms.Button BtnControlExit;
    }
}