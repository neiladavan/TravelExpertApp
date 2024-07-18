using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertData
{
    public static class PackageDB
    {
        public static List<Package> GetPackages()
        { 
            List<Package> packages = new List<Package>();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                packages = db.Packages.ToList();
            }
            return packages;
        }

        public static List<PackageDTO> GetPackageDTOs()
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

        public static List<PackageProductSupplierDTO> GetPackagesProductsSuppliers()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                List<PackageProductSupplierDTO> packageProductSuppliers = db.Packages
                    .Include(p => p.ProductSuppliers)
                        .ThenInclude(ps => ps.Product) // Include Product in ProductSupplier
                    .Include(p => p.ProductSuppliers)
                        .ThenInclude(ps => ps.Supplier) // Include Supplier in ProductSupplier
                    .SelectMany(p => p.ProductSuppliers.Select(ps => new PackageProductSupplierDTO
                    {
                        PackageId = p.PackageId,
                        PkgName = p.PkgName,
                        ProductSupplierId = ps.ProductSupplierId,
                        ProductSupplierName = ps.Product!.ProdName + " - " + ps.Supplier!.SupName
                    })).ToList();

                return packageProductSuppliers;
            }
        }

        public static List<ProductsSupplier> GetProductSuppliersForOnePackage(Package package)
        {
            List<ProductsSupplier> packageProductSuppliers = new List<ProductsSupplier>();

            using (TravelExpertsContext db = new TravelExpertsContext())
            {

                packageProductSuppliers = db.Packages
                    .Where(p => p.PackageId == package.PackageId)
                    .SelectMany(p => p.ProductSuppliers)
                    .Include(ps => ps.Product) // Eager load Product
                    .Include(ps => ps.Supplier).ToList(); // Eager load Supplier
            }       
            return packageProductSuppliers;
        }

        public static List<ProductsSupplier> GetProductSuppliersNotInOnePackage(Package package)
        {
            List<ProductsSupplier> packageProductSuppliers = new List<ProductsSupplier>();

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // get all product suppliers in package
                List<ProductsSupplier> packageProductSuppliersInPackage = GetProductSuppliersForOnePackage(package);
                List<ProductsSupplier> allProductsSuppliers = ProductsSupplierDB.GetProductsSuppliers();

                packageProductSuppliers = allProductsSuppliers.Except(packageProductSuppliersInPackage).ToList();
            }
            return packageProductSuppliers;
        }
    }
}
