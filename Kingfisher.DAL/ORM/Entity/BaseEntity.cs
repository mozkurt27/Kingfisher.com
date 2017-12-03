using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.DAL.ORM.Entity
{
    public class BaseEntity
    {
        [Key,Column(Order =1)]
        public int Id { get; set; }

        [MaxLength(30),Required]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime? InsertDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeletedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Updatedate { get; set; }

    }
}
