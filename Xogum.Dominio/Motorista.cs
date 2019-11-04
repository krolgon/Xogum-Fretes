using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xogum.Dominio
{
    public class Motorista
    {
        public int Id { get; set; }
        public string Cnh { get; set; }
        public string CertidaoCriminal { get; set; }
        public string FotoComCnh { get; set; }
        public string Localizacao { get; set; }
        public Boolean Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Avaliacao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

       
    }
}
