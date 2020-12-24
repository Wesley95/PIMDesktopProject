using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIMWebProject.Helpers;
using PIMDesktopProjectBLL;
using PIMDesktopProjectDTO;
using System.Web.Security;
using System.Diagnostics;

namespace PIMWebProject.Controllers
{
    //[Authorize(Roles = "Client")]
    public class TrocasController : Controller
    {
        const int max_trade = 7;

        // GET: Trocas
        [NoDirectAccess]
        public ActionResult Trocas()
        {
            var cookie = CookiesControll.UserAuthenticationInfo();

            if (cookie.UserData == "Client")
            {
                var list = TradeBLL.ListAllByIdLimited(0, max_trade, cookie.Name);

                foreach (var item in list)
                {
                    item.ValorVenda = FillWithZeros(item.ValorVenda);
                    item.ValorCompra = FillWithZeros(item.ValorCompra);
                    item.ValorTaxa = FillWithZeros(item.ValorTaxa);
                }

                ViewData["Trocas"] = list;
                ViewData["Historico"] = HistoricBLL.ListAll(cookie.Name, 0, 7);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        public string FillWithZeros(string text)
        {
            if (!string.IsNullOrEmpty(text) && text.Length > 0 && !string.IsNullOrWhiteSpace(text))
            {
                string[] aux = text.Split('.');
                return $"{aux[0]}.{aux[1].PadRight(8, '0')}";
            }
            else return "";
        }

        [NoDirectAccess]
        public ActionResult Add()
        {
            var cookie = CookiesControll.UserAuthenticationInfo();
            var genericUser = GenericUserBLL.GetUserById(cookie.Name);

            if (cookie.UserData == "Client")
            {
                if (genericUser.UserID != "null")
                {
                    ViewData["Coins"] = TradeCoinBLL.ListAll();
                    ViewData["Operations"] = OperationBLL.ListAll();
                    ViewBag.UserId = genericUser.UserID;
                    return View();
                }
                else
                {
                    var quitCookie = new HttpCookie(CookiesControll.MasterCookie)
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };
                    Response.Cookies.Add(quitCookie);

                    FormsAuthentication.SignOut();

                    return RedirectToAction("SignIn", "Login", new { area = "" });
                }
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [NoDirectAccess]
        [HttpPost]
        public JsonResult Remove(TradeDTO[] trade)
        {
            bool deleted = false;
            string text = "";
            if (TradeBLL.Remove(trade))
            {
                deleted = true;
                text = trade.Length > 1 ? "Removidos" : "Removido";
                text += $" {trade.Length} ";
                text += trade.Length > 1 ? "transações" : "transação";

                HistoricDTO hist = new HistoricDTO
                {
                    Data = DateTime.Now.Date,
                    UserId = CookiesControll.UserAuthenticationInfo().Name,
                    Descricao = text
                };

                deleted = HistoricBLL.RegisterHistoric(hist);
            }

            return Json(new { deleted, url = Url.Action("Trocas", "Trocas") }, JsonRequestBehavior.AllowGet);
        }

        [NoDirectAccess]
        [HttpGet]
        public JsonResult UserId()
        {
            return Json(CookiesControll.UserAuthenticationInfo().Name, JsonRequestBehavior.AllowGet);
        }

        [NoDirectAccess]
        [HttpPost]
        public JsonResult CreateTrade(TradeDTO trade)
        {
            var coin = TradeCoinBLL.ListAll();
            var type = OperationBLL.ListAll();
            var cookie_info = CookiesControll.UserAuthenticationInfo().Name;

            trade.Tipo = type.Where(t => t.Id == trade.Tipo).FirstOrDefault().Tipo;
            trade.UserId = cookie_info;

            if (!string.IsNullOrEmpty(trade.MoedaCompra) && !string.IsNullOrWhiteSpace(trade.MoedaCompra))
            {
                trade.MoedaCompra = coin.Where(c => c.Id == trade.MoedaCompra).FirstOrDefault().Sigla;
            }

            if (!string.IsNullOrEmpty(trade.MoedaVenda) && !string.IsNullOrWhiteSpace(trade.MoedaVenda))
            {
                trade.MoedaVenda = coin.Where(c => c.Id == trade.MoedaVenda).FirstOrDefault().Sigla;
            }

            if (!string.IsNullOrEmpty(trade.MoedaTaxa) && !string.IsNullOrWhiteSpace(trade.MoedaTaxa))
            {
                trade.MoedaTaxa = coin.Where(c => c.Id == trade.MoedaTaxa).FirstOrDefault().Sigla;
            }

            bool inserts_ok = false;

            if (TradeBLL.RegisterUser(trade))
            {
                inserts_ok = true;

                HistoricDTO hist = new HistoricDTO
                {
                    Data = DateTime.Now.Date,
                    UserId = cookie_info,
                    Descricao = $"Adicionado uma nova {trade.Tipo}"
                };

                inserts_ok = HistoricBLL.RegisterHistoric(hist);
            }

            var url = Url.Action("Trocas", "Trocas");

            return Json(new { insert = inserts_ok, url }, JsonRequestBehavior.AllowGet);
        }

        [NoDirectAccess]
        [HttpGet]
        public JsonResult GetHistoric(int value, bool increment)
        {
            bool has = false;
            List<HistoricDTO> temp = new List<HistoricDTO>();

            int init = (7 * value);
            init = value <= 0 ? 0 : init;
            int end = 7;

            temp = HistoricBLL.ListAll(CookiesControll.UserAuthenticationInfo().Name, init, end);
            has = temp.Count > 0 ? true : false;

            return Json(new { has, temp }, JsonRequestBehavior.AllowGet);
        }

        [NoDirectAccess]
        [HttpGet]
        public JsonResult GetTrades(int value, bool increment)
        {
            bool has = false;
            List<TradeDTO> temp = new List<TradeDTO>();

            int init = (max_trade * value);
            init = value <= 0 ? 0 : init;
            int end = max_trade;

            temp = TradeBLL.ListAllByIdLimited(init, end, CookiesControll.UserAuthenticationInfo().Name);

            foreach (var item in temp)
            {
                item.ValorVenda = FillWithZeros(item.ValorVenda);
                item.ValorCompra = FillWithZeros(item.ValorCompra);
                item.ValorTaxa = FillWithZeros(item.ValorTaxa);
            }

            has = temp.Count > 0 ? true : false;

            return Json(new { has, temp }, JsonRequestBehavior.AllowGet);
        }
    }
}