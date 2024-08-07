using System.Data;
using System.Text;
using System.Windows.Forms;
using TravelExpertData;

namespace TravelExpertGUI
{
    public partial class frmLandingPage : Form
    {
        // define selectedTable to be used when determining context for which table we're working with
        String selectedTable = null!;

        // selected Item is made generic because we are changing between table contexts.
        Object selectedItem = null!;

        public frmLandingPage()
        {
            InitializeComponent();
        }

        private void frmLandingPage_Load(object sender, EventArgs e)
        {
            // add button default should be disabled since no selected table yet.
            btnAdd.Enabled = false;
            txtSearch.Enabled = false;
            panMenu.Dock = DockStyle.Left;
            _mainDataGridView.Columns.Clear();
        }

        private void updateTableContext(string tableName)
        {
            string splitTableName = splitByCapitalLetter(tableName);
            _mainDataGridView.Columns.Clear();
            btnAdd.Text = $"Add {splitTableName}";
            txtSearch.Text = "";
            selectedTable = tableName;
            try
            {
                switch (tableName)
                {
                    case "Packages":
                        _mainDataGridView.DataSource = PackageDB.GetPackageDTOs();
                        _mainDataGridView.Columns[5].DefaultCellStyle.Format = "c";
                        _mainDataGridView.Columns[6].DefaultCellStyle.Format = "c";
                        break;
                    case "Products":
                        _mainDataGridView.DataSource = ProductDB.GetProducts();
                        var productSuppliersColumn = _mainDataGridView.Columns.OfType<DataGridViewColumn>().Where(column => column.Name == "ProductsSuppliers").First();
                        if (productSuppliersColumn != null)
                        {
                            _mainDataGridView.Columns.Remove(productSuppliersColumn);
                        }
                        break;
                    case "Suppliers":
                        _mainDataGridView.DataSource = SupplierDB.GetSuppliers();
                        var columnsToRemove = _mainDataGridView.Columns.OfType<DataGridViewColumn>().Where(column => column.Name == "ProductsSuppliers" || column.Name == "SupplierContacts").ToList();
                        if (columnsToRemove != null)
                        {   
                            foreach(var column in columnsToRemove)
                            {
                                _mainDataGridView.Columns.Remove(column);
                            }
                        }
                        break;
                    case "ProductsSuppliers":
                        _mainDataGridView.DataSource = ProductsSupplierDB.GetProductsSuppliersAsNames();
                        var productSupplierIdColumn = _mainDataGridView.Columns.OfType<DataGridViewColumn>().Where(column => column.Name == "ProductSupplierId").First();
                        if (productSupplierIdColumn != null)
                        {
                            _mainDataGridView.Columns.Remove(productSupplierIdColumn);
                        }
                        break;
                    case "PackagesProductsSuppliers":
                        _mainDataGridView.DataSource = PackageDB.GetPackagesProductsSuppliers();
                        btnAdd.Text = "Assign Product Suppliers";
                        // Identify columns to be removed
                        var ppsColumn = _mainDataGridView.Columns
                            .OfType<DataGridViewColumn>()
                            .Where(column => column.Name == "PackageId" || column.Name == "ProductSupplierId")
                            .ToList(); // Materialize the collection to avoid modification issues during iteration

                        // Remove identified columns
                        foreach (var column in ppsColumn)
                        {
                            _mainDataGridView.Columns.Remove(column);
                        }
                        _mainDataGridView.Columns[0].HeaderText = "Package Name";
                        break;
                    default:
                        break;
                }
                if (selectedTable != "PackagesProductsSuppliers") // the modify case doesn't make sense here.
                {
                    addModifyAndDeleteButtonsToDGV();
                }
                foreach (DataGridViewColumn col in _mainDataGridView.Columns)
                {
                    col.HeaderText = splitByCapitalLetter(col.HeaderText);
                }
                _mainDataGridView.AutoResizeColumns();
                btnAdd.Enabled = true;
                txtSearch.Enabled = true;

                // Attach the TextChanged event handler for the search box
                // Safely attach the TextChanged event handler for the search box
                txtSearch.TextChanged -= txtSearch_TextChanged; // Always safe to unsubscribe
                txtSearch.TextChanged += txtSearch_TextChanged; // Then subscribe
            }
            catch (Exception ex)
            {
                ErrorExceptionHandler.Handle(ex);

                // Gracefully exit the application
                CleanupAndExit();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // If search text is empty, show all data
                switch (selectedTable)
                {
                    case "Packages":
                        _mainDataGridView.DataSource = PackageDB.GetPackageDTOs();
                        break;
                    case "Products":
                        _mainDataGridView.DataSource = ProductDB.GetProducts();
                        HideUnwantedColumns(_mainDataGridView, new List<string> { "ProductsSuppliers" });
                        break;
                    case "Suppliers":
                        _mainDataGridView.DataSource = SupplierDB.GetSuppliers();
                        HideUnwantedColumns(_mainDataGridView, new List<string> { "ProductsSuppliers", "SupplierContacts" });
                        break;
                    case "ProductsSuppliers":
                        _mainDataGridView.DataSource = ProductsSupplierDB.GetProductsSuppliersAsNames();
                        HideUnwantedColumns(_mainDataGridView, new List<string> { "ProductSupplierId" });
                        break;
                    case "PackagesProductsSuppliers":
                        _mainDataGridView.DataSource = PackageDB.GetPackagesProductsSuppliers();
                        HideUnwantedColumns(_mainDataGridView, new List<string> { "PackageId", "ProductSupplierId" });
                        break;
                }
            }
            else
            {
                // Filter data based on search text
                switch (selectedTable)
                {
                    case "Packages":
                        var packages = PackageDB.GetPackageDTOs();
                        var filteredPackages = packages.Where(p => p.PkgName.ToLower().Contains(searchText) ||
                                                                    p.PkgDesc.ToLower().Contains(searchText) ||
                                                                    p.PackageId.ToString().Contains(searchText)).ToList();
                        _mainDataGridView.DataSource = filteredPackages;
                        break;
                    case "Products":
                        var products = ProductDB.GetProducts();
                        var filteredProducts = products.Where(p => p.ProdName.ToLower().Contains(searchText)).ToList();
                        _mainDataGridView.DataSource = filteredProducts;
                        HideUnwantedColumns(_mainDataGridView, new List<string> { "ProductsSuppliers" });
                        break;
                    case "Suppliers":
                        var suppliers = SupplierDB.GetSuppliers();
                        var filteredSuppliers = suppliers.Where(s => s.SupName.ToLower().Contains(searchText)).ToList();
                        _mainDataGridView.DataSource = filteredSuppliers;
                        HideUnwantedColumns(_mainDataGridView, new List<string> { "ProductsSuppliers", "SupplierContacts" });
                        break;
                    case "ProductsSuppliers":
                        var productSuppliers = ProductsSupplierDB.GetProductsSuppliersAsNames();
                        var filteredProductSuppliers = productSuppliers.Where(ps => ps.ProductName.ToLower().Contains(searchText) ||
                                                                                     ps.SupplierName.ToLower().Contains(searchText)).ToList();
                        _mainDataGridView.DataSource = filteredProductSuppliers;
                        HideUnwantedColumns(_mainDataGridView, new List<string> { "ProductSupplierId" });
                        break;
                    case "PackagesProductsSuppliers":
                        var packagesProductsSuppliers = PackageDB.GetPackagesProductsSuppliers();
                        var filteredPackagesProductsSuppliers = packagesProductsSuppliers.Where(pp => pp.PkgName.ToLower().Contains(searchText) ||
                                                                                                     pp.ProductSupplierName.ToLower().Contains(searchText)).ToList();
                        _mainDataGridView.DataSource = filteredPackagesProductsSuppliers;
                        HideUnwantedColumns(_mainDataGridView, new List<string> { "PackageId", "ProductSupplierId" });
                        break;
                }
            }
            _mainDataGridView.AutoResizeColumns();
        }

        /// <summary>
        /// Hide columns that are not needed on the main data grid view
        /// </summary>
        /// <param name="dataGridView">main data grid view</param>
        /// <param name="columnsToHide">list of columns to be hidden</param>
        private void HideUnwantedColumns(DataGridView dataGridView, List<string> columnsToHide)
        {
            foreach (var columnName in columnsToHide)
            {
                var column = dataGridView.Columns.OfType<DataGridViewColumn>()
                    .FirstOrDefault(col => col.Name == columnName);

                if (column != null)
                {
                    dataGridView.Columns.Remove(column);
                }
            }
        }

        // https://stackoverflow.com/questions/4488969/split-a-string-by-capital-letters Author: Guffa
        private static string splitByCapitalLetter(string originalString)
        {
            string splitOriginalString;
            StringBuilder builder = new StringBuilder();
            foreach (char c in originalString)
            {
                if (Char.IsUpper(c) && builder.Length > 0) builder.Append(' ');
                builder.Append(c);
            }
            splitOriginalString = builder.ToString();
            return splitOriginalString;
        }

        private void addModifyAndDeleteButtonsToDGV()
        {
            // add column for modify button
            DataGridViewButtonColumn modifyColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            _mainDataGridView.Columns.Add(modifyColumn);

            // add column for delete button
            //DataGridViewButtonColumn deleteColumn = new()
            //{
            //    UseColumnTextForButtonValue = true,
            //    HeaderText = "",
            //    Text = "Delete"
            //};
            //_mainDataGridView.Columns.Add(deleteColumn);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                switch (selectedTable)
                {
                    case "Packages":
                        System.Diagnostics.Debug.WriteLine("Packages table is selected");
                        using (frmAddModifyPackage frmAddModifyPackages = new frmAddModifyPackage())
                        {
                            DialogResult result = frmAddModifyPackages.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                Package package = frmAddModifyPackages.Package!;
                                PackageDB.AddPackages(package);
                            }
                        }

                        break;
                    case "ProductsSuppliers":
                        System.Diagnostics.Debug.WriteLine("Products supplier table is selected");
                        using (frmAddModifyProductsSuppliers frmAddModifyProductsSuppliers = new frmAddModifyProductsSuppliers())
                        {
                            DialogResult result = frmAddModifyProductsSuppliers.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                ProductsSupplier productsSupplier = frmAddModifyProductsSuppliers.ProductsSupplier;
                                ProductsSupplierDB.AddProductSupplier(productsSupplier);
                            }
                        }
                        break;
                    case "Products":
                        var addModifyProductForm = new AddModifyProduct();
                        if (addModifyProductForm.ShowDialog() == DialogResult.OK)
                        {
                            updateTableContext("Products");
                        }
                        break;
                    case "Suppliers":
                        var addModifySupplierForm = new AddModifySupplier();
                        if (addModifySupplierForm.ShowDialog() == DialogResult.OK)
                        {
                            updateTableContext("Suppliers");
                        }
                        break;
                    case "PackagesProductsSuppliers":
                        System.Diagnostics.Debug.WriteLine("Packages Products supplier table is selected");
                        using (frmAddModifyPPS frmAddModifyPPS = new frmAddModifyPPS())
                        {
                            DialogResult result = frmAddModifyPPS.ShowDialog();
                        }
                        break;
                    default:
                        break;

                }
                updateTableContext(selectedTable);
            }
            catch (Exception ex)
            {
                ErrorExceptionHandler.Handle(ex);

                // Gracefully exit the application
                CleanupAndExit();
            }
        }

        //private void DeleteItem(object sender, DataGridViewCellEventArgs e, string selectedTable)
        //{
        //    System.Diagnostics.Debug.WriteLine("Delete Button is clicked");
        //}

        private void ModifyItem(object sender, DataGridViewCellEventArgs e, string selectedTable)
        {
            DialogResult? result = null;

            // Access the DataGridView
            DataGridView? dataGridView = sender as DataGridView;

            if (dataGridView != null && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                switch (selectedTable)
                {
                    case "Products":
                        var productList = (List<Product>)_mainDataGridView.DataSource;
                        Product selectedProduct = productList[e.RowIndex];
                        var addModifyProductForm = new AddModifyProduct() { Product = selectedProduct };
                        result = addModifyProductForm.ShowDialog();
                        break;
                    case "Suppliers":
                        var supplierList = (List<Supplier>)_mainDataGridView.DataSource;
                        var selectedSupplier = supplierList[e.RowIndex];
                        var addModifySupplierForm = new AddModifySupplier() { Supplier = selectedSupplier };
                        result = addModifySupplierForm.ShowDialog();
                        break;
                    case "Packages":
                        // Access the DataSource
                        var packageList = (List<PackageDTO>)_mainDataGridView.DataSource;

                        PackageDTO selectedPackageDTO = packageList![e.RowIndex];
                        Package selectedPackage = PackageDB.GetPackageFromDTO(selectedPackageDTO)!;

                        // create object for package
                        var addModifyForm = new frmAddModifyPackage() { Package = selectedPackage };

                        // Open a form to modify the selected package
                        result = addModifyForm.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            Package package = addModifyForm.Package;
                            PackageDB.ModifyPackages(package);
                        }

                        // Assign the selected item for potential further processing
                        selectedItem = selectedPackageDTO;

                        break;
                    case "ProductsSuppliers":
                        var productsSuppliersList = (List<ProductsSupplierDTO>)_mainDataGridView.DataSource;
                        ProductsSupplierDTO selectedProductsSupplierDTO = productsSuppliersList![e.RowIndex];
                        ProductsSupplier selectedProductsSupplier = ProductsSupplierDB.GetProductsSupplierFromDTO(selectedProductsSupplierDTO)!;
                        var modifyProductsSuppliersForm = new frmAddModifyProductsSuppliers() { ProductsSupplier = selectedProductsSupplier };
                        result = modifyProductsSuppliersForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            ProductsSupplier productsSupplier = modifyProductsSuppliersForm.ProductsSupplier;
                            ProductsSupplierDB.ModifyProductSupplier(productsSupplier);
                        }
                        selectedItem = selectedProductsSupplier;
                        break;
                    default:
                        break;
                }

                if (result == DialogResult.OK)
                {
                    updateTableContext(selectedTable);
                }
            }
        }

        // method to add functionality to modify and delete buttons populated in data grid view
        private void _mainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get the clicked column
            DataGridViewColumn column = _mainDataGridView.Columns[e.ColumnIndex];

            if (column is DataGridViewButtonColumn buttonColumn)
            {
                if (buttonColumn.Text == "Modify")
                {
                    ModifyItem(sender, e, selectedTable);
                }
            }

            //int column_count = _mainDataGridView.Columns.Count;
            // index values for Modify and Delete button columns
            //int ModifyIndex = column_count - 1;
            //int DeleteIndex = column_count - 1;

            //if (e.ColumnIndex == ModifyIndex) ModifyItem(sender, e, selectedTable);
            //else if (e.ColumnIndex == DeleteIndex) DeleteItem(sender, e, selectedTable);
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            updateTableContext("Packages");
        }
        private void btnProductsSuppliers_Click(object sender, EventArgs e)
        {
            updateTableContext("ProductsSuppliers");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            updateTableContext("Products");
        }

        private void btnPackagesProductsSuppliers_Click(object sender, EventArgs e)
        {
            updateTableContext("PackagesProductsSuppliers");
        }

        private static void CleanupAndExit()
        {
            // Notify the user about the issue
            MessageBox.Show("An unexpected error occurred. The application will now exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Exit the application
            Application.Exit();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            updateTableContext("Suppliers");
        }
    }
}
