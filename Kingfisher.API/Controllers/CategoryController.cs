using Kingfisher.API.Models;
using Kingfisher.API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Kingfisher.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {
        [HttpGet, ActionName("SelectAll")]
        public IHttpActionResult GetSelectAll()
        {
            List<CategoryDTO> model = DataService.Service.CategoryService.SelectAll().ToList().Select(x => new CategoryDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Desc = x.Description
            }).ToList();

            return Ok(model);
        }
    }
}
