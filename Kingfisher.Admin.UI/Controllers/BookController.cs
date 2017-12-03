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

        [HttpPost]
        public async Task<ActionResult> Add(BookDTO model)
        {
            //AllListVM model = new AllListVM();
            //CategoryManager cm = new CategoryManager();
            //PublisherManager pm = new PublisherManager();
            //string ApiUrlCat = "http://localhost:6815/api/category/SelectAll";
            //string ApiUrlPub = "http://localhost:6815/api/publisher/SelectAll";
            //model.Categories = await cm.SelectAll(ApiUrlCat);
            //model.Publishers = await pm.SelectAll(ApiUrlPub);
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


            return PartialView("~/Views/Home/partial/BookListTable.cshtml", model);
        }
    }
}