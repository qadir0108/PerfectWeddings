using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class Event : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public string Name { get; set; }
        public string Icon { get; set; }
        public DateTime Date { get; set; }

        // 1015 HHMM
        public int Time { get; set; }
        public bool IsTime24 { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<EventSeatingTable> Seatings { get; set; }
        
        public Event()
        {
            Guests = new HashSet<Guest>();
            Seatings = new HashSet<EventSeatingTable>();
        }
    }
}
