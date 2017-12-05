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

            return Json(model);
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

        [HttpGet,ActionName("delete")]
        public IHttpActionResult GetDelete(int? id)
        {
            int result = DataService.Service.BookService.Delete(id);

            return Json(result);
        }

        [HttpPut,ActionName("update")]
        public IHttpActionResult PutUpdate(BookDTO model)
        {
            Book newEntity = new Book()
            {
                Id = model.Id,
                CategoryId = model.category,
                PublisherId = model.publisher,
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
                Quantity = model.Quantity

            };

            DataService.Service.BookService.Update(newEntity);

            return Json("Ok");
        }

        [HttpGet,ActionName("deleteds")]
        public IHttpActionResult GetDeleteds()
        {
            List<BookDTO> model = DataService.Service.BookService.SelectByState(false, true)
                                        .Select(x => new BookDTO
                                        {
                                            Id = x.Id,
                                            Name = x.Name,
                                            Price = x.Price,
                                            Stock = (short)x.Stock,
                                            Quantity = x.Quantity,
                                            category = (int)x.CategoryId,
                                            publisher = (int)x.PublisherId

                                        }).ToList();

            return Json(model);
        }

        [HttpGet,ActionName("onebook")]
        public IHttpActionResult GetOneBook(int? id)
        {
            BookDTO result = DataService.Service.BookService.SelectByOneList(id).Select(x => new BookDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                category = (int)x.CategoryId,
                publisher = (int)x.PublisherId,
                Quantity = x.Quantity,
                Stock = (short)x.Stock
            }).FirstOrDefault();

            return Json(result);
        }

    }
}
