using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class User : Person, iBaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Description { get; set; }
        public string ProfileImage { get; set; }
        public MethodToContactEnum MethodToContact { get; set; }
        public UserStatusEnum Status { get; set; }

        // Couple, Employee, Supplier, SuperAdmin
        public UserTypeEnum Type { get; set; }
        public virtual ICollection<SocialAccount> SocialAccounts { get; set; }

        public DateTime? LastLogin { get; set; }

        public User()
        {
            SocialAccounts = new HashSet<SocialAccount>();
        }
    }
}
