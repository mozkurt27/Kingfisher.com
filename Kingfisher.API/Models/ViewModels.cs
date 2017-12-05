using Kingfisher.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kingfisher.API.Models
{
    public class SigninVM
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int? RoleId { get; set; }

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
    public class bookDeletedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }

        public string CategoryName { get; set; }
        public string PublisherName { get; set; }

    }
}