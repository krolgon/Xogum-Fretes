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
            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("CON_DESCRICAO");
            Property(p => p.Avaliacao)
                .HasColumnName("CON_AVALIACAO");
            Property(p => p.Status)
                .IsRequired()
                .HasColumnName("CON_STATUS");
            Property(p => p.Data)
                .IsRequired()
                .HasColumnName("CON_DATA")
                .HasColumnType("date");
            Property(p => p.Ajudante)
                .HasColumnName("CON_AJUDANTE");
            

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
