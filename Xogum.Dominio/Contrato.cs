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
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        public virtual Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }
    }
}
