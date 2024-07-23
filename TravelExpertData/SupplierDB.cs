namespace TravelExpertData
{
    public static class SupplierDB
    {
        public static List<Supplier> GetSuppliers()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                List<Supplier> suppliers = db.Suppliers.ToList();

                return suppliers;
            }
        }

        public static void AddSupplier(Supplier supplier)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Suppliers.Add(supplier);   //adding to the collection of suppliers in the app
                db.SaveChanges();           //saves changes into the database
            }
        }

        public static void ModifySupplier(Supplier supplier)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Suppliers.Update(supplier);    //updatting to the collection of suppliers in the app
                db.SaveChanges();               //saves changes into the database
            }
        }

        /* public static void RemoveSupplier(Supplier supplier)
         {
             using (TravelExpertsContext db = new TravelExpertsContext())
             {
                 db.Suppliers.Remove(supplier);
                 db.SaveChanges();
             }
         }
        */
    }

}
