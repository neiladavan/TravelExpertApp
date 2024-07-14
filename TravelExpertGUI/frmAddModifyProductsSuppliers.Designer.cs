namespace TravelExpertGUI
{
    partial class frmAddModifyProductsSuppliers
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
            cboProduct = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cboSupplier = new ComboBox();
            btnAccept = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cboProduct
            // 
            cboProduct.FormattingEnabled = true;
            cboProduct.Location = new Point(81, 15);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(338, 28);
            cboProduct.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 15);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 1;
            label1.Text = "Product:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 51);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 2;
            label2.Text = "Supplier:";
            // 
            // cboSupplier
            // 
            cboSupplier.FormattingEnabled = true;
            cboSupplier.Location = new Point(81, 51);
            cboSupplier.Name = "cboSupplier";
            cboSupplier.Size = new Size(338, 28);
            cboSupplier.TabIndex = 3;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(132, 85);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(94, 29);
            btnAccept.TabIndex = 4;
            btnAccept.Text = "&Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(249, 85);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddModifyProductsSuppliers
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(431, 131);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(cboSupplier);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboProduct);
            Name = "frmAddModifyProductsSuppliers";
            Text = "Form1";
            Load += frmAddModifyProductsSuppliers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboProduct;
        private Label label1;
        private Label label2;
        private ComboBox cboSupplier;
        private Button btnAccept;
        private Button btnCancel;
    }
}