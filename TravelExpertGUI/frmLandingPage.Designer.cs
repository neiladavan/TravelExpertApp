namespace TravelExpertGUI
{
    partial class frmLandingPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panMenu = new Panel();
            btnPackagesProductsSuppliers = new Button();
            btnProductsSuppliers = new Button();
            btnPackages = new Button();
            btnProducts = new Button();
            btnSuppliers = new Button();
            btnAdd = new Button();
            btnExit = new Button();
            _mainDataGridView = new DataGridView();
            panMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_mainDataGridView).BeginInit();
            SuspendLayout();
            // 
            // panMenu
            // 
            panMenu.BackColor = Color.SteelBlue;
            panMenu.Controls.Add(btnPackagesProductsSuppliers);
            panMenu.Controls.Add(btnProductsSuppliers);
            panMenu.Controls.Add(btnPackages);
            panMenu.Controls.Add(btnProducts);
            panMenu.Controls.Add(btnSuppliers);
            panMenu.Dock = DockStyle.Left;
            panMenu.Location = new Point(0, 0);
            panMenu.Name = "panMenu";
            panMenu.Size = new Size(122, 450);
            panMenu.TabIndex = 0;
            // 
            // btnPackagesProductsSuppliers
            // 
            btnPackagesProductsSuppliers.Location = new Point(12, 315);
            btnPackagesProductsSuppliers.Name = "btnPackagesProductsSuppliers";
            btnPackagesProductsSuppliers.Size = new Size(94, 77);
            btnPackagesProductsSuppliers.TabIndex = 4;
            btnPackagesProductsSuppliers.Text = "Package Product Suppliers";
            btnPackagesProductsSuppliers.UseVisualStyleBackColor = true;
            btnPackagesProductsSuppliers.Click += btnPackagesProductsSuppliers_Click;
            // 
            // btnProductsSuppliers
            // 
            btnProductsSuppliers.Location = new Point(12, 224);
            btnProductsSuppliers.Name = "btnProductsSuppliers";
            btnProductsSuppliers.Size = new Size(94, 50);
            btnProductsSuppliers.TabIndex = 3;
            btnProductsSuppliers.Text = "Products Suppliers";
            btnProductsSuppliers.UseVisualStyleBackColor = true;
            btnProductsSuppliers.Click += btnProductsSuppliers_Click;
            // 
            // btnPackages
            // 
            btnPackages.Location = new Point(12, 157);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(94, 30);
            btnPackages.TabIndex = 2;
            btnPackages.Text = "Packages";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnPackages_Click;
            // 
            // btnProducts
            // 
            btnProducts.Location = new Point(12, 87);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(94, 30);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Location = new Point(12, 21);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(94, 30);
            btnSuppliers.TabIndex = 0;
            btnSuppliers.Text = "Suppliers";
            btnSuppliers.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(128, 336);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(330, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Button";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(702, 421);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 3;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // _mainDataGridView
            // 
            _mainDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _mainDataGridView.Location = new Point(125, 0);
            _mainDataGridView.Name = "_mainDataGridView";
            _mainDataGridView.RowHeadersWidth = 51;
            _mainDataGridView.Size = new Size(671, 330);
            _mainDataGridView.TabIndex = 4;
            _mainDataGridView.CellClick += _mainDataGridView_CellClick;
            // 
            // frmLandingPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_mainDataGridView);
            Controls.Add(btnExit);
            Controls.Add(btnAdd);
            Controls.Add(panMenu);
            Name = "frmLandingPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Travel Expert App";
            Load += frmLandingPage_Load;
            panMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_mainDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panMenu;
        private Button btnPackages;
        private Button btnProducts;
        private Button btnSuppliers;
        private Button btnAdd;
        private Button btnExit;
        private DataGridView _mainDataGridView;
        private Button btnProductsSuppliers;
        private Button btnPackagesProductsSuppliers;
    }
}
