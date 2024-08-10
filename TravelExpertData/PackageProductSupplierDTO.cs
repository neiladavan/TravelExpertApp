// Author: Mackenzie

namespace TravelExpertData
{
    public class PackageProductSupplierDTO
    {
        public int PackageId { get; set; }
        public string PkgName { get; set; } = null!;
        public int ProductSupplierId { get; set; }
        public string ProductSupplierName { get; set; } = null!;
    }
}
