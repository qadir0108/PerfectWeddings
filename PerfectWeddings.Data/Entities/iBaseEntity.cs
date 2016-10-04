using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PerfectWeddings.Data.Entities
{
    public interface iBaseEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
