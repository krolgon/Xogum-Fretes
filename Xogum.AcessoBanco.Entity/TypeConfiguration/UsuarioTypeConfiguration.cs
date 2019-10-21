using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xogum.Dominio;

namespace Xogum.AcessoBanco.Entity.TypeConfiguration
{
    class UsuarioTypeConfiguration : Comum.Entity.EntityAbstractConfig<Usuario>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("USU_ID");
            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("USU_NOME");
            Property(p => p.Cpf)
                .IsRequired()
                .HasColumnName("USU_CPF");
            Property(p => p.Telefone)
                .HasMaxLength(11)
                .HasColumnName("USU_TELEFONE");
            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("USU_EMAIL");
            Property(p => p.Senha)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("USU_SENHA");
            Property(p => p.Foto)
                .HasColumnName("USU_FOTO");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {

        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("USU_USUARIO");
        }
    }
}
