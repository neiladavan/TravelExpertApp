using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertData
{
    /// <summary>
    /// Package DTO with few package field
    /// Author: Neil Adavan
    /// Date: July 2024
    /// </summary>
    public class PackageDTO
    {
        public int PackageId { get; set; }

        public string PkgName { get; set; } = null!;

        public DateTime? PkgStartDate { get; set; }

        public DateTime? PkgEndDate { get; set; }

        public string PkgDesc { get; set; } = null!;

        public decimal PkgBasePrice { get; set; } = 0;

        public decimal PkgAgencyCommission { get; set; } = 0m;

    }
}
