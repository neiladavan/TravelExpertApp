
namespace TravelExpertData
{
    public static class ProductDB
    { 
        public static List<Product> GetProducts()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                List<Product> products = db.Products.ToList();

                return products;
            }
        }

        public static void AddProduct(Product product)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Products.Add(product);   //adding to the collection of products in the app
                db.SaveChanges();           //saves changes into the database
            }
        }

        public static void ModifyProduct(Product product)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Products.Update(product);    //updatting to the collection of products in the app
                db.SaveChanges();               //saves changes into the database
            }
        }

        public static void RemoveProduct(Product product)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }

}
