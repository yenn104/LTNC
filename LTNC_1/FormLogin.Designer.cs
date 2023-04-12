namespace LTNC_1
{
    partial class FormLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnForgot = new System.Windows.Forms.Button();
            this.cbPass = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnForgot);
            this.panel1.Controls.Add(this.cbPass);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.txtAcc);
            this.panel1.Location = new System.Drawing.Point(200, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 408);
            this.panel1.TabIndex = 4;
            // 
            // btnForgot
            // 
            this.btnForgot.BackColor = System.Drawing.Color.Transparent;
            this.btnForgot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnForgot.Font = new System.Drawing.Font("Cambria", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgot.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnForgot.Location = new System.Drawing.Point(94, 303);
            this.btnForgot.Name = "btnForgot";
            this.btnForgot.Size = new System.Drawing.Size(182, 39);
            this.btnForgot.TabIndex = 29;
            this.btnForgot.Text = "Quên mật khẩu";
            this.btnForgot.UseVisualStyleBackColor = false;
            this.btnForgot.Click += new System.EventHandler(this.btnForgot_Click);
            // 
            // cbPass
            // 
            this.cbPass.AutoSize = true;
            this.cbPass.BackColor = System.Drawing.Color.Transparent;
            this.cbPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPass.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPass.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cbPass.Location = new System.Drawing.Point(386, 375);
            this.cbPass.Name = "cbPass";
            this.cbPass.Size = new System.Drawing.Size(154, 27);
            this.cbPass.TabIndex = 27;
            this.cbPass.Text = "Xem mật khẩu";
            this.cbPass.UseVisualStyleBackColor = false;
            this.cbPass.CheckedChanged += new System.EventHandler(this.cbPass_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Cambria", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnExit.Location = new System.Drawing.Point(282, 303);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(166, 39);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogin.Location = new System.Drawing.Point(94, 206);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(354, 54);
            this.btnLogin.TabIndex = 26;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtPass.Location = new System.Drawing.Point(94, 128);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(354, 34);
            this.txtPass.TabIndex = 25;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // txtAcc
            // 
            this.txtAcc.Font = new System.Drawing.Font("Cambria", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtAcc.Location = new System.Drawing.Point(94, 63);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(354, 34);
            this.txtAcc.TabIndex = 24;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LTNC_1.Properties.Resources.pexels_richa_sharma_4217463;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 592);
            this.Controls.Add(this.panel1);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "nhap";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.Button btnForgot;
        private System.Windows.Forms.CheckBox cbPass;
    }
}