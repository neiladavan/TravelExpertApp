namespace TravelExpertGUI
{
    public partial class frmLandingPage : Form
    {
        private ITableContext? _currentTableContext;

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

        private void SetTableContext(ITableContext tableContext)
        {
            try
            {
                _currentTableContext = tableContext;
                _currentTableContext.UpdateTable(_mainDataGridView, txtSearch, btnAdd);
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

            if (_currentTableContext != null)
            {
                _currentTableContext.Search(_mainDataGridView, searchText);
            }

            _mainDataGridView.AutoResizeColumns();
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            SetTableContext(new PackagesContext());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            SetTableContext(new ProductsContext());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            SetTableContext(new SuppliersContext());
        }

        private void btnProductsSuppliers_Click(object sender, EventArgs e)
        {
            SetTableContext(new ProductsSuppliersContext());
        }

        private void btnPackagesProductsSuppliers_Click(object sender, EventArgs e)
        {
            SetTableContext(new PackagesProductsSuppliersContext());
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _currentTableContext?.Add();
                _currentTableContext?.UpdateTable(_mainDataGridView, txtSearch, btnAdd);
            }
            catch (Exception ex)
            {
                ErrorExceptionHandler.Handle(ex);

                // Gracefully exit the application
                CleanupAndExit();
            }
        }

        private void ModifyItem(object sender, DataGridViewCellEventArgs e)
        {
            // Access the DataGridView
            DataGridView? dataGridView = sender as DataGridView;

            if (dataGridView != null && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _currentTableContext?.Modify(dataGridView, e);
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
                    ModifyItem(sender, e);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void CleanupAndExit()
        {
            // Notify the user about the issue
            MessageBox.Show("An unexpected error occurred. The application will now exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Exit the application
            Application.Exit();
        }
    }
}
