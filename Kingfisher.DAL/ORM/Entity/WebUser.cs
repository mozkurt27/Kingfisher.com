using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.DAL.ORM.Entity
{
    [Table("WebUsers")]
    public class WebUser : BaseEntity
    {
        [MaxLength(30),Required]
        public string Lastname { get; set; }

        [Required, MaxLength(20),MinLength(4)]
        public string Username { get; set; }

        [Required, MaxLength(30), MinLength(3)]
        public string Password { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [ForeignKey("Role")]
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
