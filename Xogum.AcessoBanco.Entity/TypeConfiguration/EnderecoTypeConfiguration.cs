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
            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("END_DESCRICAO");
            Property(p => p.Avaliacao)
                .HasColumnName("END_AVALIACAO");
            Property(p => p.Status)
                .IsRequired()
                .HasColumnName("END_STATUS");
            Property(p => p.Data)
                .IsRequired()
                .HasColumnName("END_DATA")
                .HasColumnType("date");
            Property(p => p.Ajudante)
                .HasColumnName("END_AJUDANTE");
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
