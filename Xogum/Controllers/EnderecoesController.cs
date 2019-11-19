﻿using System;
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
    public class EnderecoesController : Controller
    {
        private XogumDbContexto db = new XogumDbContexto();

        // GET: Enderecoes
        public ActionResult Index()
        {
            var enderecos = db.Enderecos.Include(e => e.Usuario).Include(e => e.Veiculo);
            return View(enderecos.ToList());
        }

        // GET: Enderecoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Enderecoes/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome");
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa");
            return View();
        }

        // POST: Enderecoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EnderecoInicial,NumeroInicial,EnderecoFinal,NumeroFinal,Complemento,Bairro,Cidade,Estado,Cep,UsuarioId,VeiculoId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Enderecos.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", endereco.UsuarioId);
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa", endereco.VeiculoId);
            return View(endereco);
        }

        // GET: Enderecoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", endereco.UsuarioId);
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa", endereco.VeiculoId);
            return View(endereco);
        }

        // POST: Enderecoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EnderecoInicial,NumeroInicial,EnderecoFinal,NumeroFinal,Complemento,Bairro,Cidade,Estado,Cep,UsuarioId,VeiculoId")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", endereco.UsuarioId);
            ViewBag.VeiculoId = new SelectList(db.Veiculos, "Id", "Placa", endereco.VeiculoId);
            return View(endereco);
        }

        // GET: Enderecoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Enderecos.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.Enderecos.Find(id);
            db.Enderecos.Remove(endereco);
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
