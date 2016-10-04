using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class Enquirer : Person, iBaseEntity
    {
        public EnquiryCategoryEnum EnquiryCategory { get; set; }
        public string Message { get; set; }
        
        public Enquirer()
        {
        }
    }
}
