using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.DAL.ORM.Entity
{
    [Table("Books")]
    public class Book : BaseEntity
    {

        public decimal? Price { get; set; }
        public short? Stock { get; set; }

        [MaxLength(30)]
        public string Quantity { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Publisher")]
        public int? PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

    }
}
