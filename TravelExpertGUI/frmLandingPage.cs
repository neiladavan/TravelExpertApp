using System.Security.Cryptography;
using System.Text;
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
            
            foreach(DataGridViewColumn col in _mainDataGridView.Columns)
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
            frmAddModifyItem frmAddModifyItem = new frmAddModifyItem();
            frmAddModifyItem.Text = $"Add {splitByCapitalLetter(selectedTable).ToString()}";
            switch (selectedTable)
            {
                case "Packages":
                    System.Diagnostics.Debug.WriteLine("Packages table is selected");
                    break;
                case "ProductsSuppliers":
                    System.Diagnostics.Debug.WriteLine("Products supplier table is selected");
                    // this should be replaced with a foreach loop on an array?
                    // and all this to its own method
                    Label lblProduct = new Label();
                    lblProduct.AutoSize = true;
                    lblProduct.Text = "Product:";
                    lblProduct.Location = new Point(5, 5);
                    frmAddModifyItem.Controls.Add(lblProduct);
                    
                    List<Product> products = new List<Product>(); 
                    products = ProductDB.GetProducts();
                    ComboBox cboProduct = new ComboBox();
                    cboProduct.DataSource = products;
                    cboProduct.DisplayMember = "ProdName";
                    cboProduct.ValueMember = "ProductId";
                    cboProduct.Width = 300;
                    cboProduct.Location = new Point(70, 5);
                    frmAddModifyItem.Controls.Add(cboProduct);

                    Label lblSupplier = new Label();
                    lblSupplier.AutoSize = true;
                    lblSupplier.Text = "Supplier:";
                    lblSupplier.Location = new Point(5, 70);
                    frmAddModifyItem.Controls.Add(lblSupplier);

                    List<Supplier> suppliers = new List<Supplier>();
                    suppliers = SupplierDB.GetSuppliers();
                    ComboBox cboSupplier = new ComboBox();
                    cboSupplier.DataSource = suppliers;
                    cboSupplier.DisplayMember = "SupName";
                    cboSupplier.ValueMember = "SupplierId";
                    cboSupplier.Width = 300;
                    cboSupplier.Location = new Point(70, 70);
                    frmAddModifyItem.Controls.Add(cboSupplier);

                    frmAddModifyItem.Size = new Size(0, 0);
                    frmAddModifyItem.AutoSize = true;

                    break;
                default:
                    break;
            }
            DialogResult result = frmAddModifyItem.ShowDialog();
        }

        private void DeleteItem()
        {
            System.Diagnostics.Debug.WriteLine("Delete Button is clicked");
        }

        private void ModifyItem()
        {
            System.Diagnostics.Debug.WriteLine("Modify Button is clicked");
        }

        // method to add functionality to modify and delete buttons populated in data grid view
        private void _mainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int column_count = _mainDataGridView.Columns.Count;
            // index values for Modify and Delete button columns
            int ModifyIndex = column_count - 2;
            int DeleteIndex = column_count - 1;

            if (e.RowIndex > -1)  // make sure header row wasn't clicked
            {
                if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
                {
                    DataGridViewCell cell = _mainDataGridView.Rows[e.RowIndex].Cells[0];
                    string itemID = cell.Value?.ToString()?.Trim() ?? "";
                    selectedItem = "";
                }

                if (selectedItem != null)
                {
                    if (e.ColumnIndex == ModifyIndex)
                    {
                        ModifyItem();
                    }
                    else if (e.ColumnIndex == DeleteIndex)
                    {
                        DeleteItem();
                    }
                }
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
    }
}
