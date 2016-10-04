using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class BudgetSummary : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public int NoOfGuests { get; set; }
        public double TotalBudgetedCost { get; set; }

        public virtual ICollection<BudgetList> BudgetList { get; set; }

        public BudgetSummary()
        {
            BudgetList = new HashSet<BudgetList>();
        }
    }
}
