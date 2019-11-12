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
    }
}