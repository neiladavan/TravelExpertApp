

namespace TravelExpertData
{
    public static class ProductsSupplierDB
    {
        public static void AddProductSupplier(ProductsSupplier productsSupplier)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.ProductsSuppliers.Add(productsSupplier);
                db.SaveChanges();
            }
        }

        public static List<ProductsSupplierDTO> GetProductsSuppliersAsNames()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                List<ProductsSupplierDTO> productsSuppliers = db.ProductsSuppliers.Select(
                    p => new ProductsSupplierDTO
                    {
                        ProductName = p.Product.ProdName,
                        SupplierName = p.Supplier.SupName 
                    }).ToList();
                return productsSuppliers;
            }
        }

    }
}

