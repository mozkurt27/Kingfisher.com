using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.DAL.ORM.Entity
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        public virtual List<WebUser> WebUsers { get; set; }

    }
}
