using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xogum.Dominio
{
    public class Contrato
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Avaliacao { get; set; }
        public Boolean Status { get; set; }
        public DateTime Data { get; set; }
        public int Ajudante { get; set; }

        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public virtual Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }

        public virtual Motorista Motorista { get; set; }
        public int MotoristaId { get; set; }

        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
    }
}
