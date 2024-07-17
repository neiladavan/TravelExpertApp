using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
