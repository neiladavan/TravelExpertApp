

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;

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
                        ProductSupplierId = p.ProductSupplierId,
                        ProductName = p.Product!.ProdName,
                        SupplierName = p.Supplier!.SupName! 
                    }).ToList();
                return productsSuppliers;
            }
        }

        public static ProductsSupplier? GetProductsSupplierFromDTO(ProductsSupplierDTO productSupplierDTO)
        {
            ProductsSupplier? productsSupplier = null;
            
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                productsSupplier = db.ProductsSuppliers
                    .Where(ps => ps.ProductSupplierId == productSupplierDTO.ProductSupplierId)
                    .FirstOrDefault();
                
            }
            return productsSupplier;
        }

        public static List<ProductsSupplier> GetProductsSuppliers()
        {
            List<ProductsSupplier> productsSuppliers = new List<ProductsSupplier>();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                productsSuppliers = db.ProductsSuppliers
                    .AsNoTracking()
                    .Include(ps => ps.Product) // Eager load Product
                    .Include(ps => ps.Supplier).ToList(); // Eager load Supplier
            }
            return productsSuppliers;
        }

    }
}

