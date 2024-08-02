namespace TravelExpertGUI
{
    partial class frmAddModifyPPS
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
            lstProductSuppliersAvailable = new ListBox();
            lstProductSuppliersAssigned = new ListBox();
            label1 = new Label();
            cboPackages = new ComboBox();
            btnAccept = new Button();
            btnCancel = new Button();
            btnAddAll = new Button();
            btnAddSelected = new Button();
            btnRemoveSelected = new Button();
            btnRemoveAll = new Button();
            lblAvailablePS = new Label();
            lblAssignedPS = new Label();
            SuspendLayout();
            // 
            // lstProductSuppliersAvailable
            // 
            lstProductSuppliersAvailable.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstProductSuppliersAvailable.FormattingEnabled = true;
            lstProductSuppliersAvailable.ItemHeight = 31;
            lstProductSuppliersAvailable.Location = new Point(20, 115);
            lstProductSuppliersAvailable.Margin = new Padding(5, 5, 5, 5);
            lstProductSuppliersAvailable.Name = "lstProductSuppliersAvailable";
            lstProductSuppliersAvailable.SelectionMode = SelectionMode.MultiSimple;
            lstProductSuppliersAvailable.Size = new Size(529, 376);
            lstProductSuppliersAvailable.TabIndex = 0;
            // 
            // lstProductSuppliersAssigned
            // 
            lstProductSuppliersAssigned.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstProductSuppliersAssigned.FormattingEnabled = true;
            lstProductSuppliersAssigned.ItemHeight = 31;
            lstProductSuppliersAssigned.Location = new Point(670, 115);
            lstProductSuppliersAssigned.Margin = new Padding(5, 5, 5, 5);
            lstProductSuppliersAssigned.Name = "lstProductSuppliersAssigned";
            lstProductSuppliersAssigned.SelectionMode = SelectionMode.MultiSimple;
            lstProductSuppliersAssigned.Size = new Size(529, 376);
            lstProductSuppliersAssigned.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 16);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(165, 31);
            label1.TabIndex = 2;
            label1.Text = "Select Package";
            // 
            // cboPackages
            // 
            cboPackages.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboPackages.FormattingEnabled = true;
            cboPackages.Location = new Point(203, 11);
            cboPackages.Margin = new Padding(5, 5, 5, 5);
            cboPackages.Name = "cboPackages";
            cboPackages.Size = new Size(420, 39);
            cboPackages.TabIndex = 3;
            cboPackages.SelectedIndexChanged += cboPackages_SelectedIndexChanged;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(398, 502);
            btnAccept.Margin = new Padding(5, 5, 5, 5);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(153, 45);
            btnAccept.TabIndex = 4;
            btnAccept.Text = "&Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(670, 502);
            btnCancel.Margin = new Padding(5, 5, 5, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(153, 45);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAddAll
            // 
            btnAddAll.Location = new Point(561, 178);
            btnAddAll.Margin = new Padding(5, 5, 5, 5);
            btnAddAll.Name = "btnAddAll";
            btnAddAll.Size = new Size(99, 45);
            btnAddAll.TabIndex = 6;
            btnAddAll.Text = ">>";
            btnAddAll.UseVisualStyleBackColor = true;
            btnAddAll.Click += btnAddAll_Click;
            // 
            // btnAddSelected
            // 
            btnAddSelected.Location = new Point(561, 232);
            btnAddSelected.Margin = new Padding(5, 5, 5, 5);
            btnAddSelected.Name = "btnAddSelected";
            btnAddSelected.Size = new Size(99, 45);
            btnAddSelected.TabIndex = 7;
            btnAddSelected.Text = ">";
            btnAddSelected.UseVisualStyleBackColor = true;
            btnAddSelected.Click += btnAddSelected_Click;
            // 
            // btnRemoveSelected
            // 
            btnRemoveSelected.Location = new Point(561, 287);
            btnRemoveSelected.Margin = new Padding(5, 5, 5, 5);
            btnRemoveSelected.Name = "btnRemoveSelected";
            btnRemoveSelected.Size = new Size(99, 45);
            btnRemoveSelected.TabIndex = 8;
            btnRemoveSelected.Text = "<";
            btnRemoveSelected.UseVisualStyleBackColor = true;
            btnRemoveSelected.Click += btnRemoveSelected_Click;
            // 
            // btnRemoveAll
            // 
            btnRemoveAll.Location = new Point(561, 341);
            btnRemoveAll.Margin = new Padding(5, 5, 5, 5);
            btnRemoveAll.Name = "btnRemoveAll";
            btnRemoveAll.Size = new Size(99, 45);
            btnRemoveAll.TabIndex = 9;
            btnRemoveAll.Text = "<<";
            btnRemoveAll.UseVisualStyleBackColor = true;
            btnRemoveAll.Click += btnRemoveAll_Click;
            // 
            // lblAvailablePS
            // 
            lblAvailablePS.AutoSize = true;
            lblAvailablePS.Location = new Point(20, 79);
            lblAvailablePS.Margin = new Padding(5, 0, 5, 0);
            lblAvailablePS.Name = "lblAvailablePS";
            lblAvailablePS.Size = new Size(305, 31);
            lblAvailablePS.TabIndex = 10;
            lblAvailablePS.Text = "Available Products Suppliers";
            // 
            // lblAssignedPS
            // 
            lblAssignedPS.AutoSize = true;
            lblAssignedPS.Location = new Point(670, 79);
            lblAssignedPS.Margin = new Padding(5, 0, 5, 0);
            lblAssignedPS.Name = "lblAssignedPS";
            lblAssignedPS.Size = new Size(295, 31);
            lblAssignedPS.TabIndex = 11;
            lblAssignedPS.Text = "Assigned Product Suppliers";
            // 
            // frmAddModifyPPS
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(1230, 578);
            Controls.Add(lblAssignedPS);
            Controls.Add(lblAvailablePS);
            Controls.Add(btnRemoveAll);
            Controls.Add(btnRemoveSelected);
            Controls.Add(btnAddSelected);
            Controls.Add(btnAddAll);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(cboPackages);
            Controls.Add(label1);
            Controls.Add(lstProductSuppliersAssigned);
            Controls.Add(lstProductSuppliersAvailable);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 5, 5, 5);
            Name = "frmAddModifyPPS";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Assign Product Suppliers";
            Load += frmAddModifyPPS_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstProductSuppliersAvailable;
        private ListBox lstProductSuppliersAssigned;
        private Label label1;
        private ComboBox cboPackages;
        private Button btnAccept;
        private Button btnCancel;
        private Button btnAddAll;
        private Button btnAddSelected;
        private Button btnRemoveSelected;
        private Button btnRemoveAll;
        private Label lblAvailablePS;
        private Label lblAssignedPS;
    }
}