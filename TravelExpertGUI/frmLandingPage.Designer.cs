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
            panMenu.Margin = new Padding(5);
            panMenu.Name = "panMenu";
            panMenu.Size = new Size(239, 671);
            panMenu.TabIndex = 0;
            // 
            // btnPackagesProductsSuppliers
            // 
            btnPackagesProductsSuppliers.Font = new Font("Segoe UI", 19.8000011F);
            btnPackagesProductsSuppliers.Location = new Point(15, 475);
            btnPackagesProductsSuppliers.Margin = new Padding(5);
            btnPackagesProductsSuppliers.Name = "btnPackagesProductsSuppliers";
            btnPackagesProductsSuppliers.Size = new Size(200, 175);
            btnPackagesProductsSuppliers.TabIndex = 4;
            btnPackagesProductsSuppliers.Text = "Package Product Suppliers";
            btnPackagesProductsSuppliers.UseVisualStyleBackColor = true;
            btnPackagesProductsSuppliers.Click += btnPackagesProductsSuppliers_Click;
            // 
            // btnProductsSuppliers
            // 
            btnProductsSuppliers.Font = new Font("Segoe UI", 19F);
            btnProductsSuppliers.Location = new Point(15, 360);
            btnProductsSuppliers.Margin = new Padding(5);
            btnProductsSuppliers.Name = "btnProductsSuppliers";
            btnProductsSuppliers.Size = new Size(200, 100);
            btnProductsSuppliers.TabIndex = 3;
            btnProductsSuppliers.Text = "Products Suppliers";
            btnProductsSuppliers.UseVisualStyleBackColor = true;
            btnProductsSuppliers.Click += btnProductsSuppliers_Click;
            // 
            // btnPackages
            // 
            btnPackages.Font = new Font("Segoe UI", 19F);
            btnPackages.Location = new Point(15, 245);
            btnPackages.Margin = new Padding(5);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(200, 100);
            btnPackages.TabIndex = 2;
            btnPackages.Text = "Packages";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnPackages_Click;
            // 
            // btnProducts
            // 
            btnProducts.Font = new Font("Segoe UI", 19F);
            btnProducts.Location = new Point(15, 130);
            btnProducts.Margin = new Padding(5);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(200, 100);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Font = new Font("Segoe UI", 19F);
            btnSuppliers.Location = new Point(15, 15);
            btnSuppliers.Margin = new Padding(5);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(200, 100);
            btnSuppliers.TabIndex = 0;
            btnSuppliers.Text = "Suppliers";
            btnSuppliers.UseVisualStyleBackColor = true;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 19F);
            btnAdd.Location = new Point(249, 544);
            btnAdd.Margin = new Padding(5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(440, 93);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Button";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 19F);
            btnExit.Location = new Point(843, 544);
            btnExit.Margin = new Padding(5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(406, 93);
            btnExit.TabIndex = 3;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // _mainDataGridView
            // 
            _mainDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _mainDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _mainDataGridView.Location = new Point(249, 14);
            _mainDataGridView.Margin = new Padding(5);
            _mainDataGridView.Name = "_mainDataGridView";
            _mainDataGridView.RowHeadersWidth = 51;
            _mainDataGridView.Size = new Size(1000, 500);
            _mainDataGridView.TabIndex = 4;
            _mainDataGridView.CellClick += _mainDataGridView_CellClick;
            // 
            // frmLandingPage
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1291, 671);
            Controls.Add(_mainDataGridView);
            Controls.Add(btnExit);
            Controls.Add(btnAdd);
            Controls.Add(panMenu);
            Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
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
