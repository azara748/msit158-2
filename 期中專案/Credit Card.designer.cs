namespace 期中專案.付帳
{
    partial class Credit_Card
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.fbPrice = new SelectShop.Components.FieldBox();
            this.fbUsePoint = new SelectShop.Components.FieldBox();
            this.fbAllPoint = new SelectShop.Components.FieldBox();
            this.fbPoint = new SelectShop.Components.FieldBox();
            this.fbTotalPrice = new SelectShop.Components.FieldBox();
            this.fbName = new SelectShop.Components.FieldBox();
            this.fbExpectedPoint = new SelectShop.Components.FieldBox();
            this.fbDeposit = new SelectShop.Components.FieldBox();
            this.fbState = new SelectShop.Components.FieldBox();
            this.fbStateId = new SelectShop.Components.FieldBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(347, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "信用卡1";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(585, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 57);
            this.button1.TabIndex = 3;
            this.button1.Text = "確認付款(Confirm)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(382, 465);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 57);
            this.button2.TabIndex = 4;
            this.button2.Text = "取消(Cancel)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(17, 433);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(771, 2);
            this.label8.TabIndex = 5;
            // 
            // fbPrice
            // 
            this.fbPrice.fieldName = "折抵後消費金額：";
            this.fbPrice.fieldValue = "";
            this.fbPrice.Location = new System.Drawing.Point(26, 346);
            this.fbPrice.Name = "fbPrice";
            this.fbPrice.Size = new System.Drawing.Size(192, 74);
            this.fbPrice.TabIndex = 7;
            // 
            // fbUsePoint
            // 
            this.fbUsePoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fbUsePoint.fieldName = "使用折抵點數：";
            this.fbUsePoint.fieldValue = "";
            this.fbUsePoint.Location = new System.Drawing.Point(554, 196);
            this.fbUsePoint.Name = "fbUsePoint";
            this.fbUsePoint.Size = new System.Drawing.Size(184, 74);
            this.fbUsePoint.TabIndex = 7;
            // 
            // fbAllPoint
            // 
            this.fbAllPoint.fieldName = "目前點數：";
            this.fbAllPoint.fieldValue = "";
            this.fbAllPoint.Location = new System.Drawing.Point(26, 266);
            this.fbAllPoint.Name = "fbAllPoint";
            this.fbAllPoint.Size = new System.Drawing.Size(192, 74);
            this.fbAllPoint.TabIndex = 7;
            // 
            // fbPoint
            // 
            this.fbPoint.fieldName = "此次消費點數：";
            this.fbPoint.fieldValue = "";
            this.fbPoint.Location = new System.Drawing.Point(26, 196);
            this.fbPoint.Name = "fbPoint";
            this.fbPoint.Size = new System.Drawing.Size(192, 74);
            this.fbPoint.TabIndex = 7;
            // 
            // fbTotalPrice
            // 
            this.fbTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbTotalPrice.fieldName = "商品金額：";
            this.fbTotalPrice.fieldValue = "";
            this.fbTotalPrice.Location = new System.Drawing.Point(26, 116);
            this.fbTotalPrice.Name = "fbTotalPrice";
            this.fbTotalPrice.Size = new System.Drawing.Size(726, 74);
            this.fbTotalPrice.TabIndex = 7;
            // 
            // fbProductName
            // 
            this.fbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fbName.fieldName = "商品名稱：";
            this.fbName.fieldValue = "";
            this.fbName.Location = new System.Drawing.Point(26, 36);
            this.fbName.Name = "fbProductName";
            this.fbName.Size = new System.Drawing.Size(726, 74);
            this.fbName.TabIndex = 6;
            // 
            // fbExpectedPoint
            // 
            this.fbExpectedPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fbExpectedPoint.fieldName = "消費後點數：";
            this.fbExpectedPoint.fieldValue = "";
            this.fbExpectedPoint.Location = new System.Drawing.Point(554, 266);
            this.fbExpectedPoint.Name = "fbExpectedPoint";
            this.fbExpectedPoint.Size = new System.Drawing.Size(184, 74);
            this.fbExpectedPoint.TabIndex = 8;
            // 
            // fbDeposit
            // 
            this.fbDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fbDeposit.fieldName = "消費後個人存款：";
            this.fbDeposit.fieldValue = "";
            this.fbDeposit.Location = new System.Drawing.Point(280, 207);
            this.fbDeposit.Name = "fbDeposit";
            this.fbDeposit.Size = new System.Drawing.Size(184, 74);
            this.fbDeposit.TabIndex = 9;
            // 
            // fbState
            // 
            this.fbState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fbState.fieldName = "狀態：";
            this.fbState.fieldValue = "";
            this.fbState.Location = new System.Drawing.Point(554, 346);
            this.fbState.Name = "fbState";
            this.fbState.Size = new System.Drawing.Size(184, 74);
            this.fbState.TabIndex = 9;
            // 
            // fbStateId
            // 
            this.fbStateId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fbStateId.fieldName = "狀態ID：";
            this.fbStateId.fieldValue = "";
            this.fbStateId.Location = new System.Drawing.Point(280, 346);
            this.fbStateId.Name = "fbStateId";
            this.fbStateId.Size = new System.Drawing.Size(184, 74);
            this.fbStateId.TabIndex = 10;
            // 
            // Credit_Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.Controls.Add(this.fbStateId);
            this.Controls.Add(this.fbState);
            this.Controls.Add(this.fbDeposit);
            this.Controls.Add(this.fbExpectedPoint);
            this.Controls.Add(this.fbPrice);
            this.Controls.Add(this.fbUsePoint);
            this.Controls.Add(this.fbAllPoint);
            this.Controls.Add(this.fbPoint);
            this.Controls.Add(this.fbTotalPrice);
            this.Controls.Add(this.fbName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Credit_Card";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit_Card";
            this.Load += new System.EventHandler(this.Credit_Card_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private SelectShop.Components.FieldBox fbName;
        private SelectShop.Components.FieldBox fbTotalPrice;
        private SelectShop.Components.FieldBox fbPoint;
        private SelectShop.Components.FieldBox fbAllPoint;
        private SelectShop.Components.FieldBox fbUsePoint;
        private SelectShop.Components.FieldBox fbPrice;
        private SelectShop.Components.FieldBox fbExpectedPoint;
        private SelectShop.Components.FieldBox fbDeposit;
        private SelectShop.Components.FieldBox fbState;
        private SelectShop.Components.FieldBox fbStateId;
    }
}