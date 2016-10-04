using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class HoneyMoonPackage : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public string Title { get; set; }
        public double Cost { get; set; }
        public string Content { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<string> Inclusions { get; set; }
        public List<string> Gallery { get; set; }
        public string Flights { get; set; }
        public string Terms { get; set; }

        public HoneyMoonPackage()
        {
        }
    }
}
