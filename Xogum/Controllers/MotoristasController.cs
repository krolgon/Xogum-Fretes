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
using Xogum.ViewModels.Motorista;
using Xogum.ViewModels.Usuario;

namespace Xogum.Controllers
{
    public class MotoristasController : Controller
    {
        private XogumDbContexto db = new XogumDbContexto();

        // GET: Motoristas
        public ActionResult Index()
        {
            var motoristas = db.Motoristas.Include(m => m.Usuario);
            return View(motoristas.ToList());
        }

        // GET: Motoristas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motoristas.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            return View(motorista);
        }

        public ActionResult Cadastro()
        {
            //ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(MotoristaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                usuario.Id = viewModel.Id;
                usuario.Nome = viewModel.Nome;
                usuario.Email = viewModel.Email;
                usuario.Senha = Annotations.Hash.HashTexto(viewModel.Senha, "SHA512");
                usuario.Telefone = viewModel.Telefone;
                usuario.Cpf = viewModel.Cpf;
                usuario.Foto = viewModel.Foto;
                usuario.TipoUsuarioId = 1;
                db.Usuarios.Add(usuario);

                Motorista motorista = new Motorista();
                motorista.Cnh = viewModel.Cnh;
                motorista.CertidaoCriminal = viewModel.CertidaoCriminal;
                motorista.Status = false;
                motorista.DataCriacao = DateTime.Now;
                motorista.FotoComCnh = viewModel.FotoComCnh;
                motorista.Localizacao = "-";
                db.Motoristas.Add(motorista);

                Veiculo veiculo = new Veiculo();
                veiculo.Placa = viewModel.Placa;
                veiculo.Crlv = viewModel.Crlv;
                veiculo.Modelo = viewModel.Modelo;
                veiculo.Cor = viewModel.Cor;
                veiculo.Foto = viewModel.FotoVeiculo;
                veiculo.Status = false;
                veiculo.DataCriacao = DateTime.Now;
                db.Veiculos.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Login", "Home");
            }
            return View(viewModel);
        }
     
        // GET: Motoristas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motoristas.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", motorista.UsuarioId);
            return View(motorista);
        }

        // POST: Motoristas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cnh,CertidaoCriminal,Status,Cnh,UsuarioId")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                motorista.DataCriacao = DateTime.Now;
                db.Entry(motorista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", motorista.UsuarioId);
            return View(motorista);
        }

        // GET: Motoristas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorista motorista = db.Motoristas.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            return View(motorista);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motorista motorista = db.Motoristas.Find(id);
            db.Motoristas.Remove(motorista);
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
