namespace Human_resources_management
{
    partial class frm_Welcome
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
            this.btn_admin_login = new System.Windows.Forms.Button();
            this.btn_employee_login = new System.Windows.Forms.Button();
            this.btn_traffic = new System.Windows.Forms.Button();
            this.lbl_birthday_notice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_admin_login
            // 
            this.btn_admin_login.Location = new System.Drawing.Point(69, 38);
            this.btn_admin_login.Name = "btn_admin_login";
            this.btn_admin_login.Size = new System.Drawing.Size(75, 23);
            this.btn_admin_login.TabIndex = 0;
            this.btn_admin_login.Text = "مدیریت";
            this.btn_admin_login.UseVisualStyleBackColor = true;
            this.btn_admin_login.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_employee_login
            // 
            this.btn_employee_login.Location = new System.Drawing.Point(69, 89);
            this.btn_employee_login.Name = "btn_employee_login";
            this.btn_employee_login.Size = new System.Drawing.Size(75, 23);
            this.btn_employee_login.TabIndex = 1;
            this.btn_employee_login.Text = "اعضا";
            this.btn_employee_login.UseVisualStyleBackColor = true;
            this.btn_employee_login.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_traffic
            // 
            this.btn_traffic.Location = new System.Drawing.Point(69, 140);
            this.btn_traffic.Name = "btn_traffic";
            this.btn_traffic.Size = new System.Drawing.Size(75, 23);
            this.btn_traffic.TabIndex = 2;
            this.btn_traffic.Text = "تردد";
            this.btn_traffic.UseVisualStyleBackColor = true;
            this.btn_traffic.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbl_birthday_notice
            // 
            this.lbl_birthday_notice.AutoSize = true;
            this.lbl_birthday_notice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_birthday_notice.Location = new System.Drawing.Point(12, 177);
            this.lbl_birthday_notice.Name = "lbl_birthday_notice";
            this.lbl_birthday_notice.Size = new System.Drawing.Size(27, 17);
            this.lbl_birthday_notice.TabIndex = 3;
            this.lbl_birthday_notice.Text = "N/A";
            this.lbl_birthday_notice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(218, 203);
            this.Controls.Add(this.lbl_birthday_notice);
            this.Controls.Add(this.btn_traffic);
            this.Controls.Add(this.btn_employee_login);
            this.Controls.Add(this.btn_admin_login);
            this.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(236, 250);
            this.MinimumSize = new System.Drawing.Size(236, 250);
            this.Name = "frm_Welcome";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shetab_Userlogin";
            this.Load += new System.EventHandler(this.Enter_User_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_admin_login;
        private System.Windows.Forms.Button btn_employee_login;
        private System.Windows.Forms.Button btn_traffic;
        private System.Windows.Forms.Label lbl_birthday_notice;
    }
}

