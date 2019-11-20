using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xogum.Dominio;

namespace Xogum.AcessoBanco.Entity.TypeConfiguration
{
    class EnderecoTypeConfiguration : Comum.Entity.EntityAbstractConfig<Endereco>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
               .HasColumnName("END_ID");
            Property(p => p.Complemento)
                .HasColumnName("END_COMPLEMENTO");
            Property(p => p.EnderecoFrete)
                .HasColumnName("END_ENDERECO_FRETE");
            Property(p => p.Bairro)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("END_BAIRRO");
            Property(p => p.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("END_CIDADE");
            Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("END_ESTADO");
            Property(p => p.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("END_CIDADE");
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
            ToTable("END_ENDERECO");
        }
    }
}
