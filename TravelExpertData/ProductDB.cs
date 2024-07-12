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
    }
}
