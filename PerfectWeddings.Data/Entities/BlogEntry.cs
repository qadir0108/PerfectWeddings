using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class BlogEntry : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }

        public BlogEntryTypeEnum Type { get; set; }
        public BlogEntryCategory Category { get; set; }

        public virtual ICollection<BlogEntryComment> Comments { get; set; }
        public virtual ICollection<BlogEntryTag> Tags { get; set; }

        public BlogEntry()
        {
            Comments = new HashSet<BlogEntryComment>();
            Tags = new HashSet<BlogEntryTag>();
        }
    }
}
