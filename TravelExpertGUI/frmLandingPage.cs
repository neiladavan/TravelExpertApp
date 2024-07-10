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

        private void btnPackages_Click(object sender, EventArgs e)
        {
            updateTableContext("Packages");
        }

        private void updateTableContext(string tableName)
        {
            btnAdd.Enabled = true;
            _mainDataGridView.Columns.Clear();
            btnAdd.Text = $"Add {tableName}";
            selectedTable = tableName;
            switch (tableName)
            {
                case "Packages":
                    _mainDataGridView.DataSource = PackageDB.GetPackages();
                    break;
                case "Products":
                case "Suppliers":
                default:
                    break;
            }
            addModifyAndDeleteButtonsToDGV();
            _mainDataGridView.AutoResizeColumns();
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
                default:
                    break;
            }
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
    }
}
