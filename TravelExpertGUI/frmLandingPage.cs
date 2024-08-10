namespace TravelExpertGUI
{
    public partial class frmLandingPage : Form
    {
        private ITableContext? _currentTableContext;

        public frmLandingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the frmLandingPage form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void frmLandingPage_Load(object sender, EventArgs e)
        {
            // add button default should be disabled since no selected table yet.
            btnAdd.Enabled = false;
            txtSearch.Enabled = false;
            panMenu.Dock = DockStyle.Left;
            _mainDataGridView.Columns.Clear();
        }

        /// <summary>
        /// Sets the table context and updates the DataGridView with the selected table's data.
        /// </summary>
        /// <param name="tableContext">The context of the selected table.</param>
        private void SetTableContext(ITableContext tableContext)
        {
            try
            {
                _mainDataGridView.Columns.Clear();
                _currentTableContext = tableContext;
                _currentTableContext.UpdateTable(_mainDataGridView, txtSearch, btnAdd);
                _mainDataGridView.AutoResizeColumns();

                txtSearch.Text = "";
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

        /// <summary>
        /// Handles the TextChanged event of the txtSearch TextBox to filter the DataGridView based on search input.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            if (_currentTableContext != null)
            {
                _currentTableContext.Search(_mainDataGridView, searchText);
            }

            _mainDataGridView.AutoResizeColumns();
        }

        /// <summary>
        /// Handles the Click event of the btnPackages button to set the context to Packages.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnPackages_Click(object sender, EventArgs e)
        {
            SetTableContext(new PackagesContext());
        }

        /// <summary>
        /// Handles the Click event of the btnProducts button to set the context to Products.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnProducts_Click(object sender, EventArgs e)
        {
            SetTableContext(new ProductsContext());
        }

        /// <summary>
        /// Handles the Click event of the btnSuppliers button to set the context to Suppliers.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            SetTableContext(new SuppliersContext());
        }

        /// <summary>
        /// Handles the Click event of the btnProductsSuppliers button to set the context to Product Suppliers.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnProductsSuppliers_Click(object sender, EventArgs e)
        {
            SetTableContext(new ProductsSuppliersContext());
        }

        /// <summary>
        /// Handles the Click event of the btnPackagesProductsSuppliers button to set the context to Packages Products Suppliers.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnPackagesProductsSuppliers_Click(object sender, EventArgs e)
        {
            SetTableContext(new PackagesProductsSuppliersContext());
        }

        /// <summary>
        /// Handles the Click event of the btnAdd button to add a new entry to the current table.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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

        /// <summary>
        /// Modifies the selected item in the DataGridView.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ModifyItem(object sender, DataGridViewCellEventArgs e)
        {
            // Access the DataGridView
            DataGridView? dataGridView = sender as DataGridView;

            if (dataGridView != null && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _currentTableContext?.Modify(dataGridView, e);
                _mainDataGridView.Columns.Clear();
                _currentTableContext?.UpdateTable(_mainDataGridView, txtSearch, btnAdd);
                _mainDataGridView.AutoResizeColumns();
            }
        }

        // method to add functionality to modify and delete buttons populated in data grid view
        /// <summary>
        /// Handles the CellClick event of the DataGridView to execute modify or delete operations.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void _mainDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

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

        /// <summary>
        /// Handles the Click event of the btnExit button to close the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Cleans up resources and exits the application gracefully in case of an error.
        /// </summary>
        private static void CleanupAndExit()
        {
            // Notify the user about the issue
            MessageBox.Show("An unexpected error occurred. The application will now exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Exit the application
            Application.Exit();
        }
    }
}
