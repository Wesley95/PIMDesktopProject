using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIMDesktopProjectBLL;
using PIMDesktopProjectDTO;
using PIMWebProject.Helpers;

namespace PIMWebProject.Controllers
{
    public class ConfiguracaoController : Controller
    {
        [NoDirectAccess]
        // GET: Configuracao
        public ActionResult Configuracao()
        {
            var cookie = CookiesControll.UserAuthenticationInfo();

            if (cookie.UserData == "Client")
            {
                ViewData["Usuario"] = PhraseBLL.GetPhrase(cookie.Name);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [NoDirectAccess]
        [HttpGet]
        public JsonResult GetWords()
        {
            return Json(WordBLL.ListAll(), JsonRequestBehavior.AllowGet);
        }

        [NoDirectAccess]
        [HttpGet]
        public JsonResult GetCurPass()
        {
            return Json(UserBLL.GetUserById(CookiesControll.UserAuthenticationInfo().Name), JsonRequestBehavior.AllowGet);
        }

        [NoDirectAccess]
        [HttpGet]
        public JsonResult GetPhrase()
        {
            return Json(PhraseBLL.GetPhrase(CookiesControll.UserAuthenticationInfo().Name), JsonRequestBehavior.AllowGet);
        }

        [NoDirectAccess]
        [HttpPost]
        public JsonResult UpdatePassword(string pass)
        {
            Debug.WriteLine($"{pass} Senha");
            return Json(UserBLL.UpdatePassword(CookiesControll.UserAuthenticationInfo().Name, pass), JsonRequestBehavior.AllowGet);
        }

        [NoDirectAccess]
        [HttpPost]
        public JsonResult UpdateOrInsert(string[] words)
        {
            var cookie = CookiesControll.UserAuthenticationInfo();
            string word = "";
            bool ok;
            foreach (string wr in words)
                word += $"{wr};";

            word = !string.IsNullOrEmpty(word) ? word.Remove(word.Length - 1) : word;

            PhraseDTO phrase = new PhraseDTO
            {
                Frase = word,
                DataAlteracao = DateTime.Now,
                UserId = cookie.Name
            };

            Debug.WriteLine($"{phrase.Frase} \n {phrase.DataAlteracao} \n {phrase.Id} \n {phrase.UserId}");

            if (PhraseBLL.GetPhrase(cookie.Name).Id != "null")
                ok = PhraseBLL.Update(phrase);
            else
                ok = PhraseBLL.Insert(phrase);

            return Json(new { ok, url = Url.Action("Configuracao", "Configuracao") }, JsonRequestBehavior.AllowGet);
        }
    }
}