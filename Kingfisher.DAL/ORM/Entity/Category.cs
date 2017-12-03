using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.DAL.ORM.Entity
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        [MaxLength(400)]
        public string Description { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
