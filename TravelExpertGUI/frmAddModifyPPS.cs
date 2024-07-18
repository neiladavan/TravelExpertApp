using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public partial class frmAddModifyPPS : Form
    {
        List<Package> packages = new List<Package>();
        List<ProductsSupplier> productSuppliersAssigned = new List<ProductsSupplier>();
        List<ProductsSupplier> productsSuppliersAvailable = new List<ProductsSupplier>();

        public frmAddModifyPPS()
        {
            InitializeComponent();
        }

        private void frmAddModifyPPS_Load(object sender, EventArgs e)
        {
            packages = PackageDB.GetPackages();
            cboPackages.DataSource = packages;
            cboPackages.DisplayMember = "PkgName";
            cboPackages.ValueMember = "PackageId";
            LoadProductSuppliersInPackage();
        }

        private void LoadProductSuppliersInPackage()
        {
            productSuppliersAssigned = PackageDB.GetProductSuppliersForOnePackage((Package)(cboPackages.SelectedItem));
            productsSuppliersAvailable = PackageDB.GetProductSuppliersNotInOnePackage((Package)(cboPackages.SelectedItem));
            lstProductSuppliersAssigned.Items.Clear();
            lstProductSuppliersAssigned.Items.AddRange(productSuppliersAssigned.ToArray());
            lstProductSuppliersAvailable.Items.Clear();
            lstProductSuppliersAvailable.Items.AddRange(productsSuppliersAvailable.ToArray());
        }

        private void cboPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductSuppliersInPackage();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            var itemsToMove = lstProductSuppliersAvailable.Items;
            lstProductSuppliersAssigned.Items.AddRange(itemsToMove);
            lstProductSuppliersAvailable.Items.Clear();
        }

        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            var selectedItem = lstProductSuppliersAvailable.SelectedItem;
            
            if(selectedItem != null) { 
            lstProductSuppliersAssigned.Items.Add(selectedItem);
            lstProductSuppliersAvailable.Items.Remove(selectedItem);
            } else
            {
                MessageBox.Show("You must select available product suppliers first");
            }
            
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            var selectedItem = lstProductSuppliersAssigned.SelectedItem;

            if (selectedItem != null)
            {
                lstProductSuppliersAvailable.Items.Add(selectedItem);
                lstProductSuppliersAssigned.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("You must select assigned product suppliers first");
            }

        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            var itemsToMove = lstProductSuppliersAssigned.Items;
            lstProductSuppliersAvailable.Items.AddRange(itemsToMove);
            lstProductSuppliersAssigned.Items.Clear();
        }
    }
}
