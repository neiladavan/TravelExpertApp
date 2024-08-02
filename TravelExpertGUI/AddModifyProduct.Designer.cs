namespace TravelExpertGUI
{
    partial class AddModifyProduct
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
            lblID = new Label();
            lblProdName = new Label();
            txtID = new TextBox();
            txtProdName = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Segoe UI", 13.8F);
            lblID.Location = new Point(75, 38);
            lblID.Margin = new Padding(2, 0, 2, 0);
            lblID.Name = "lblID";
            lblID.Size = new Size(125, 31);
            lblID.TabIndex = 0;
            lblID.Text = "Product Id:";
            // 
            // lblProdName
            // 
            lblProdName.AutoSize = true;
            lblProdName.Font = new Font("Segoe UI", 13.8F);
            lblProdName.Location = new Point(34, 93);
            lblProdName.Margin = new Padding(2, 0, 2, 0);
            lblProdName.Name = "lblProdName";
            lblProdName.Size = new Size(166, 31);
            lblProdName.TabIndex = 1;
            lblProdName.Text = "Product Name:";
            // 
            // txtID
            // 
            txtID.Font = new Font("Segoe UI", 13.8F);
            txtID.Location = new Point(204, 38);
            txtID.Margin = new Padding(2, 2, 2, 2);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(299, 38);
            txtID.TabIndex = 2;
            // 
            // txtProdName
            // 
            txtProdName.Font = new Font("Segoe UI", 13.8F);
            txtProdName.Location = new Point(204, 93);
            txtProdName.Margin = new Padding(2, 2, 2, 2);
            txtProdName.Name = "txtProdName";
            txtProdName.Size = new Size(299, 38);
            txtProdName.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("Segoe UI", 13.8F);
            btnOK.Location = new Point(105, 170);
            btnOK.Margin = new Padding(2, 2, 2, 2);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(132, 49);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 13.8F);
            btnCancel.Location = new Point(279, 169);
            btnCancel.Margin = new Padding(2, 2, 2, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(135, 50);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddModifyProduct
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(529, 235);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtProdName);
            Controls.Add(txtID);
            Controls.Add(lblProdName);
            Controls.Add(lblID);
            Margin = new Padding(2, 2, 2, 2);
            Name = "AddModifyProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add/Modify Products";
            Load += AddModifyProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblID;
        private Label lblProdName;
        private TextBox txtID;
        private TextBox txtProdName;
        private Button btnOK;
        private Button btnCancel;
    }
}