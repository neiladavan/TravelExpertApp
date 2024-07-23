namespace TravelExpertGUI
{
    partial class AddModifySupplier
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
            btnCancel = new Button();
            btnOK = new Button();
            txtSupName = new TextBox();
            txtSupID = new TextBox();
            lblSupName = new Label();
            lblSupID = new Label();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(474, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(219, 80);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(192, 291);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(215, 78);
            btnOK.TabIndex = 10;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // txtSupName
            // 
            txtSupName.Location = new Point(335, 169);
            txtSupName.Name = "txtSupName";
            txtSupName.Size = new Size(389, 39);
            txtSupName.TabIndex = 9;
            // 
            // txtSupID
            // 
            txtSupID.Location = new Point(335, 80);
            txtSupID.Name = "txtSupID";
            txtSupID.ReadOnly = true;
            txtSupID.Size = new Size(389, 39);
            txtSupID.TabIndex = 8;
            // 
            // lblSupName
            // 
            lblSupName.AutoSize = true;
            lblSupName.Location = new Point(76, 172);
            lblSupName.Name = "lblSupName";
            lblSupName.Size = new Size(178, 32);
            lblSupName.TabIndex = 7;
            lblSupName.Text = "Supplier Name:";
            // 
            // lblSupID
            // 
            lblSupID.AutoSize = true;
            lblSupID.Location = new Point(76, 80);
            lblSupID.Name = "lblSupID";
            lblSupID.Size = new Size(134, 32);
            lblSupID.TabIndex = 6;
            lblSupID.Text = "Supplier Id:";
            // 
            // AddModifySupplier
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtSupName);
            Controls.Add(txtSupID);
            Controls.Add(lblSupName);
            Controls.Add(lblSupID);
            Name = "AddModifySupplier";
            Text = "AddModifySupplier";
            Load += AddModifySupplier_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnOK;
        private TextBox txtSupName;
        private TextBox txtSupID;
        private Label lblSupName;
        private Label lblSupID;
    }
}