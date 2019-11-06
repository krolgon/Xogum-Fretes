using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xogum.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Localizacao { get; set; }
        public int Avaliacao { get; set; }
        public DateTime DataNascimento { get; set; }

        public string Foto { get; set; }

        public virtual TipoUsuario TipoUsuario { get; set; }
        public int TipoUsuarioId { get; set; }
 
    }
}
