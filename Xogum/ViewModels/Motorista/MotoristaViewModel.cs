using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Xogum.Annotations;
using Xogum.ViewModels.Usuario;

namespace Xogum.ViewModels.Motorista
{
    public class MotoristaViewModel
    {

        /*Cadastro de Usuário*/
        [Display(Name = "Nome do Usuário")]
        [Required(ErrorMessage = "O nome é um campo obrigatório")]
        [MaxLength(150, ErrorMessage = "O máximo são 150 caracteres")]
        [MinLength(4, ErrorMessage = "O número minímo de caracteres é 4")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        [MaxLength(100, ErrorMessage = "O máximo são 100 caracteres")]
        [MinLength(7, ErrorMessage = "O mínimo são 7 caracteres")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,12})", ErrorMessage = "A senha deve conter aos menos uma letra maiúscula, minúscula e um número.Deve ser no mínimo 6 caracteres")]
        public string Senha { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(8, ErrorMessage = "Informe o telefone correto")]
        [MaxLength(11, ErrorMessage = "O campo deve possuir até 11 números")]
        public string Telefone { get; set; }


        [Display(Name = "CPF")]
        [CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }

        [Display(Name = "Foto")]
        public string Foto { get; set; }

        [Display(Name = "Data de Nascimento")]
        public string DataNascimento { get; set; }

        [Display(Name = "Localização")]
        public string Localização { get; set; }


        /*Motorista*/

        [Display(Name ="Identificador")]
        public int Id { get; set; }

        [Display(Name = "CNH(Foto)")]
        //[Required(ErrorMessage = "A foto da CNH é um campo obrigatório")]
        public string Cnh { get; set; }

        [Display(Name = "CND(Foto)")]
        //[Required(ErrorMessage = "A foto da certidão criminal é um campo obrigatório")]
        public string CertidaoCriminal { get; set; }

        [Display(Name ="Status")]
        [Required]
        public Boolean Status { get; set; }

        [Display(Name="Data de Criação")]
        [Required]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Verificação")]
        [Required]
        public Boolean Verificacao { get; set; }


        /*Veículo*/

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Placa é um campo obrigatório")]
        [MaxLength(7, ErrorMessage = "O máximo são 7 caracteres")]
        [MinLength(7, ErrorMessage = "O mínimo são 7 caracteres")]
        public string Placa { get; set; }

        [Display(Name = "CRLV")]
        //[Required(ErrorMessage = "O campo CRLV é obrigatório")]
        public string Crlv { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "O campo modelo é obrigatório")]
        public string Modelo { get; set; }

        [Display(Name = "Cor")]
        [Required(ErrorMessage = "O campo cor é obrigatório")]
        public string Cor { get; set; }

        [Display(Name = "Veículo(Foto)")]
        //[Required(ErrorMessage = "O campo foto do veículo é obrigatório")]
        public string FotoVeiculo { get; set; }

        [Display(Name = "Foto com CNH")]
        //[Required(ErrorMessage = "O campo foto é obrigatório")]
        public string FotoComCnh { get; set; }

        [Display(Name = "Localização")]
        public string Localizacao { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O campo status é obrigatório")]
        public Boolean StatusVeiculo { get; set; }

        [Display(Name = "Data de Criação")]
        [Column(TypeName = "DateTime2")]
        public DateTime DataCriacaoVeiculo { get; set; }
    }
}