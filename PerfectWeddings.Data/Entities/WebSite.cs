using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class WebSite : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public WebSiteSettings Settings { get; set; }
        public virtual ICollection<WebSitePage> Pages { get; set; }

        public WebSite()
        {
            Pages = new HashSet<WebSitePage>();
        }
    }
}
