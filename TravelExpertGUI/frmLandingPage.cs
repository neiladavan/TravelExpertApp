using System.Security.Cryptography;
using System.Text;
using TravelExpertData;
using System.Linq;

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
            panMenu.Dock = DockStyle.Left;
            _mainDataGridView.Columns.Clear();
        }

        private void updateTableContext(string tableName)
        {
            string splitTableName = splitByCapitalLetter(tableName);
            _mainDataGridView.Columns.Clear();
            btnAdd.Text = $"Add {splitTableName}";
            selectedTable = tableName;
            switch (tableName)
            {
                case "Packages":
                    _mainDataGridView.DataSource = PackageDB.GetPackages();
                    _mainDataGridView.Columns[5].DefaultCellStyle.Format = "c";
                    _mainDataGridView.Columns[6].DefaultCellStyle.Format = "c";
                    break;
                case "Products":
                    _mainDataGridView.DataSource = ProductDB.GetProducts();
                    var productSuppliersColumn = _mainDataGridView.Columns.OfType<DataGridViewColumn>().Where(column => column.Name == "ProductsSuppliers").First();
                    if(productSuppliersColumn != null)
                    {
                        _mainDataGridView.Columns.Remove(productSuppliersColumn);
                    }
                    break;
                case "Suppliers":
                    break;
                case "ProductsSuppliers":
                    _mainDataGridView.DataSource = ProductsSupplierDB.GetProductsSuppliersAsNames();
                    break;
                default:
                    break;
            }
            addModifyAndDeleteButtonsToDGV();

            foreach (DataGridViewColumn col in _mainDataGridView.Columns)
            {
                col.HeaderText = splitByCapitalLetter(col.HeaderText);
            }
            _mainDataGridView.AutoResizeColumns();
            btnAdd.Enabled = true;
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
            switch (selectedTable)
            {
                case "Packages":
                    System.Diagnostics.Debug.WriteLine("Packages table is selected");
                    using (frmAddModifyPackage frmAddModifyPackages = new frmAddModifyPackage())
                    {
                        DialogResult result = frmAddModifyPackages.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            // Handle OK result for Packages
                            // Add necessary code here
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
                default:
                    break;
            
            }
            updateTableContext(selectedTable);
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
                        var addModifyProductForm = new AddModifyProduct() { Product = selectedProduct};
                        result = addModifyProductForm.ShowDialog();

                        selectedItem = selectedProduct;

                        break;
                    case "Packages":
                        // Access the DataSource
                        var packageList = (List<PackageDTO>)_mainDataGridView.DataSource;

                        // Get the selected package from the list
                        var selectedPackageDTO = packageList![e.RowIndex];

                        // Open a form to modify the selected package
                        frmAddModifyPackage addModifyForm = new frmAddModifyPackage();

                        addModifyForm.Package = new Package
                        {
                            PackageId = selectedPackageDTO.PackageId,
                            PkgName = selectedPackageDTO.PkgName,
                            PkgStartDate = selectedPackageDTO.PkgStartDate,
                            PkgEndDate = selectedPackageDTO.PkgEndDate,
                            PkgDesc = selectedPackageDTO.PkgDesc,
                            PkgBasePrice = selectedPackageDTO.PkgBasePrice,
                            PkgAgencyCommission = selectedPackageDTO.PkgAgencyCommission
                        };

                        result = addModifyForm.ShowDialog();

                        // Assign the selected item for potential further processing
                        selectedItem = selectedPackageDTO;

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
            if(e.RowIndex < 0) return;

            int column_count = _mainDataGridView.Columns.Count;
            // index values for Modify and Delete button columns
            int ModifyIndex = column_count - 2;
            //int DeleteIndex = column_count - 1;
            
            if (e.ColumnIndex == ModifyIndex) ModifyItem(sender, e, selectedTable);
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
    }
}
