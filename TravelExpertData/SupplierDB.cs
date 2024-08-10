using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TravelExpertData
{
    //Jessica Pereira Lins
    //August,2024

    //GetSuppliers: Retrieves and returns a list of all suppliers from the database.
    //AddSupplier: Adds a new supplier to the database and saves the changes.
    //ModifySupplier: Updates an existing supplier in the database and saves the changes


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
                //Retrieves the highest `SupplierId` from the `Suppliers` table to find the maximum existing ID.
                var highestID = db.Suppliers
                    .Select(supplier => supplier.SupplierId)
                    .OrderByDescending(id => id)
                    .FirstOrDefault();
                
                supplier.SupplierId = highestID + 1;
                db.Suppliers.Add(supplier);    //adding to the collection of suppliers in the app
                db.SaveChanges();              //saves changes into the database
            }
        }

        public static void ModifySupplier(Supplier supplier)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Suppliers.Update(supplier);    //updatting to the collection of suppliers in the app
                db.SaveChanges();                 //saves changes into the database
            }
        }

        ///public static void RemoveSupplier(Supplier supplier)
        // {
        //     using (TravelExpertsContext db = new TravelExpertsContext())
        //     {
        //         db.Suppliers.Remove(supplier);
        //         db.SaveChanges();
        //     }
        // }
        // We are not implementing the remove/delete functionality for this workshop.
    }

}
