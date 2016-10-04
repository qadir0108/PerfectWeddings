using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class NormalUser : User, iBaseEntity
    {
        public DateTime WeddingDate { get; set; }
        public string WeddingCity { get; set; }
        public string WeddingState { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }

        public string PartnerFirstName { get; set; }
        public string PartnerLastName { get; set; }
        public DateTime? PartnerDateOfBirth { get; set; }
        public GenderEnum PartnerGender { get; set; }

        public WebSite WebSite { get; set; }
        public BudgetSummary Budget { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Supplier> WishList { get; set; }
        public virtual ICollection<CheckList> CheckList { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        
        public NormalUser()
        {
            WishList = new HashSet<Supplier>();
            CheckList = new HashSet<CheckList>();
            Guests = new HashSet<Guest>();
        }
    }
}
