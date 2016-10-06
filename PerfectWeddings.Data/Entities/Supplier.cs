using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class Supplier : User, iBaseEntity
    {
        public string Name { get; set; }
        public string WhySpecial { get; set; }
        public string VideoURL { get; set; }

        public SupplierCompany Company { get; set; }
        public SupplierCategory Category { get; set; }

        public Location Location { get; set; }

        public SupplierAccountTypeEnum AccountType { get; set; }
        public DateTime AccountExpiryDate {get;set;}

        public int NumberOfAdAllowed { get; set; }
        public bool IsVerified { get; set; }
        
        public virtual ICollection<SupplierFacility> Facilities { get; set; }
        public virtual ICollection<SupplierAdvertisement> Ads { get; set; }
        public virtual ICollection<SupplierReview> Reviews { get; set; }
        public virtual ICollection<SupplierEnquiry> Enquiries { get; set; }
        public virtual ICollection<SupplierCoupon> Coupons { get; set; }

        public Supplier()
        {
            Facilities = new HashSet<SupplierFacility>();
            Ads = new HashSet<SupplierAdvertisement>();
            Reviews = new HashSet<SupplierReview>();
            Enquiries = new HashSet<SupplierEnquiry>();
            Coupons = new HashSet<SupplierCoupon>();
        }
    }
}
