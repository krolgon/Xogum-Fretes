﻿using AutoMapper;
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
using Xogum.ViewModels.Usuario;

namespace Xogum.Controllers
{
    public class UsuariosController : Controller
    {
        private XogumDbContexto db = new XogumDbContexto();

        // GET: Usuarios
        //[Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Usuario>, List<UsuarioExibicaoViewModel>>(db.Usuarios.ToList()));
        }

        [Authorize(Roles = "Cliente")]
        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Usuario, UsuarioExibicaoViewModel>(usuario));
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.TipoUsuarioId = new SelectList(db.TipoUsuarios, "Id", "Descricao");
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,Senha,ConfirmaSenha,Telefone,Cpf,Foto")] UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = Mapper.Map<UsuarioViewModel, Usuario>(viewModel);
                usuario.TipoUsuarioId = 2;
                usuario.Senha = Annotations.Hash.HashTexto(viewModel.Senha, "SHA512");
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("HomeCliente","Usuarios");
            }

            return View(viewModel);
        }

        //[Authorize(Roles = "Cliente")]
        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Usuario, UsuarioExibicaoViewModel>(usuario));
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Senha,Telefone,Cpf,Foto,TipoUsuarioId")] UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = Mapper.Map<UsuarioViewModel, Usuario>(viewModel);
                usuario.TipoUsuarioId = 2;
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Usuarios/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Usuario, UsuarioExibicaoViewModel>(usuario));
        }

        // POST: Usuarios/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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

        [Authorize(Roles = "Cliente")]
        public ActionResult HomeCliente()
        {
            return View();
        }


        /*============================================================================================*/
        /*===================================ADMINISTRADOR============================================*/
        /*============================================================================================*/

        public ActionResult HomeAdministrador()
        {
            return View();
        }
    }
}
