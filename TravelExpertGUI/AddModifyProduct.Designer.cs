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
            lblID.Location = new Point(55, 61);
            lblID.Name = "lblID";
            lblID.Size = new Size(128, 32);
            lblID.TabIndex = 0;
            lblID.Text = "Product Id:";
            // 
            // lblProdName
            // 
            lblProdName.AutoSize = true;
            lblProdName.Location = new Point(55, 153);
            lblProdName.Name = "lblProdName";
            lblProdName.Size = new Size(172, 32);
            lblProdName.TabIndex = 1;
            lblProdName.Text = "Product Name:";
            // 
            // txtID
            // 
            txtID.Location = new Point(314, 61);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(389, 39);
            txtID.TabIndex = 2;
            // 
            // txtProdName
            // 
            txtProdName.Location = new Point(314, 150);
            txtProdName.Name = "txtProdName";
            txtProdName.Size = new Size(389, 39);
            txtProdName.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(171, 272);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(215, 78);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(453, 271);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(219, 80);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddModifyProduct
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(808, 432);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtProdName);
            Controls.Add(txtID);
            Controls.Add(lblProdName);
            Controls.Add(lblID);
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