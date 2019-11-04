using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xogum.Dominio;
using Xogum.ViewModels.Usuario;

namespace Xogum.ViewModels.Motorista
{
    public class MotoristaExibicaoViewModel
    {


        /*Cadastro de Usuário*/
        public UsuarioExibicaoViewModel usuario { get; set; }


        /*Motorista*/

        [Display(Name = "Identificador")]
        public int Id { get; set; }

        [Display(Name = "CNH(Foto)")]
        public string Cnh { get; set; }

        [Display(Name = "CND(Foto)")]
        public string CertidaoCriminal { get; set; }

        [Display(Name = "Status")]
        [Required]
        public Boolean Status { get; set; }

        [Display(Name = "Data de Criação")]
        [Required]
        public DateTime DataCriacao { get; set; }


        /*Veículo*/

        [Display(Name = "Placa")]
        public string Placa { get; set; }

        [Display(Name = "CRLV")]
        public string Crlv { get; set; }

        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Display(Name = "Cor")]
        public string Cor { get; set; }

        [Display(Name = "Veículo(Foto)")]
        public string FotoVeiculo { get; set; }

        [Display(Name = "Foto com CNH")]
        public string FotoComCnh { get; set; }

        [Display(Name = "Localização")]
        public string Localizacao { get; set; }

        [Display(Name = "Status")]
        public Boolean StatusVeiculo { get; set; }

        [Display(Name = "Data de Criação")]
        public DateTime DataCriacaoVeiculo { get; set; }
    }
}