using TravelExpertData;


// Author: Mackenzie Whitney for ITableContext structure
// The context methods were written separately by team members
namespace TravelExpertGUI
{
    public interface ITableContext
    {
        void UpdateTable(DataGridView dataGridView, TextBox txtSearch, Button btnAdd);
        void Search(DataGridView dataGridView, string searchText);
        void Add();
        void Modify(DataGridView dataGridView, DataGridViewCellEventArgs e);
    }

    // Author: Neil
    public class PackagesContext : ITableContext
    {
        public void UpdateTable(DataGridView dataGridView, TextBox txtSearch, Button btnAdd)
        {
            dataGridView.DataSource = PackageDB.GetPackageDTOs();
            dataGridView.Columns[5].DefaultCellStyle.Format = "c";
            dataGridView.Columns[6].DefaultCellStyle.Format = "c";
            DataGridViewHelper.AddModifyAndDeleteButtonsToDGV(dataGridView);
            btnAdd.Text = "Add Package";
            btnAdd.Enabled = true;
            txtSearch.Enabled = true;
        }
        public void Search(DataGridView dataGridView, string searchText)
        {
            var packages = PackageDB.GetPackageDTOs();
            var filteredPackages = packages.Where(p => p.PkgName.ToLower().Contains(searchText)).ToList();
            dataGridView.DataSource = filteredPackages;
        }

        public void Add()
        {
            using (frmAddModifyPackage frmAddModifyPackages = new frmAddModifyPackage())
            {
                DialogResult result = frmAddModifyPackages.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Package package = frmAddModifyPackages.Package!;
                    PackageDB.AddPackages(package);
                }
            }
        }

        public void Modify(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
                DialogResult? result = null;
                var packageList = (List<PackageDTO>)dataGridView.DataSource;

                PackageDTO selectedPackageDTO = packageList![e.RowIndex];
                Package selectedPackage = PackageDB.GetPackageFromDTO(selectedPackageDTO)!;

                // create object for package
                var addModifyForm = new frmAddModifyPackage() { Package = selectedPackage };

                // Open a form to modify the selected package
                result = addModifyForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Package package = addModifyForm.Package;
                    PackageDB.ModifyPackages(package);
                }
            
        }
    }
    // Author: Jessica
    public class ProductsContext : ITableContext
    {
        public void UpdateTable(DataGridView dataGridView, TextBox txtSearch, Button btnAdd)
        {
            dataGridView.DataSource = ProductDB.GetProducts();
            DataGridViewHelper.HideUnwantedColumns(dataGridView, new List<string> { "ProductsSuppliers" });
            DataGridViewHelper.AddModifyAndDeleteButtonsToDGV(dataGridView);
            btnAdd.Text = "Add Product";
            btnAdd.Enabled = true;
            txtSearch.Enabled = true;
        }

        public void Search(DataGridView dataGridView, string searchText)
        {
            var products = ProductDB.GetProducts();
            var filteredProducts = products.Where(p => p.ProdName.ToLower().Contains(searchText)).ToList();
            dataGridView.DataSource = filteredProducts;
            DataGridViewHelper.HideUnwantedColumns(dataGridView, new List<string> { "ProductsSuppliers" });
        }

        public void Add()
        {
            var addModifyProductForm = new AddModifyProduct();
            addModifyProductForm.ShowDialog();
        }

        public void Modify(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            DialogResult? result = null;
            var productList = (List<Product>)dataGridView.DataSource;
            Product selectedProduct = productList[e.RowIndex];
            var addModifyProductForm = new AddModifyProduct() { Product = selectedProduct };
            result = addModifyProductForm.ShowDialog();
        }
    }

    // Author: Jessica
    public class SuppliersContext : ITableContext
    {
        public void UpdateTable(DataGridView dataGridView, TextBox txtSearch, Button btnAdd)
        {
            dataGridView.DataSource = SupplierDB.GetSuppliers();
            DataGridViewHelper.HideUnwantedColumns(dataGridView, new List<string> { "ProductsSuppliers", "SupplierContacts" });
            DataGridViewHelper.AddModifyAndDeleteButtonsToDGV(dataGridView);
            btnAdd.Text = "Add Supplier";
            btnAdd.Enabled = true;
            txtSearch.Enabled = true;
        }

        public void Search(DataGridView dataGridView, string searchText)
        {
            var suppliers = SupplierDB.GetSuppliers();
            var filteredSuppliers = suppliers.Where(s => s.SupName.ToLower().Contains(searchText)).ToList();
            dataGridView.DataSource = filteredSuppliers;
            DataGridViewHelper.HideUnwantedColumns(dataGridView, new List<string> { "ProductsSuppliers", "SupplierContacts" });
        }

        public void Add()
        {
            var addModifySupplierForm = new AddModifySupplier();
            addModifySupplierForm.ShowDialog();
        }

        public void Modify(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            DialogResult? result = null;
            var supplierList = (List<Supplier>)dataGridView.DataSource;
            var selectedSupplier = supplierList[e.RowIndex];
            var addModifySupplierForm = new AddModifySupplier() { Supplier = selectedSupplier };
            result = addModifySupplierForm.ShowDialog();
        }
    }

    // Author: Mackenzie
    public class ProductsSuppliersContext : ITableContext
    {
        public void UpdateTable(DataGridView dataGridView, TextBox txtSearch, Button btnAdd)
        {
            dataGridView.DataSource = ProductsSupplierDB.GetProductsSuppliersAsNames();
            DataGridViewHelper.HideUnwantedColumns(dataGridView, new List<string> { "ProductSupplierId" });
            DataGridViewHelper.AddModifyAndDeleteButtonsToDGV(dataGridView);
            btnAdd.Text = "Add Product Supplier";
            btnAdd.Enabled = true;
            txtSearch.Enabled = true;
        }
        public void Search(DataGridView dataGridView, string searchText)
        {
            var productSuppliers = ProductsSupplierDB.GetProductsSuppliersAsNames();
            var filteredProductSuppliers = productSuppliers.Where(ps => ps.ProductName.ToLower().Contains(searchText) ||
                                                                         ps.SupplierName.ToLower().Contains(searchText)).ToList();
            dataGridView.DataSource = filteredProductSuppliers;
            DataGridViewHelper.HideUnwantedColumns(dataGridView, new List<string> { "ProductSupplierId" });
        }

        public void Add()
        {
            using (frmAddModifyProductsSuppliers frmAddModifyProductsSuppliers = new frmAddModifyProductsSuppliers())
            {
                DialogResult result = frmAddModifyProductsSuppliers.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ProductsSupplier productsSupplier = frmAddModifyProductsSuppliers.ProductsSupplier;
                    ProductsSupplierDB.AddProductSupplier(productsSupplier);
                }
            }
        }

        public void Modify(DataGridView dataGridView, DataGridViewCellEventArgs e) 
        {
            DialogResult? result = null;
            var productsSuppliersList = (List<ProductsSupplierDTO>)dataGridView.DataSource;
            ProductsSupplierDTO selectedProductsSupplierDTO = productsSuppliersList![e.RowIndex];
            ProductsSupplier selectedProductsSupplier = ProductsSupplierDB.GetProductsSupplierFromDTO(selectedProductsSupplierDTO)!;
            var modifyProductsSuppliersForm = new frmAddModifyProductsSuppliers() { ProductsSupplier = selectedProductsSupplier };
            result = modifyProductsSuppliersForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                ProductsSupplier productsSupplier = modifyProductsSuppliersForm.ProductsSupplier;
                ProductsSupplierDB.ModifyProductSupplier(productsSupplier);
            }
        }
    }


    // Author: Mackenzie
    public class PackagesProductsSuppliersContext : ITableContext
    {
        public void UpdateTable(DataGridView dataGridView, TextBox txtSearch, Button btnAdd)
        {
            dataGridView.DataSource = PackageDB.GetPackagesProductsSuppliers();
            btnAdd.Text = "Assign Product Suppliers";
            DataGridViewHelper.HideUnwantedColumns(dataGridView, new List<string> { "PackageId", "ProductSupplierId" });
            dataGridView.Columns[0].HeaderText = "Package Name";
            btnAdd.Enabled = true;
            txtSearch.Enabled = true;
        }
        public void Search(DataGridView dataGridView, string searchText)
        {
            var packagesProductsSuppliers = PackageDB.GetPackagesProductsSuppliers();
            var filteredPackagesProductsSuppliers = packagesProductsSuppliers.Where(pp => pp.PkgName.ToLower().Contains(searchText) ||
                                                                                         pp.ProductSupplierName.ToLower().Contains(searchText)).ToList();
            dataGridView.DataSource = filteredPackagesProductsSuppliers;
            DataGridViewHelper.HideUnwantedColumns(dataGridView, new List<string> { "PackageId", "ProductSupplierId" });
        }

        public void Add()
        {
            using (frmAddModifyPPS frmAddModifyPPS = new frmAddModifyPPS())
            {
                DialogResult result = frmAddModifyPPS.ShowDialog();
            }
        }

        // modify case doesn't make sense for Product Suppliers as we only assign product suppliers
        public void Modify(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}