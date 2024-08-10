using Microsoft.EntityFrameworkCore;
using TravelExpertData;
// Author: Mackenzie Whitney
namespace TravelExpertGUI
{
 
    public partial class frmAddModifyPPS : Form
    {
        List<Package> packages = [];
        List<ProductsSupplier> startProductSuppliersAssigned = [];
        List<ProductsSupplier> startProductsSuppliersAvailable = [];

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

        // load product suppliers in both Available and Assigned lists
        private void LoadProductSuppliersInPackage()
        {
            startProductSuppliersAssigned = PackageDB.GetProductSuppliersForOnePackage((Package)(cboPackages.SelectedItem!));
            startProductsSuppliersAvailable = PackageDB.GetProductSuppliersNotInOnePackage((Package)(cboPackages.SelectedItem!));
            lstProductSuppliersAssigned.Items.Clear();
            lstProductSuppliersAssigned.Items.AddRange(startProductSuppliersAssigned.ToArray());
            lstProductSuppliersAvailable.Items.Clear();
            lstProductSuppliersAvailable.Items.AddRange(startProductsSuppliersAvailable.ToArray());
        }

        // change Available and Assigned lists when selected package changes
        private void cboPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductSuppliersInPackage();
        }

        // below are methods of the buttons that move product suppliers from one list to another
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            var itemsToMove = lstProductSuppliersAvailable.Items;
            lstProductSuppliersAssigned.Items.AddRange(itemsToMove);
            lstProductSuppliersAvailable.Items.Clear();
        }

        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            moveFromSourceListToTargetList(lstProductSuppliersAvailable, lstProductSuppliersAssigned);

        }

        
        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            moveFromSourceListToTargetList(lstProductSuppliersAssigned, lstProductSuppliersAvailable);
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            var itemsToMove = lstProductSuppliersAssigned.Items;
            lstProductSuppliersAvailable.Items.AddRange(itemsToMove);
            lstProductSuppliersAssigned.Items.Clear();
        }

        private void moveFromSourceListToTargetList(
            ListBox sourceList,
            ListBox destinationList)
        {
            var selectedItems = sourceList.SelectedItems;

            if (selectedItems != null)
            {
                foreach (var item in selectedItems)
                {
                    destinationList.Items.Add(item);
                }
                while (selectedItems.Count > 0)
                {
                    sourceList.Items.Remove(selectedItems[0]!);
                }
            }
            else
            {
                MessageBox.Show("You must select product suppliers first");
            }
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
                Package selectedPackage = (Package)(cboPackages.SelectedItem!);

                var packageToModify = db.Packages.Include(p => p.ProductSuppliers)
                                     .FirstOrDefault(p => p.PackageId == selectedPackage.PackageId);
                foreach (ProductsSupplier psToAdd in psToAddToPackage)
                {
                    packageToModify!.ProductSuppliers.Add(psToAdd);
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
                        packageToModify!.ProductSuppliers.Remove(attachedPsToRemove);
                    }
                }
                
                db.SaveChanges();
            }

            DialogResult = DialogResult.OK;
        }
            
        
    }
}
