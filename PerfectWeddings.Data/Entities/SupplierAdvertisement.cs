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
    public class SupplierAdvertisement : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Location Location { get; set; }
        public SupplierCategoryEnum Category { get; set; }

        public int Capacity { get; set; }
        public int Cost { get; set; }

        [Required]
        public virtual Supplier Supplier { get; set; }

        public SupplierAdvertisement()
        {

        }
    }
}
