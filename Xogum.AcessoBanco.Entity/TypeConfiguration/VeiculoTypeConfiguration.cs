using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xogum.Dominio;

namespace Xogum.AcessoBanco.Entity.TypeConfiguration
{
    class VeiculoTypeConfiguration : Comum.Entity.EntityAbstractConfig<Veiculo>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("VEI_ID");
            Property(p => p.Placa)
                .IsRequired()
                .HasMaxLength(7)
                .HasColumnName("VEI_PLACA");
            Property(p => p.Crlv)
                .IsRequired()
                .HasColumnName("VEI_CRLV");
            Property(p => p.Modelo)
                .IsRequired()
                .HasColumnName("VEI_MODELO");
            Property(p => p.Cor)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("VEI_COR");
            Property(p => p.Foto)
                .IsRequired()
                .HasColumnName("VEI_FOTO");
            Property(p => p.Status)
                .IsRequired()
                .HasColumnName("VEI_STATUS");
            Property(p => p.DataCriacao)
                .IsRequired()
                .HasColumnName("VEI_DATA_CRIACAO");
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
            ToTable("VEI_VEICULO");
        }
    }
}
