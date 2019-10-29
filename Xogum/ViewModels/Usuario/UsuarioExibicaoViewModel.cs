using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xogum.Dominio;

namespace Xogum.ViewModels.Usuario
{
    public class UsuarioExibicaoViewModel
    {
        [Display(Name = "Identificador")]
        public int Id { get; set; }

        [Display(Name = "Nome do Usuário")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "Foto")]
        public string Foto { get; set; }
        
        public virtual TipoUsuario TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}