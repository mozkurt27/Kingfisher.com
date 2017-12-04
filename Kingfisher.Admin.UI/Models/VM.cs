using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kingfisher.Admin.UI.Models
{
  
    public class AllListVM
    {
        public List<CategoryDTO> Categories { get; set; }
        public List<UserDTO> Users { get; set; }
        public List<PublisherDTO> Publishers { get; set; }

    }

    public class ComplexVm
    {
        public BookDTO book { get; set; }
        public AllListVM AllList { get; set; }

    }
    public class SigninUserVM
    {
        [MinLength(4,ErrorMessage ="username kısa")]
        public string username { get; set; }

        [MinLength(4,ErrorMessage ="password kısa")]
        public string password { get; set; }

    }
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

    }
    public class PublisherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
    }

    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }



    }

    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Quantity { get; set; }
        public short Stock { get; set; }
        public int category { get; set; }
        public int publisher { get; set; }


    }
}