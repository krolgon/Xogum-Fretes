using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Xogum.Annotations
{
    public class Upload
    {
        public static bool CriarDiretorio()
        {
            string dir = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\"; // caminho fisico da aplicação
            if (!Directory.Exists(dir))
            {
                //Caso não exista devemos criar
                Directory.CreateDirectory(dir);
                return true;
            }
            else
            {
                return false;
            }
        } // Cria diretório na maquina local

        public static bool ExcluirArquivo(string arq)
        {
            if (File.Exists(arq))
            {
                File.Delete(arq);
                return true;
            }
            else
            {
                return false;
            }
        } // Exclui baseado na string que esta armazenado no banco

        public static string UploadArquivo(HttpPostedFileBase flpUpload, string nome)
        {
            try
            {
                double permitido = 900;
                if (flpUpload != null)
                {
                    string arq = Path.GetFileName(flpUpload.FileName);
                    double tamanho = Convert.ToDouble(flpUpload.ContentLength) / 1024;
                    string extensao = Path.GetExtension(flpUpload.FileName).ToLower(); // tudo em mínusculo 
                    string diretorio = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\" + nome;
                    if (tamanho > permitido)
                    {
                        return "Tamanho máximo permitido é de " + permitido + "kb";
                    }
                    else if ((extensao != ".png" && extensao != ".jpg"))
                    {
                        return "Extensão inválida, só são permitidas .png e .jpg";
                    }
                    else
                    {
                        if (!File.Exists(diretorio))
                        {
                            flpUpload.SaveAs(diretorio);
                            return "Sucesso";
                        }
                        else
                        {
                            return "Já existe um arquivo com esse nome";
                        }
                    }
                }
                else
                {
                    return "Erro no Upload.";
                }
            }
            catch
            {
                return "Erro no Upload";
            }
        }

        public static string UploadMultArquivo(HttpPostedFileBase img1, HttpPostedFileBase img2, HttpPostedFileBase img3, HttpPostedFileBase img4, HttpPostedFileBase img5, HttpPostedFileBase img6, string nome1, string nome2, string nome3, string nome4, string nome5, string  nome6)
        {
            if (UploadArquivo(img1, nome1) == "Sucesso")
            {
                if(UploadArquivo(img2, nome2) == "Sucesso")
                {
                    if(UploadArquivo(img3, nome3) == "Sucesso")
                    {
                        if(UploadArquivo(img4, nome4) == "Sucesso")
                        {
                            if(UploadArquivo(img5, nome5) == "Sucesso")
                            {
                                if(UploadArquivo(img6, nome6) == "Sucesso")
                                {
                                    return "Sucesso";
                                }
                                else
                                {
                                    return "Erro Arquivo 6";
                                }
                            }
                            else
                            {
                                return "Erro Arquivo 5";
                            }
                        }
                        else
                        {
                            return "Erro Arquivo 4";
                        }
                    }else
                    {
                        return "Erro Arquivo 3";
                    }
                }
                else
                {
                    return "Erro Arquivo 2";
                }
            }
            else
            {
                return "Erro Arquivo 1";
            }
            
            
            
            
            //string arq;
            //double tamanho;
            //string extensao;
            //string diretorio;
            //string resultado = "";
            //// dando um erro que o httppostedfilebase esta duplicando o nome da imagem por causa 
            //// de estar usando a mesma variavel sobrescrevendo a mesma
            //// gerar uma variavel unica para cada parametro do método
            //try
            //{
            //    if (img1 != null)
            //    {
            //        arq = Path.GetFileName(img1.FileName);
            //        tamanho = Convert.ToDouble(img1.ContentLength) / 1024;
            //        extensao = Path.GetExtension(img1.FileName).ToLower(); // tudo em mínusculo 
            //        diretorio = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\" + nome1;
            //        if (tamanho > 900)
            //        {
            //            return "Tamanho máximo permitido é de 900 kb";
            //        }
            //        else if ((extensao != ".png" && extensao != ".jpg"))
            //        {
            //            return "Extensão inválida, só são permitidas .png e .jpg";
            //        }
            //        else
            //        {
            //            if (!File.Exists(diretorio))
            //            {
            //                img1.SaveAs(diretorio);
            //                resultado += "Sucesso";
            //            }
            //            else
            //            {
            //                return "Já existe um arquivo com esse nome";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return "Erro no Upload.";
            //    }
            //    if (img2 != null)
            //    {
            //        arq = Path.GetFileName(img2.FileName);
            //        tamanho = Convert.ToDouble(img2.ContentLength) / 1024;
            //        extensao = Path.GetExtension(img2.FileName).ToLower(); // tudo em mínusculo 
            //        diretorio = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\" + nome2;
            //        if (tamanho > 900)
            //        {
            //            return "Tamanho máximo permitido é de 900 kb";
            //        }
            //        else if ((extensao != ".png" && extensao != ".jpg"))
            //        {
            //            return "Extensão inválida, só são permitidas .png e .jpg";
            //        }
            //        else
            //        {
            //            if (!File.Exists(diretorio))
            //            {
            //                img2.SaveAs(diretorio);
            //                resultado += "Sucesso";
            //            }
            //            else
            //            {
            //                return "Já existe um arquivo com esse nome";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return "Erro no Upload.";
            //    }
            //    if (img3 != null)
            //    {
            //        arq = Path.GetFileName(img3.FileName);
            //        tamanho = Convert.ToDouble(img3.ContentLength) / 1024;
            //        extensao = Path.GetExtension(img3.FileName).ToLower(); // tudo em mínusculo 
            //        diretorio = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\" + nome3;
            //        if (tamanho > 900)
            //        {
            //            return "Tamanho máximo permitido é de 900 kb";
            //        }
            //        else if ((extensao != ".png" && extensao != ".jpg"))
            //        {
            //            return "Extensão inválida, só são permitidas .png e .jpg";
            //        }
            //        else
            //        {
            //            if (!File.Exists(diretorio))
            //            {
            //                img3.SaveAs(diretorio);
            //                resultado += "Sucesso";
            //            }
            //            else
            //            {
            //                return "Já existe um arquivo com esse nome";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return "Erro no Upload.";
            //    }
            //    if (img4 != null)
            //    {
            //        arq = Path.GetFileName(img4.FileName);
            //        tamanho = Convert.ToDouble(img4.ContentLength) / 1024;
            //        extensao = Path.GetExtension(img4.FileName).ToLower(); // tudo em mínusculo 
            //        diretorio = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\" + nome4;
            //        if (tamanho > 900)
            //        {
            //            return "Tamanho máximo permitido é de 900 kb";
            //        }
            //        else if ((extensao != ".png" && extensao != ".jpg"))
            //        {
            //            return "Extensão inválida, só são permitidas .png e .jpg";
            //        }
            //        else
            //        {
            //            if (!File.Exists(diretorio))
            //            {
            //                img4.SaveAs(diretorio);
            //                resultado += "Sucesso";
            //            }
            //            else
            //            {
            //                return "Já existe um arquivo com esse nome";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return "Erro no Upload.";
            //    }
            //    if (img5 != null)
            //    {
            //        arq = Path.GetFileName(img5.FileName);
            //        tamanho = Convert.ToDouble(img5.ContentLength) / 1024;
            //        extensao = Path.GetExtension(img5.FileName).ToLower(); // tudo em mínusculo 
            //        diretorio = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\" + nome5;
            //        if (tamanho > 900)
            //        {
            //            return "Tamanho máximo permitido é de 900 kb";
            //        }
            //        else if ((extensao != ".png" && extensao != ".jpg"))
            //        {
            //            return "Extensão inválida, só são permitidas .png e .jpg";
            //        }
            //        else
            //        {
            //            if (!File.Exists(diretorio))
            //            {
            //                img5.SaveAs(diretorio);
            //                resultado += "Sucesso";
            //            }
            //            else
            //            {
            //                return "Já existe um arquivo com esse nome";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return "Erro no Upload.";
            //    }
            //    if (img6 != null)
            //    {
            //        arq = Path.GetFileName(img6.FileName);
            //        tamanho = Convert.ToDouble(img6.ContentLength) / 1024;
            //        extensao = Path.GetExtension(img6.FileName).ToLower(); // tudo em mínusculo 
            //        diretorio = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\" + nome6;
            //        if (tamanho > 900)
            //        {
            //            return "Tamanho máximo permitido é de 900 kb";
            //        }
            //        else if ((extensao != ".png" && extensao != ".jpg"))
            //        {
            //            return "Extensão inválida, só são permitidas .png e .jpg";
            //        }
            //        else
            //        {
            //            if (!File.Exists(diretorio))
            //            {
            //                img6.SaveAs(diretorio);
            //                resultado += "Sucesso";
            //            }
            //            else
            //            {
            //                return "Já existe um arquivo com esse nome";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return "Erro no Upload.";
            //    }
            //    if(resultado== "SucessoSucessoSucessoSucessoSucessoSucesso")
            //    {
            //        return "Sucesso";
            //    }
            //    else
            //    {
            //        return "Erro no Cadastro de imagens";
            //    }
            //}
            //catch
            //{
            //    return "Erro no Upload";
            //}
        }
    }
}