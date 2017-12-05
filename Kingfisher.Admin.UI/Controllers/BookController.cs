using Kingfisher.Admin.UI.Manager.APIManager;
using Kingfisher.Admin.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Kingfisher.Admin.UI.Controllers
{
    public class BookController : Controller
    {

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            AllListVM model = new AllListVM(); 
            CategoryManager cm = new CategoryManager();
            PublisherManager pm = new PublisherManager();
            string ApiUrlCat = "http://localhost:6815/api/category/SelectAll";
            string ApiUrlPub = "http://localhost:6815/api/publisher/SelectAll";
            model.Categories = await cm.SelectAll(ApiUrlCat);
            model.Publishers = await pm.SelectAll(ApiUrlPub);


            return PartialView("~/Views/Book/partial/insert.cshtml", model);
        }

        [HttpGet]
        public async Task<ActionResult> Deleteds()
        {
            BookManager bm = new BookManager();
            string ApiUrl = "http://localhost:6815/api/book/deleteds";
            List<BookDTO> model = await bm.Deleteds(ApiUrl);


            return PartialView("~/Views/Book/partial/Deleteds.cshtml", model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(BookDTO model)
        {
           
            string ApiUrl = "http://localhost:6815/api/book/Insert";

            BookManager bm = new BookManager();
            int result = await bm.Insert(model,ApiUrl);


            return Json(result);
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            BookManager bm = new BookManager();
            string ApiUrl = "http://localhost:6815/api/book/SelectAll";
            List<BookDTO> model = await bm.SelectAll(ApiUrl);


            return PartialView("~/Views/Book/partial/BookListTable.cshtml", model);
        }



        [HttpGet]
        public async Task<ActionResult> GetOneBook(int? id)
        {
            ComplexVm complex = new ComplexVm();
            AllListVM model = new AllListVM();
            CategoryManager cm = new CategoryManager();
            PublisherManager pm = new PublisherManager();
            string ApiUrlCat = "http://localhost:6815/api/category/SelectAll";
            string ApiUrlPub = "http://localhost:6815/api/publisher/SelectAll";
            model.Categories = await cm.SelectAll(ApiUrlCat);
            model.Publishers = await pm.SelectAll(ApiUrlPub);
            complex.AllList = model;

            BookManager bm = new BookManager();
            string ApiUrlBook = "http://localhost:6815/api/book/onebook/"+id;
            complex.book = await bm.OneBook(ApiUrlBook);




            return PartialView("~/Views/Book/partial/UpdateForm.cshtml", complex);

        }

        [HttpGet]
        public async Task<JsonResult> Delete(int? id)
        {
            BookManager bm = new BookManager();
            string ApiUrl = "http://localhost:6815/api/book/delete/";
            bool result = await bm.Delete(id, ApiUrl);

            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> Update(BookDTO model)
        {
            BookManager bm = new BookManager();
            string APiUrl = "http://localhost:6815/api/book/update";
            bool result = await bm.Update(model, APiUrl);

            if (result) return Json("OK");

            return Json("No");
        }
    }
}