using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xogum.Annotations;
using Xogum.Dominio;

namespace Xogum.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        [Display(Name = "Identificador")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage ="O nome é um campo obrigatório")]
        [MaxLength(150, ErrorMessage ="O máximo são 150 caracteres")]
        [MinLength(4, ErrorMessage ="O número minímo de caracteres é 4")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="O campo e-mail é obrigatório")]
        [MaxLength(100, ErrorMessage ="O máximo são 100 caracteres")]
        [MinLength(7, ErrorMessage ="O mínimo são 7 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12})", ErrorMessage = "A senha deve conter aos menos uma letra maiúscula, minúscula e um número.Deve ser no mínimo 6 caracteres")]
        public string Senha { get; set; }

        [Display(Name ="Telefone")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(8,ErrorMessage ="Informe o telefone correto")]
        [MaxLength(11,ErrorMessage ="O campo deve possuir até 11 números")]                
        public string Telefone { get; set; }

        [Display(Name ="CPF")]
        [CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }

        [Display(Name ="Foto")]
        public string Foto { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}