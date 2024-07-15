using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertData;

namespace TravelExpertGUI
{
    public partial class frmAddModifyPackage : Form
    {
        // add public property for a Product entity 
        public PackageDTO? Package;

        public frmAddModifyPackage()
        {
            InitializeComponent();
        }

        private void frmAddModifyPackages_Load(object sender, EventArgs e)
        {
            if (Package == null)
            {
                Text = "Add Package";
                txtPackageId.ReadOnly = false;
            }
            else 
            {
                Text = "Modify Package";
                txtPackageId.ReadOnly = true;

                DisplayPackages();
            }
        }

        private void DisplayPackages()
        {
            txtPackageId.Text = Package?.PackageId.ToString();
            txtPackageName.Text = Package?.PkgName;
            txtPackageStartDate.Text = Package?.PkgStartDate.ToString();
            txtPackageEndDate.Text = Package?.PkgEndDate.ToString();
            txtPackageDesc.Text = Package?.PkgDesc;
            txtPackageBasePrice.Text = Package?.PkgBasePrice.ToString("c");
            txtPackageAgencyCommission.Text = Package?.PkgAgencyCommission.ToString("c");
        }
    }
}
