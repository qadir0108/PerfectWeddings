using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class Guest : Person, iBaseEntity
    {
        public string Address { get; set; }
        public bool IsSpecialMeal { get; set; }
        public bool IsChild { get; set; }
        public GuestCategoryEnum Category { get; set; }
        public string Notes { get; set; }

        // Event related
        public bool IsInvitationSent { get; set; }
        public AttendingStatusEnum IsAttending { get; set; }

        public virtual NormalUser NormalUser { get; set; }

        public Guest()
        {
        }
    }
}
