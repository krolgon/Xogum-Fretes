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
        public string Descricao { get; set; }
        public int Avaliacao { get; set; }
        public Boolean Status { get; set; }
        public DateTime Data { get; set; }
        public int Ajudante { get; set; }
    }
}
