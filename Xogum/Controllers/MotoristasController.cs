﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Xogum.AcessoBanco.Entity.Contexto;
using Xogum.Annotations;
using Xogum.Dominio;
using Xogum.ViewModels.Motorista;
using Xogum.ViewModels.Usuario;

namespace Xogum.Controllers
{
    public class MotoristasController : Controller
    {
        private XogumDbContexto db = new XogumDbContexto();

        // GET: Motoristas
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var motoristas = db.Motoristas.Include(m => m.Usuario);
            return View(motoristas.ToList());
        }

        // GET: Motoristas/Details/5
        [Authorize(Roles = "Motorista")]
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
        public ActionResult Cadastro(MotoristaViewModel viewModel, HttpPostedFileBase arqFoto,
        HttpPostedFileBase arqCnh, HttpPostedFileBase arqCriminal, HttpPostedFileBase arqFotoComCnh,
        HttpPostedFileBase arqCrlv, HttpPostedFileBase arqVeiculo, string local)
        {
            
            if (ModelState.IsValid)
            {
                Upload.CriarDiretorio();
                if (arqFoto != null)
                {
                    string nomeFoto = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqFoto.FileName);
                    string repFoto = Upload.UploadArquivo(arqFoto, nomeFoto);
                    if (arqCnh != null)
                    {
                        string nomeCnh = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqCnh.FileName);
                        string repCnh = Upload.UploadArquivo(arqCnh, nomeCnh);
                        if (arqCriminal != null)
                        {
                            string nomeCriminal = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqCriminal.FileName);
                            string repCriminal = Upload.UploadArquivo(arqCriminal, nomeCriminal);
                            if (arqFotoComCnh != null)
                            {
                                string nomeFotoCnh = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqFotoComCnh.FileName);
                                string repFotoCnh = Upload.UploadArquivo(arqFotoComCnh, nomeFotoCnh);
                                if (arqCrlv != null)
                                {
                                    string nomeCrlv = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqCrlv.FileName);
                                    string repCrlv = Upload.UploadArquivo(arqCrlv, nomeCrlv);
                                    if (arqVeiculo != null)
                                    {
                                        string nomeVeiculo = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqVeiculo.FileName);
                                        string repVeiculo = Upload.UploadArquivo(arqVeiculo, nomeVeiculo);
                                        //valor = Upload.UploadMultArquivo(arqFoto, arqCnh, arqCriminal, arqFotoComCnh, arqCrlv, arqVeiculo,
                                        //    nomeFoto, nomeCnh, nomeCriminal, nomeFotoCnh, nomeCrlv, nomeVeiculo);
                                        Usuario usuario = new Usuario();
                                        usuario.Id = viewModel.Id;
                                        usuario.Nome = viewModel.Nome;
                                        usuario.Email = viewModel.Email;
                                        usuario.Senha = Annotations.Hash.HashTexto(viewModel.Senha, "SHA512");
                                        usuario.Telefone = viewModel.Telefone;
                                        usuario.Cpf = viewModel.Cpf;
                                        usuario.Foto = nomeFoto;
                                        usuario.TipoUsuarioId = 1;
                                        usuario.Avaliacao = 0;
                                        usuario.Localizacao = "-";
                                        usuario.DataNascimento = Convert.ToDateTime(viewModel.DataNascimento);
                                        db.Usuarios.Add(usuario);

                                        Motorista motorista = new Motorista();
                                        motorista.Cnh = nomeCnh;
                                        motorista.CertidaoCriminal = nomeCriminal;
                                        motorista.Status = false;
                                        motorista.DataCriacao = DateTime.Now;
                                        motorista.FotoComCnh = nomeFotoCnh;
                                        motorista.Verificacao = false;
                                        db.Motoristas.Add(motorista);

                                        Veiculo veiculo = new Veiculo();
                                        veiculo.Placa = viewModel.Placa;
                                        veiculo.Crlv = nomeCrlv;
                                        veiculo.Modelo = viewModel.Modelo;
                                        veiculo.Cor = viewModel.Cor;
                                        veiculo.Foto = nomeVeiculo;
                                        veiculo.Status = false;
                                        veiculo.DataCriacao = DateTime.Now;
                                        db.Veiculos.Add(veiculo);
                                        db.SaveChanges();
                                        return RedirectToAction("Login", "Home");
                                    }
                                    else
                                    {
                                        return View(viewModel);
                                    }
                                }
                                else
                                {
                                    return View(viewModel);
                                }
                            }
                            else
                            {
                                return View(viewModel);
                            }
                        }
                        else
                        {

                            return View(viewModel);
                        }
                    }
                    else
                    {
                        return View(viewModel);
                    }
                }
                else //Final If
                {
                    if (arqCnh != null)
                    {
                        string nomeCnh = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqCnh.FileName);
                        string repCnh = Upload.UploadArquivo(arqCnh, nomeCnh);
                        if (arqCriminal != null)
                        {
                            string nomeCriminal = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqCriminal.FileName);
                            string repCriminal = Upload.UploadArquivo(arqCriminal, nomeCriminal);
                            if (arqFotoComCnh != null)
                            {
                                string nomeFotoCnh = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqFotoComCnh.FileName);
                                string repFotoCnh = Upload.UploadArquivo(arqFotoComCnh, nomeFotoCnh);
                                if (arqCrlv != null)
                                {
                                    string nomeCrlv = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqCrlv.FileName);
                                    string repCrlv = Upload.UploadArquivo(arqCrlv, nomeCrlv);
                                    if (arqVeiculo != null)
                                    {
                                        string nomeVeiculo = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(arqVeiculo.FileName);
                                        string repVeiculo = Upload.UploadArquivo(arqVeiculo, nomeVeiculo);
                                        //valor = Upload.UploadMultArquivo(arqFoto, arqCnh, arqCriminal, arqFotoComCnh, arqCrlv, arqVeiculo,
                                        //    nomeFoto, nomeCnh, nomeCriminal, nomeFotoCnh, nomeCrlv, nomeVeiculo);
                                        Usuario usuario = new Usuario();
                                        usuario.Id = viewModel.Id;
                                        usuario.Nome = viewModel.Nome;
                                        usuario.Email = viewModel.Email;
                                        usuario.Senha = Annotations.Hash.HashTexto(viewModel.Senha, "SHA512");
                                        usuario.Telefone = viewModel.Telefone;
                                        usuario.Cpf = viewModel.Cpf;
                                        usuario.Foto = "Sem foto";
                                        usuario.Localizacao = local;
                                        usuario.TipoUsuarioId = 1;
                                        db.Usuarios.Add(usuario);

                                        Motorista motorista = new Motorista();
                                        motorista.Cnh = nomeCnh;
                                        motorista.CertidaoCriminal = nomeCriminal;
                                        motorista.Status = false;
                                        motorista.DataCriacao = DateTime.Now;
                                        motorista.FotoComCnh = nomeFotoCnh;
                                        db.Motoristas.Add(motorista);

                                        Veiculo veiculo = new Veiculo();
                                        veiculo.Placa = viewModel.Placa;
                                        veiculo.Crlv = nomeCrlv;
                                        veiculo.Modelo = viewModel.Modelo;
                                        veiculo.Cor = viewModel.Cor;
                                        veiculo.Foto = nomeVeiculo;
                                        veiculo.Status = false;
                                        veiculo.DataCriacao = DateTime.Now;
                                        db.Veiculos.Add(veiculo);
                                        db.SaveChanges();
                                        return RedirectToAction("Login", "Home");
                                    }
                                    else
                                    {
                                        return View(viewModel);
                                    }
                                }
                                else
                                {
                                    return View(viewModel);
                                }
                            }
                            else
                            {
                                return View(viewModel);
                            }
                        }
                        else
                        {

                            return View(viewModel);
                        }
                    }
                    else
                    {
                        return View(viewModel);
                    }
                }
            }
            else
            {
                return View(viewModel);
            }
        }
        [Authorize(Roles = "Motorista")]
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

        //LISTAR MOTORISTAS INATIVOS
        [Authorize(Roles = "Administrador")]
        public ActionResult MotoristasStatus()
        {
            var motoristasStatus = db.Motoristas
                .Include(m => m.Usuario)
                .Where(m => m.Verificacao == false);

            return View(Mapper.Map<List<Motorista>, List<MotoristaExibicaoViewModel>>(motoristasStatus.ToList()));
        }
        // ALTERAÇÃO DE STATUS DO MOTORISTAS
        [Authorize(Roles = "Administrador")]
        public ActionResult ValidarMotoristas(int? id, [Bind(Include = "Id,Cnh,CertidaoCriminal,Status,Cnh,Localizacao, UsuarioId ")] Motorista motorista)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var x = db.Motoristas.Where(v => v.Id == id).ToList().FirstOrDefault();
            Motorista mot = db.Motoristas.Find(motorista.Id);
            mot.Verificacao = true;
            db.Entry(mot).State = EntityState.Modified;
            db.SaveChanges();
            //MotoristaExibicaoViewModel mv = new MotoristaExibicaoViewModel();
            //mv.Cnh = x.Veiculos.FirstOrDefault().Placa;
            return View(Mapper.Map<Motorista, MotoristaExibicaoViewModel>(x));
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidarMotorista([Bind(Include = "Id,Cnh,CertidaoCriminal,Status,Cnh,Localizacao, UsuarioId ")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                Motorista mot = db.Motoristas.Find(motorista.Id);
                mot.Status = true;
                mot.Verificacao = true;
                db.Entry(mot).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("HomeAdministrador", "Usuarios");
            }


            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", motorista.UsuarioId);
            return View(motorista);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Resposta(string mensagem, string email, string assunto)
        {
            if (mensagem != "" && email != "" && assunto != "")
            {
                TempData["MSG"] = Funcoes.EnviarEmail(email, assunto, mensagem);

            }
            else
            {
                TempData["MSG"] = "warning|Preencha todos os campos";
            }
            return RedirectToAction("HomeAdministrador", "Usuarios");

        }
        [Authorize(Roles = "Motorista")]
        public ActionResult HomeMotorista()
        {
            return View(Mapper.Map<List<Motorista>, List<MotoristaExibicaoViewModel>>(db.Motoristas.ToList()));
        }
    }
}

