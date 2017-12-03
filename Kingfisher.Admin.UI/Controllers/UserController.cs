using Kingfisher.Admin.UI.Manager.APIManager;
using Kingfisher.Admin.UI.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace Kingfisher.Admin.UI.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                    return Redirect("/home/index");
            }

            ViewBag.Title = "Kingfisher | Login";
            return View();

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }

        public ActionResult SignUp()
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                    return Redirect("/home/index");
            }

            ViewBag.Title = "Kingfisher | SignUp";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(SigninUserVM data)
        {

            if (ModelState.IsValid)
            {
                UserManager um = new UserManager();

                string apiUrl = "http://localhost:6815/api/user/CheckByCredentials?username=" + data.username + "&password=" + data.password;

                bool isExist = await um.CheckByCredentials(apiUrl);

                if (isExist)
                {
                    string apiUrl1 = "http://localhost:6815/api/user/FindByUser?username=admin";
                    UserDTO currentUser = await um.FindByUser(apiUrl1);

                    if (currentUser == null) return RedirectToAction("login");
                    string cookie = $"{currentUser.Id}-{currentUser.FullName}-{currentUser.Username}-admin";

                    FormsAuthentication.SetAuthCookie(cookie, true);
                    return Redirect("/home/index");
                }

            }


            return RedirectToAction("login");

        }
    }


}
