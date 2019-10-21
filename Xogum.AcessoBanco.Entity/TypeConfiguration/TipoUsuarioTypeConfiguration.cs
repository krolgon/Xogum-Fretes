using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xogum.Dominio;

namespace Xogum.AcessoBanco.Entity.TypeConfiguration
{
    class TipoUsuarioTypeConfiguration : Comum.Entity.EntityAbstractConfig<TipoUsuario>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("TIP_ID");
            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("TIP_DESCRICAO");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(fk => fk.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {

        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("TIP_TIPO_USUARIO");
        }
    }
}
