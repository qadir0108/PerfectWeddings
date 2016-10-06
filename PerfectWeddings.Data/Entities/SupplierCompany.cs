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
    public class SupplierCompany : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string WebAddress { get; set; }

        [Required]
        public virtual Supplier Supplier { get; set; }

        public SupplierCompany()
        {

        }
    }
}
