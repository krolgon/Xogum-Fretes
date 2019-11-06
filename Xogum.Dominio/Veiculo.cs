using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xogum.Dominio
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Crlv { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Foto { get; set; }
        public Boolean Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public Boolean Verificacao { get; set; }

        public virtual Motorista Motorista { get; set; }
        public int MotoristaId { get; set; }
    }
}
