

using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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

        public static void ModifyProductSupplier(ProductsSupplier productsSupplier)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.ProductsSuppliers.Update(productsSupplier);
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

        public static ProductsSupplier? GetProductsSupplierFromDTO(ProductsSupplierDTO productSupplierDTO)
        {
            ProductsSupplier? productsSupplier = null;
            
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var productId = db.Products
                    .Where(p => p.ProdName == productSupplierDTO.ProductName)
                    .Select(p => p.ProductId)
                    .FirstOrDefault();
                var supplierId = db.Suppliers
                    .Where(s => s.SupName == productSupplierDTO.SupplierName)
                    .Select(s => s.SupplierId)
                    .FirstOrDefault();
                productsSupplier = db.ProductsSuppliers
                    .Where(ps => ps.ProductId == productId && ps.SupplierId == supplierId)
                    .FirstOrDefault();
                
            }
            return productsSupplier;
        }

    }
}

