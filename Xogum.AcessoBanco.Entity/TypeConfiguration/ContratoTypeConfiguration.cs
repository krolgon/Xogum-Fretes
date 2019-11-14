using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xogum.Dominio;

namespace Xogum.AcessoBanco.Entity.TypeConfiguration
{
    class ContratoTypeConfiguration : Comum.Entity.EntityAbstractConfig<Contrato>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
               .HasColumnName("CON_ID");
            Property(p => p.Complemento)
                .HasColumnName("CON_COMPLEMENTO");
            Property(p => p.Bairro)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("CON_BAIRRO");
            Property(p => p.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("CON_CIDADE");
            Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CON_ESTADO");
            Property(p => p.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("CON_CIDADE");

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
            ToTable("CON_CONTRATO");
        }
    }
}
