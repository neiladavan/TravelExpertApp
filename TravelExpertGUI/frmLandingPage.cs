using TravelExpertData;

namespace TravelExpertGUI
{
    public partial class frmLandingPage : Form
    {
        public frmLandingPage()
        {
            InitializeComponent();
        }

        private void frmLandingPage_Load(object sender, EventArgs e)
        {
            panMenu.Dock = DockStyle.Left;

            _mainDataGridView.Columns.Clear();

            _mainDataGridView.DataSource = PackageDB.GetPackages();
        }
    }
}
