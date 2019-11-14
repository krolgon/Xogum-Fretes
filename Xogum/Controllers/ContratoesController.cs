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

namespace Xogum.Controllers
{
    public class ContratoesController : Controller
    {
        private XogumDbContexto db = new XogumDbContexto();

        // GET: Contratoes
        public ActionResult Index()
        {
            var contratos = db.Contratos.Include(c => c.Endereco).Include(c => c.Usuario).Include(c => c.Veiculo);
            return View(contratos.ToList());
        }

        // GET: Contratoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratos.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratoes/Create
        public ActionResult Create()
        {
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "Id", "Descricao");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome");
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa");
            return View();
        }

        // POST: Contratoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Complemento,Bairro,Cidade,Estado,Cep,UsuarioId,EnderecoId,VeiculoId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contratos.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnderecoId = new SelectList(db.Enderecos, "Id", "Descricao", contrato.EnderecoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", contrato.UsuarioId);
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa", contrato.VeiculoId);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratos.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "Id", "Descricao", contrato.EnderecoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", contrato.UsuarioId);
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa", contrato.VeiculoId);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Complemento,Bairro,Cidade,Estado,Cep,UsuarioId,EnderecoId,VeiculoId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnderecoId = new SelectList(db.Enderecos, "Id", "Descricao", contrato.EnderecoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", contrato.UsuarioId);
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa", contrato.VeiculoId);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratos.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contratos.Find(id);
            db.Contratos.Remove(contrato);
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
