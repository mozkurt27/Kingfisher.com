using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.DAL.ORM.Entity
{
    [Table("Orders")]
    public class Order : BaseEntity
    {
        [ForeignKey("WebUser")]
        public int? WebUserId { get; set; }
        public virtual WebUser WebUser { get; set; }

    }
}
