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
        /// Get specific package based from the packageDTO data
        /// </summary>
        /// <param name="packageDTO">package to be retrieve</param>
        /// <returns>package record</returns>
        public static Package? GetPackageFromDTO(PackageDTO packageDTO)
        {
            Package? package = null;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                package = db.Packages.Find(packageDTO.PackageId); // returns package the package or null when not found
            }

            return package;
        }

        /// <summary>
        /// Modifies selected package
        /// </summary>
        /// <param name="newPackageData">new package data to be saved</param>
        public static void ModifyPackages(Package newPackageData)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Packages.Update(newPackageData);
                db.SaveChanges();
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
