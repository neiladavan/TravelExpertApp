using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        public Package? Package;

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
            txtPackageStartDate.Text = Package?.PkgStartDate.HasValue ?? false
                                                ? Package.PkgStartDate.Value.ToString("MM/dd/yyyy")
                                                : null;
            txtPackageEndDate.Text = Package?.PkgEndDate.HasValue ?? false
                                                ? Package.PkgEndDate.Value.ToString("MM/dd/yyyy")
                                                : null;
            txtPackageDesc.Text = Package?.PkgDesc;
            txtPackageBasePrice.Text = Package?.PkgBasePrice.ToString("c");
            txtPackageAgencyCommission.Text = Package?.PkgAgencyCommission.HasValue ?? false
                                                ? Package.PkgAgencyCommission.Value.ToString("c")
                                                : string.Empty;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (true) 
            {
                //TO DO Validation

                Package ??= new Package(); // if Package is null, create new object
                
                PopulatePackageDate();

                PackageDB.ModifyPackages(Convert.ToInt32(txtPackageId.Text), Package);

                DialogResult = DialogResult.OK;
            }
        }

        private void PopulatePackageDate()
        {
            if (decimal.TryParse(txtPackageBasePrice.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal parsedPkgBasePriceValue))
                Package!.PkgBasePrice = parsedPkgBasePriceValue;

            if (decimal.TryParse(txtPackageAgencyCommission.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal parsedPkgAgencyCommValue))
                Package!.PkgBasePrice = parsedPkgAgencyCommValue;

            Package!.PkgName = txtPackageName.Text;
            Package.PkgStartDate = DateTime.ParseExact(txtPackageStartDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            Package.PkgEndDate = DateTime.ParseExact(txtPackageEndDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            Package.PkgDesc = txtPackageDesc.Text;
            Package.PkgBasePrice = Convert.ToDecimal(parsedPkgBasePriceValue);
            Package.PkgAgencyCommission = Convert.ToDecimal(parsedPkgAgencyCommValue);
        }
    }
}
