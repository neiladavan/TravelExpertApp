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

        /// <summary>
        /// Get specific package based from the package id provided
        /// </summary>
        /// <param name="productCode">package id of the package to be retrieve</param>
        /// <returns>package rcord</returns>
        public static Package? GetPackage(int packageId)
        {
            Package? package = null;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                package = db.Packages.Find(packageId); // returns package by package id or null when not found
            }

            return package;
        }

        public static void ModifyPackages(int packageId, Package newPackageData)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                Package? pck = db.Packages.Find(packageId);

                // modify existing packages object in the app
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

        public static void AddPackages(Package package)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                if (package != null)
                {
                    db.Packages.Add(package); // adds to the collection packages in the app
                    db.SaveChanges(); // saves to the database
                }
            }
        }
    }
}
