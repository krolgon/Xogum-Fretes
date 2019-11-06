using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Cadastro(MotoristaViewModel viewModel, HttpPostedFileBase arqFoto,
        HttpPostedFileBase arqCnh, HttpPostedFileBase arqCriminal, HttpPostedFileBase arqFotoComCnh,
        HttpPostedFileBase arqCrlv, HttpPostedFileBase arqVeiculo)
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
        public ActionResult MotoristasStatus()
        {
            var motoristasStatus = db.Motoristas
                .Include(m => m.Usuario)
                .Where(m => m.Status == false);
            return View(Mapper.Map<List<Motorista>, List<MotoristaExibicaoViewModel>>(motoristasStatus.ToList()));
        }
        // ALTERAÇÃO DE STATUS DO MOTORISTAS
        public ActionResult ValidarMotoristas(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var x = db.Motoristas.Where(v => v.Id == id).ToList().FirstOrDefault();
            //MotoristaExibicaoViewModel mv = new MotoristaExibicaoViewModel();
            //mv.Cnh = x.Veiculos.FirstOrDefault().Placa;
            return View(Mapper.Map<Motorista, MotoristaExibicaoViewModel>(x));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidarMotorista([Bind(Include = "Id,Cnh,CertidaoCriminal,Status,Cnh,Localizacao, UsuarioId ")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                var loc = motorista.Usuario.Localizacao;
                var foto = motorista.FotoComCnh;

                db.Entry(motorista).State = EntityState.Modified;
                motorista.Usuario.Localizacao = "-";
                motorista.FotoComCnh = "foto";
                motorista.DataCriacao = DateTime.Now;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", motorista.UsuarioId);
            return View(motorista);
        }
    }
}
