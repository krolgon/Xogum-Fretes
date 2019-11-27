using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Xogum.AcessoBanco.Entity.Contexto;
using Xogum.Annotations;
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

        public ActionResult TipoCadastro()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string senha, string ReturnUrl)
        {
            senha = Annotations.Hash.HashTexto(senha, "SHA512");
            Usuario usu = db.Usuarios.Where(t => t.Email == email && t.Senha == senha).ToList().FirstOrDefault();
            if (usu != null)
            {
                string permissoes = usu.TipoUsuario.Descricao;
                FormsAuthentication.SetAuthCookie(usu.Nome, false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usu.Email, DateTime.Now, DateTime.Now.AddMinutes(30), false, permissoes);
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
                Response.Cookies.Add(cookie);
                if ((String.IsNullOrEmpty(ReturnUrl)) && (permissoes == "Administrador"))
                    return RedirectToAction("HomeAdministrador", "Usuarios");
                if ((String.IsNullOrEmpty(ReturnUrl)) && (permissoes == "Cliente"))
                    return RedirectToAction("HomeCliente", "Usuarios");
                if ((String.IsNullOrEmpty(ReturnUrl)) && (permissoes == "Motorista"))
                    return RedirectToAction("HomeMotorista", "Motoristas");
                else
                {
                    var decodedUrl = Server.UrlDecode(ReturnUrl);
                    if (Url.IsLocalUrl(decodedUrl))
                        return Redirect(decodedUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
            }
            else { ModelState.AddModelError("", "Usuário/Senha inválidos"); return View(); }
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult RecuperarSenha()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult RecuperarSenha(string UserName)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        if (WebSecurity.UserExists(UserName))
        //        {
        //            string To = UserName, UserID, Password, SMTPPort, Host;
        //            string token = WebSecurity.GeneratePasswordResetToken(UserName);
        //            if (token == null)
        //            {
        //                // If user does not exist or is not confirmed.  

        //                return View("Index");

        //            }
        //            else
        //            {
        //                //Create URL with above token  

        //                var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = UserName, code = token }, "http") + "'>Reset Password</a>";


        //                //HTML Template for Send email  

        //                string subject = "Your changed password";

        //                string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;


        //                //Get and set the AppSettings using configuration manager.  

        //                EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);


        //                //Call send email methods.  

        //                EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);

        //            }

        //        }

        //    }
        //    return View();
        //}

        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Email(string mensagem, string email, string assunto)
        {
            if (mensagem != "" && email != "" && assunto != "")
            {
                TempData["MSG"] = Funcoes.EnviarEmail(email, assunto, mensagem);
            }
            else
            {
                TempData["MSG"] = "warning|Preencha todos os campos";
            }
            return View();


        }

    }
}