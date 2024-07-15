using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertData
{
    public static class PackageDB
    {
        public static List<PackageDTO> GetPackages()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            { 
                List<PackageDTO> packages = db.Packages.Select(
                    p => new PackageDTO
                    { 
                        PackageId = p.PackageId,
                        PkgName = p.PkgName,
                        PkgStartDate = p.PkgStartDate,
                        PkgEndDate = p.PkgEndDate,
                        PkgDesc = p.PkgDesc!,
                        PkgBasePrice = p.PkgBasePrice,
                        PkgAgencyCommission = p.PkgAgencyCommission ?? 0m
                    }).ToList();

                return packages;
            }
        }

        public static void ModifyPackages(int packageId, Package newPackageData)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Package? pck = db.Packages.Find(packageId);

                // modify existing customer object in the app
                if (pck != null)
                {
                    pck.PkgName = newPackageData.PkgName;
                    pck.PkgStartDate = newPackageData.PkgStartDate;
                    pck.PkgEndDate = newPackageData.PkgEndDate;
                    pck.PkgDesc = newPackageData.PkgDesc;
                    pck.PkgBasePrice = newPackageData.PkgBasePrice;
                    pck.PkgAgencyCommission = newPackageData.PkgAgencyCommission;

                    db.SaveChanges(); // saves changes to the database
                }
            }
        }
    }
}
