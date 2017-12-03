using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.DAL.ORM.Entity
{
    [Table("Publishers")]
    public class Publisher : BaseEntity
    {
        [MaxLength(100)]
        public string Adress { get; set; }

        [MaxLength(16)]
        public string Phone { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
