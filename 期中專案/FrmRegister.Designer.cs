namespace SelectShop.Views
{
	partial class FrmRegister
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
            this.MBirthday = new System.Windows.Forms.DateTimePicker();
            this.lblMBirthday = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxMPassword = new System.Windows.Forms.TextBox();
            this.tbxMPassConfirm = new System.Windows.Forms.TextBox();
            this.fbMAddress = new SelectShop.Components.FieldBox();
            this.fbMEmail = new SelectShop.Components.FieldBox();
            this.fbMCellphone = new SelectShop.Components.FieldBox();
            this.fbMName = new SelectShop.Components.FieldBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MBirthday
            // 
            this.MBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MBirthday.Location = new System.Drawing.Point(507, 86);
            this.MBirthday.Name = "MBirthday";
            this.MBirthday.Size = new System.Drawing.Size(200, 25);
            this.MBirthday.TabIndex = 7;
            // 
            // lblMBirthday
            // 
            this.lblMBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMBirthday.AutoSize = true;
            this.lblMBirthday.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMBirthday.Location = new System.Drawing.Point(507, 54);
            this.lblMBirthday.Name = "lblMBirthday";
            this.lblMBirthday.Size = new System.Drawing.Size(78, 22);
            this.lblMBirthday.TabIndex = 8;
            this.lblMBirthday.Text = "會員生日";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnConfirm.Location = new System.Drawing.Point(541, 379);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 28);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "確認";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancel.Location = new System.Drawing.Point(632, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(38, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 11;
            this.label1.Text = "會員密碼";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(272, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "確認會員密碼";
            // 
            // tbxMPassword
            // 
            this.tbxMPassword.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxMPassword.Location = new System.Drawing.Point(36, 379);
            this.tbxMPassword.Name = "tbxMPassword";
            this.tbxMPassword.Size = new System.Drawing.Size(188, 30);
            this.tbxMPassword.TabIndex = 13;
            // 
            // tbxMPassConfirm
            // 
            this.tbxMPassConfirm.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbxMPassConfirm.Location = new System.Drawing.Point(272, 379);
            this.tbxMPassConfirm.Name = "tbxMPassConfirm";
            this.tbxMPassConfirm.Size = new System.Drawing.Size(188, 30);
            this.tbxMPassConfirm.TabIndex = 14;
            // 
            // fbMAddress
            // 
            this.fbMAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbMAddress.fieldName = "會員地址";
            this.fbMAddress.fieldValue = "";
            this.fbMAddress.Location = new System.Drawing.Point(36, 270);
            this.fbMAddress.Name = "fbMAddress";
            this.fbMAddress.Size = new System.Drawing.Size(671, 57);
            this.fbMAddress.TabIndex = 4;
            // 
            // fbMEmail
            // 
            this.fbMEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbMEmail.fieldName = "會員電子郵件信箱";
            this.fbMEmail.fieldValue = "";
            this.fbMEmail.Location = new System.Drawing.Point(272, 188);
            this.fbMEmail.Name = "fbMEmail";
            this.fbMEmail.Size = new System.Drawing.Size(435, 57);
            this.fbMEmail.TabIndex = 3;
            // 
            // fbMCellphone
            // 
            this.fbMCellphone.fieldName = "會員手機";
            this.fbMCellphone.fieldValue = "";
            this.fbMCellphone.Location = new System.Drawing.Point(36, 188);
            this.fbMCellphone.Name = "fbMCellphone";
            this.fbMCellphone.Size = new System.Drawing.Size(188, 57);
            this.fbMCellphone.TabIndex = 2;
            // 
            // fbMName
            // 
            this.fbMName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbMName.fieldName = "會員名稱";
            this.fbMName.fieldValue = "";
            this.fbMName.Location = new System.Drawing.Point(272, 54);
            this.fbMName.Name = "fbMName";
            this.fbMName.Size = new System.Drawing.Size(184, 57);
            this.fbMName.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(42, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 145);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbxMPassConfirm);
            this.Controls.Add(this.tbxMPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblMBirthday);
            this.Controls.Add(this.MBirthday);
            this.Controls.Add(this.fbMAddress);
            this.Controls.Add(this.fbMEmail);
            this.Controls.Add(this.fbMCellphone);
            this.Controls.Add(this.fbMName);
            this.Name = "FrmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegister";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private Components.FieldBox fbMName;
		private Components.FieldBox fbMCellphone;
		private Components.FieldBox fbMEmail;
		private Components.FieldBox fbMAddress;
		private System.Windows.Forms.DateTimePicker MBirthday;
		private System.Windows.Forms.Label lblMBirthday;
		private System.Windows.Forms.Button btnConfirm;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbxMPassword;
		private System.Windows.Forms.TextBox tbxMPassConfirm;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}