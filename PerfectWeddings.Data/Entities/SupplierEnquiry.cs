using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class SupplierEnquiry : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public string EnquirerName { get; set; }
        public string EnquirerPhone { get; set; }
        public string EnquirerEmail { get; set; }
        public DateTime EnquirerWeddingDate { get; set; }
        public int NoOfGuests { get; set; }
        public bool IsSendInfoEmail { get; set; }
        public bool IsNeedCallback { get; set; }

        [Required]
        public virtual Supplier Supplier { get; set; }

        public SupplierEnquiry()
        {

        }
    }
}
