using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class BlogEntryComment : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public string Subject { get; set; }
        public string Comment { get; set; }

        public string CommenterName { get; set; }
        public string CommenterEmail { get; set; }

        public virtual BlogEntry BlogEntry { get; set; }

        public BlogEntryComment()
        {
        }
    }
}
