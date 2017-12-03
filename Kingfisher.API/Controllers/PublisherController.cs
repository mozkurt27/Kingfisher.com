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
    public class PublisherController : ApiController
    {

        [HttpGet, ActionName("SelectAll")]
        public IHttpActionResult GetSelectAll()
        {
            List<PublisherDTO> model = DataService.Service.PublisherService.SelectAll().ToList().Select(x => new PublisherDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Adress = x.Adress,
                Phone = x.Phone
            }).ToList();

            return Ok(model);
        }
    }
}
