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
            btnCancel.Font = new Font("Segoe UI", 13.8F);
            btnCancel.Location = new Point(257, 146);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(135, 50);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("Segoe UI", 13.8F);
            btnOK.Location = new Point(83, 147);
            btnOK.Margin = new Padding(2);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(132, 49);
            btnOK.TabIndex = 10;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // txtSupName
            // 
            txtSupName.Font = new Font("Segoe UI", 13.8F);
            txtSupName.Location = new Point(201, 86);
            txtSupName.Margin = new Padding(2);
            txtSupName.Name = "txtSupName";
            txtSupName.Size = new Size(241, 38);
            txtSupName.TabIndex = 9;
            // 
            // txtSupID
            // 
            txtSupID.Font = new Font("Segoe UI", 13.8F);
            txtSupID.Location = new Point(201, 30);
            txtSupID.Margin = new Padding(2);
            txtSupID.Name = "txtSupID";
            txtSupID.ReadOnly = true;
            txtSupID.Size = new Size(241, 38);
            txtSupID.TabIndex = 8;
            // 
            // lblSupName
            // 
            lblSupName.AutoSize = true;
            lblSupName.Font = new Font("Segoe UI", 13.8F);
            lblSupName.Location = new Point(26, 89);
            lblSupName.Margin = new Padding(2, 0, 2, 0);
            lblSupName.Name = "lblSupName";
            lblSupName.Size = new Size(171, 31);
            lblSupName.TabIndex = 7;
            lblSupName.Text = "Supplier Name:";
            // 
            // lblSupID
            // 
            lblSupID.AutoSize = true;
            lblSupID.Font = new Font("Segoe UI", 13.8F);
            lblSupID.Location = new Point(67, 30);
            lblSupID.Margin = new Padding(2, 0, 2, 0);
            lblSupID.Name = "lblSupID";
            lblSupID.Size = new Size(130, 31);
            lblSupID.TabIndex = 6;
            lblSupID.Text = "Supplier Id:";
            // 
            // AddModifySupplier
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(462, 219);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtSupName);
            Controls.Add(txtSupID);
            Controls.Add(lblSupName);
            Controls.Add(lblSupID);
            Margin = new Padding(2);
            Name = "AddModifySupplier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add/Modify Supplier";
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