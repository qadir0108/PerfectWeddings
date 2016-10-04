using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class EventSeatingTable : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public string TableName { get; set; }
        public int NoOfSeats { get; set; }

        public virtual ICollection<Guest> GuestsSeated { get; set; }

        public EventSeatingTable()
        {
            GuestsSeated = new HashSet<Guest>();
        }
    }
}
