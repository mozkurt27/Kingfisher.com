using Kingfisher.API.Models;
using Kingfisher.API.Service;
using Kingfisher.DAL.ORM.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Kingfisher.API.Controllers
{
    [EnableCors("*","*","*")]
    public class BookController : ApiController
    {

        [HttpGet,ActionName("SelectAll")]
        public IHttpActionResult GetSelectAll()
        {
            List<BookDTO> model = DataService.Service.BookService.SelectAll().ToList().Select(x => new BookDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).ToList();

            return Ok(model);
        }

        [HttpPost,ActionName("Insert")]
        public IHttpActionResult PostInsert(BookDTO model)
        {
            int result = DataService.Service.BookService.Insert(new Book {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
                Quantity = model.Quantity,
                CategoryId = model.category,
                PublisherId = model.publisher
            });

            return Json(result);
        }

    }
}
