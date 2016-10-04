using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Data.Entities
{
    public class WebSiteSettings : BaseEntity, iBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public System.Guid Id { get; set; }

        public string URL { get; set; }
        public bool IsPasswordProtected { get; set; }
        public string Password { get; set; }

        public string Theme { get; set; }
        public List<string> Themes { get; set; }
        
        public WebSiteSettings()
        {
        }
    }
}
