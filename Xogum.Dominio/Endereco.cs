using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xogum.Dominio
{
    public class Endereco
    {
        public int Id { get; set; }
        public string EnderecoInicial { get; set; }
        public string NumeroInicial { get; set; }
        public string EnderecoFinal { get; set; }
        public string NumeroFinal { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public virtual Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }
    }
}
