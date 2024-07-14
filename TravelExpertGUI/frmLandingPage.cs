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
            DataGridViewButtonColumn deleteColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            _mainDataGridView.Columns.Add(deleteColumn);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (selectedTable)
            {
                case "Packages":
                    System.Diagnostics.Debug.WriteLine("Packages table is selected");
                    break;
                case "ProductsSuppliers":
                    System.Diagnostics.Debug.WriteLine("Products supplier table is selected");
                    frmAddModifyProductsSuppliers frmAddProductsSuppliers = new frmAddModifyProductsSuppliers();
                    DialogResult result = frmAddProductsSuppliers.ShowDialog();
                    if(result == DialogResult.OK)
                    {
                        ProductsSupplier productsSupplier = frmAddProductsSuppliers.ProductsSupplier;
                        ProductsSupplierDB.AddProductSupplier(productsSupplier);
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

        private void DeleteItem(DataGridViewCellEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Delete Button is clicked");
        }

        private void ModifyItem(DataGridViewCellEventArgs e)
        {
            DialogResult? result = null;

            switch (selectedTable)
            {
                case "Products":
                    var productList = (List<Product>)_mainDataGridView.DataSource;
                    var selectedItem = productList[e.RowIndex];
                    var addModifyProductForm = new AddModifyProduct(selectedItem);
                    result = addModifyProductForm.ShowDialog();
                    break;
            }

            if (result == DialogResult.OK)
            {
                updateTableContext(selectedTable);
            }
        }

        // method to add functionality to modify and delete buttons populated in data grid view
        private void _mainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }

            int column_count = _mainDataGridView.Columns.Count;
            // index values for Modify and Delete button columns
            int ModifyIndex = column_count - 2;
            int DeleteIndex = column_count - 1;
            if (e.ColumnIndex == ModifyIndex)
            {
                ModifyItem(e);
            }
            else if (e.ColumnIndex == DeleteIndex) {
                DeleteItem(e);
            }
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
