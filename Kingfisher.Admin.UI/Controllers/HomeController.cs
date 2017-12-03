using Kingfisher.Admin.UI.Manager.APIManager;
using Kingfisher.Admin.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kingfisher.Admin.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if(!HttpContext.User.Identity.IsAuthenticated) return Redirect("/user/login");
            
            return View();
        }

       

        public async Task<ActionResult> Effect(string id)
        {
            if (id != null)
            {
                switch (id)
                {
                    case "book-content":
                        {
                            BookManager bm = new BookManager();
                            string ApiUrl = "http://localhost:6815/api/book/SelectAll";
                            List<BookDTO> vm = await bm.SelectAll(ApiUrl);

                            if(vm != null)
                            return PartialView("~/Views/Home/partial/BookListTable.cshtml", vm);

                            return RedirectToAction("index");
                        }
                    //case "category-content":
                    //    {
                    //        UIInsertVM vm = new UIInsertVM();
                    //        vm.Categories = DataService.Service.CategoryService.SelectAll();

                    //        return PartialView("~/Views/Category/partial/CategoryListTable.cshtml", vm);
                    //    }
                    //case "user-content":
                    //    {
                    //        UIInsertVM vm = new UIInsertVM();
                    //        vm.Users = DataService.Service.WebUserService.SelectAll();

                    //        return PartialView("~/Views/User/partial/UserListTable.cshtml", vm);
                    //    }
                    //case "publisher-content":
                    //    {
                    //        UIInsertVM vm = new UIInsertVM();
                    //        vm.Publishers = DataService.Service.PublisherService.SelectAll();

                    //        return PartialView("~/Views/Publisher/partial/PublisherListTable.cshtml", vm);
                    //    }
                    //case "order-content":
                    //    {
                    //        UIInsertVM vm = new UIInsertVM();
                    //        vm.Orders = DataService.Service.OrderService.SelectAll();

                    //        return PartialView("~/Views/Order/partial/OrderListTable.cshtml", vm);
                    //    }

                    default:
                        return Json("<h1>HOŞGELDİNİZ...</h1>", JsonRequestBehavior.AllowGet);
                }

            }

            return Json("<h1>HOŞGELDİNİZ...</h1>", JsonRequestBehavior.AllowGet);
        }
    }
}