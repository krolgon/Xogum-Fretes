using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xogum.ViewModels.TiposUsuario
{
    public class TiposUsuarioExibicaoViewModel
    {
        [Display(Name = "Identificador")]
        public int Id { get; set; }

        [Display(Name = "Tipo de Usuário")]
        public string Descricao { get; set; }
    }
}