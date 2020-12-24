using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PIMWebProject.Helpers;
using PIMDesktopProjectBLL;

namespace PIMWebProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            var cookie = CookiesControll.UserAuthenticationInfo();

            if (cookie.Name != null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View();
        }

        public ActionResult Sair()
        {
            var cookie = new HttpCookie(CookiesControll.MasterCookie)
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();

            return RedirectToAction("SignIn", "Login", new { area = "" });
        }   
        
        public JsonResult UserInfoEmail(string Email)
        {
            return Json(UserBLL.ListAllByEmail(Email.ToUpper()).Email != "null" ? true : false,
                JsonRequestBehavior.AllowGet);
        }
                
        public JsonResult UserInfoPass(string Password, string Email)
        {
            try
            {
                var user = UserBLL.ListAllByEmail(Email.ToLower());
                var passcorrect = user.Senha == Password ? true : false;

                if (passcorrect)
                {
                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        user.UserID.ToString(),
                        DateTime.Now,
                        DateTime.Now.AddDays(10),
                        true,
                        "Client",
                        "/"
                        );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);


                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                    if (authTicket.IsPersistent)
                    {
                        authCookie.Expires = authTicket.Expiration;
                    }

                    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
                }
                return Json(passcorrect,
              JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false,
              JsonRequestBehavior.AllowGet);
            }
        }
    }
}