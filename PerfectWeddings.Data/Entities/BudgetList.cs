using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class BudgetList : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public string BudgetItemName { get; set; }
        public BudgetCategoryEnum Category { get; set; }

        public double BudgetCost { get; set; }
        public double ActualCost { get; set; }
        public double PaidCost { get; set; }

        public virtual BudgetSummary BudgetSummary { get; set; }

        public BudgetList()
        {
        }
    }
}
