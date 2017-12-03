using Kingfisher.API.Models;
using Kingfisher.API.Service;
using Kingfisher.DAL.ORM.Entity;
using System.Linq;
using System.Web.Http;

namespace Kingfisher.API.Controllers
{
    public class UserController : ApiController
    {

        [HttpGet,ActionName("CheckByCredentials")]
        public IHttpActionResult GetCheckByCredentials(string username,string password)
        {
            bool isExist = DataService.Service.WebUserService.CheckByCredentials(username, password);
            return Ok(isExist);
        }

        [HttpGet,ActionName("FindByUser")]
        public IHttpActionResult GetFindByUser(string username)
        {
            WebUser u = DataService.Service.WebUserService.FindByUser(username);

            UserDTO udto = DataService.Service.WebUserService.SelectByOneList(u.Id).Select(x => new UserDTO
            {
                Id = x.Id,
                Email = x.Email,
                FullName = x.Name +" "+ x.Lastname,
                Username = x.Username,
                Password = x.Password,
                IsActive = x.IsActive,
                RoleId = x.RoleId
            }).FirstOrDefault();

            return Ok(udto);
        }
        
    }
}
