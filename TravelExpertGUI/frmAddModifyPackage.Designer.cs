
namespace TravelExpertGUI
{
    partial class frmAddModifyPackage
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtPackageId = new TextBox();
            txtPackageName = new TextBox();
            txtPackageStartDate = new TextBox();
            txtPackageEndDate = new TextBox();
            txtPackageDesc = new TextBox();
            txtPackageBasePrice = new TextBox();
            txtPackageAgencyCommission = new TextBox();
            btnConfirm = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 33);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 0;
            label1.Text = "Package Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 72);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 1;
            label2.Text = "Package Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 109);
            label3.Name = "label3";
            label3.Size = new Size(137, 20);
            label3.TabIndex = 2;
            label3.Text = "Package Start Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 154);
            label4.Name = "label4";
            label4.Size = new Size(131, 20);
            label4.TabIndex = 3;
            label4.Text = "Package End Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 201);
            label5.Name = "label5";
            label5.Size = new Size(146, 20);
            label5.TabIndex = 4;
            label5.Text = "Package Description:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 248);
            label6.Name = "label6";
            label6.Size = new Size(137, 20);
            label6.TabIndex = 5;
            label6.Text = "Package Base Price:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 297);
            label7.Name = "label7";
            label7.Size = new Size(204, 20);
            label7.TabIndex = 6;
            label7.Text = "Package Agency Commission:";
            // 
            // txtPackageId
            // 
            txtPackageId.Location = new Point(255, 26);
            txtPackageId.Name = "txtPackageId";
            txtPackageId.Size = new Size(112, 27);
            txtPackageId.TabIndex = 7;
            // 
            // txtPackageName
            // 
            txtPackageName.Location = new Point(255, 65);
            txtPackageName.Name = "txtPackageName";
            txtPackageName.Size = new Size(351, 27);
            txtPackageName.TabIndex = 8;
            // 
            // txtPackageStartDate
            // 
            txtPackageStartDate.Location = new Point(255, 106);
            txtPackageStartDate.Name = "txtPackageStartDate";
            txtPackageStartDate.Size = new Size(162, 27);
            txtPackageStartDate.TabIndex = 9;
            // 
            // txtPackageEndDate
            // 
            txtPackageEndDate.Location = new Point(255, 147);
            txtPackageEndDate.Name = "txtPackageEndDate";
            txtPackageEndDate.Size = new Size(162, 27);
            txtPackageEndDate.TabIndex = 10;
            // 
            // txtPackageDesc
            // 
            txtPackageDesc.Location = new Point(255, 194);
            txtPackageDesc.Name = "txtPackageDesc";
            txtPackageDesc.Size = new Size(351, 27);
            txtPackageDesc.TabIndex = 11;
            // 
            // txtPackageBasePrice
            // 
            txtPackageBasePrice.Location = new Point(255, 241);
            txtPackageBasePrice.Name = "txtPackageBasePrice";
            txtPackageBasePrice.Size = new Size(112, 27);
            txtPackageBasePrice.TabIndex = 12;
            // 
            // txtPackageAgencyCommission
            // 
            txtPackageAgencyCommission.Location = new Point(255, 290);
            txtPackageAgencyCommission.Name = "txtPackageAgencyCommission";
            txtPackageAgencyCommission.Size = new Size(112, 27);
            txtPackageAgencyCommission.TabIndex = 13;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(103, 381);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 14;
            btnConfirm.Text = "&Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(512, 381);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 15;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // frmAddModifyPackage
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(703, 437);
            Controls.Add(btnExit);
            Controls.Add(btnConfirm);
            Controls.Add(txtPackageAgencyCommission);
            Controls.Add(txtPackageBasePrice);
            Controls.Add(txtPackageDesc);
            Controls.Add(txtPackageEndDate);
            Controls.Add(txtPackageStartDate);
            Controls.Add(txtPackageName);
            Controls.Add(txtPackageId);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmAddModifyPackage";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmAddModifyPackages_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtPackageId;
        private TextBox txtPackageName;
        private TextBox txtPackageStartDate;
        private TextBox txtPackageEndDate;
        private TextBox txtPackageDesc;
        private TextBox txtPackageBasePrice;
        private TextBox txtPackageAgencyCommission;
        private Button btnConfirm;
        private Button btnExit;
    }
}