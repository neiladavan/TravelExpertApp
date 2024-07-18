using Microsoft.EntityFrameworkCore;
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
        List<ProductsSupplier> startProductSuppliersAssigned = new List<ProductsSupplier>();
        List<ProductsSupplier> startProductsSuppliersAvailable = new List<ProductsSupplier>();
        Package selectedPackage = null!;

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
            startProductSuppliersAssigned = PackageDB.GetProductSuppliersForOnePackage((Package)(cboPackages.SelectedItem));
            startProductsSuppliersAvailable = PackageDB.GetProductSuppliersNotInOnePackage((Package)(cboPackages.SelectedItem));
            lstProductSuppliersAssigned.Items.Clear();
            lstProductSuppliersAssigned.Items.AddRange(startProductSuppliersAssigned.ToArray());
            lstProductSuppliersAvailable.Items.Clear();
            lstProductSuppliersAvailable.Items.AddRange(startProductsSuppliersAvailable.ToArray());
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

            if (selectedItem != null)
            {
                lstProductSuppliersAssigned.Items.Add(selectedItem);
                lstProductSuppliersAvailable.Items.Remove(selectedItem);
            }
            else
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            List<ProductsSupplier> currentProductSuppliersAssigned = lstProductSuppliersAssigned.Items.OfType<ProductsSupplier>().ToList();
            List<ProductsSupplier> currentProductSuppliersAvailable = lstProductSuppliersAvailable.Items.OfType<ProductsSupplier>().ToList();
            // take the difference from the current and start assignment to find out which ones were added
            List<ProductsSupplier> psToAddToPackage = currentProductSuppliersAssigned.Except(startProductSuppliersAssigned).ToList();
            // take the difference from the current and start available to find out which ones were added
            List <ProductsSupplier> psToRemoveFromPackage = currentProductSuppliersAvailable.Except(startProductsSuppliersAvailable).ToList();

            // debug
            //foreach (ProductsSupplier ps in psToAddToPackage)
            //{
            //    System.Diagnostics.Debug.WriteLine(ps.ToString());
            //}
            //System.Diagnostics.Debug.WriteLine("---");
            //foreach (ProductsSupplier ps in psToRemoveFromPackage)
            //{
            //    System.Diagnostics.Debug.WriteLine(ps.ToString());
            //}


            // update selected package

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Package selectedPackage = (Package)(cboPackages.SelectedItem);

                var packageToModify = db.Packages.Include(p => p.ProductSuppliers)
                                     .FirstOrDefault(p => p.PackageId == selectedPackage.PackageId);
                foreach (ProductsSupplier psToAdd in psToAddToPackage)
                {
                    packageToModify.ProductSuppliers.Add(psToAdd);
                }
                foreach (ProductsSupplier psToRemove in psToRemoveFromPackage)
                {

                    /* Note: I need to find psToRemove as an attached object.
                     Directly calling Remove with psToRemove doesn't work
                     to update junction table.*/ 
                    var attachedPsToRemove = db.ProductsSuppliers.Find(psToRemove.ProductSupplierId);

                    if (attachedPsToRemove != null)
                    {
                        // Remove psToRemove from the many-to-many relationship
                        packageToModify.ProductSuppliers.Remove(attachedPsToRemove);
                    }
                }
                db.SaveChanges();
            }

            DialogResult = DialogResult.OK;
        }
            
        
    }
}
