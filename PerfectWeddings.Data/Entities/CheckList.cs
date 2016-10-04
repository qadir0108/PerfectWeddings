using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class CheckList : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string TimeFrame { get; set; }

        public virtual ICollection<CheckListComment> Comments { get; set; }
        
        public CheckList()
        {
            Comments = new HashSet<CheckListComment>();
        }
    }
}
