using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Xogum.AcessoBanco.Entity.Contexto;
using Xogum.Dominio;
using Xogum.ViewModels.TiposUsuario;

namespace Xogum.Controllers
{
    [Authorize]
    public class TipoUsuariosController : Controller
    {
        private XogumDbContexto db = new XogumDbContexto();

        // GET: TipoUsuarios
        public ActionResult Index()
        {
            return View(Mapper.Map<List<TipoUsuario>, List<TiposUsuarioExibicaoViewModel>>(db.TipoUsuarios.ToList()));
        }

        // GET: TipoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.TipoUsuarios.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<TipoUsuario, TiposUsuarioExibicaoViewModel>(tipoUsuario));
        }

        // GET: TipoUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] TiposUsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                TipoUsuario tipoUsuario = Mapper.Map<TiposUsuarioViewModel, TipoUsuario>(viewModel);
                db.TipoUsuarios.Add(tipoUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: TipoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.TipoUsuarios.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<TipoUsuario, TiposUsuarioExibicaoViewModel>(tipoUsuario));
        }

        // POST: TipoUsuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TiposUsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                TipoUsuario tipoUsuario = Mapper.Map<TiposUsuarioViewModel, TipoUsuario>(viewModel);
                db.Entry(tipoUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: TipoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.TipoUsuarios.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<TipoUsuario, TiposUsuarioExibicaoViewModel>(tipoUsuario));
        }

        // POST: TipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoUsuario tipoUsuario = db.TipoUsuarios.Find(id);
            db.TipoUsuarios.Remove(tipoUsuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
