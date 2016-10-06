using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class WebSitePage : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public int PageOrder { get; set; }
        public bool IsPasswordProtected { get; set; }
        public string Password { get; set; }

        public virtual WebSite WebSite { get; set; }

        public WebSitePage()
        {
        }
    }
}
