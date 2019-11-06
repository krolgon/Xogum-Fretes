using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xogum.Dominio;

namespace Xogum.AcessoBanco.Entity.TypeConfiguration
{
    class MotoristaTypeConfiguration : Comum.Entity.EntityAbstractConfig<Motorista>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("MOT_ID");
            Property(p => p.Cnh)
                .IsRequired()
                .HasColumnName("MOT_CNH");
            Property(p => p.CertidaoCriminal)
                .IsRequired()
                .HasColumnName("MOT_CERTIDAO_CRIMINAL");
            Property(p => p.FotoComCnh)
                .IsRequired()
                .HasColumnName("MOT_FOTO_CNH");
            Property(p => p.Status)
                .IsRequired()
                .HasColumnName("MOT_STATUS");
            Property(p => p.DataCriacao)
                .HasColumnName("MOT_DATA_CRIACAO");
            Property(p => p.Verificacao)
                .HasColumnName("MOT_VERIFICACAO");
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
            ToTable("MOT_MOTORISTA");
        }
    }
}
