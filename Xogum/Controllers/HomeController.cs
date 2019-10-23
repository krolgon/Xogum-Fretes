using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Xogum.AcessoBanco.Entity.Contexto;
using Xogum.Dominio;


namespace Xogum.Controllers
{

    public class HomeController : Controller
    {

        private XogumDbContexto db = new XogumDbContexto();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string senha, string ReturnUrl)
        {
            Usuario usu = db.Usuarios.Where(t => t.Email == email && t.Senha == senha).ToList().FirstOrDefault();
            if (usu != null)
            {
                string permissoes = usu.TipoUsuario.Descricao;
                //foreach (Usuario p in usu.Usuarios)
                //    permissoes += p.TipoUsuario.Descricao + ",";
                //permissoes = permissoes.Substring(0, permissoes.Length - 1);
                FormsAuthentication.SetAuthCookie(usu.Nome, false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usu.Email, 
                    DateTime.Now, DateTime.Now.AddMinutes(30), false, permissoes);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);
                if (String.IsNullOrEmpty(ReturnUrl))
                    return RedirectToAction("Index", "Home");
                else
                {
                    var decodedUrl = Server.UrlDecode(ReturnUrl);
                    if (Url.IsLocalUrl(decodedUrl))
                        return Redirect(decodedUrl);
                    else
                        return RedirectToAction("Index", "Perfils");
                }
            }
            else { ModelState.AddModelError("", "Usuário/Senha inválidos"); return View(); }
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }

}