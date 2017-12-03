using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.DAL.ORM.Entity
{
    [Table("OrderDetails")]
    public class OrderDetail : BaseEntity
    {
        [ForeignKey("Book")]
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

        public decimal? Price { get; set; }
        public string Quantity { get; set; }

    }
}
