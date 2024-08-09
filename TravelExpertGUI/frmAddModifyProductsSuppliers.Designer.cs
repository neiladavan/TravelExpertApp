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
            cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProduct.FormattingEnabled = true;
            cboProduct.Location = new Point(132, 23);
            cboProduct.Margin = new Padding(5);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(547, 39);
            cboProduct.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 23);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(99, 31);
            label1.TabIndex = 1;
            label1.Text = "Product:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 79);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(104, 31);
            label2.TabIndex = 2;
            label2.Text = "Supplier:";
            // 
            // cboSupplier
            // 
            cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSupplier.FormattingEnabled = true;
            cboSupplier.Location = new Point(132, 79);
            cboSupplier.Margin = new Padding(5);
            cboSupplier.Name = "cboSupplier";
            cboSupplier.Size = new Size(547, 39);
            cboSupplier.TabIndex = 3;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(214, 132);
            btnAccept.Margin = new Padding(5);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(153, 45);
            btnAccept.TabIndex = 4;
            btnAccept.Text = "&Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(405, 132);
            btnCancel.Margin = new Padding(5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(153, 45);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddModifyProductsSuppliers
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(700, 203);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(cboSupplier);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboProduct);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "frmAddModifyProductsSuppliers";
            StartPosition = FormStartPosition.CenterScreen;
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