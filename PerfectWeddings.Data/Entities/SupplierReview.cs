using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class SupplierReview : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public int ReviewStars { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewDetail { get; set; }

        public NormalUser Reviewer { get; set; }

        public SupplierReview()
        {

        }
    }
}
