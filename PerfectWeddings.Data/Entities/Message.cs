using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class Message : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public User Sender { get; set; }
        public User Reciever { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }

        public Message()
        {
        }
    }
}
