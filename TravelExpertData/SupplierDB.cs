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
    }
}
