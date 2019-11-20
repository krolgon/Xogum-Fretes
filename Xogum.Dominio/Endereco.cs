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
        public string EnderecoFrete { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}
