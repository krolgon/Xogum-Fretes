﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xogum.AcessoBanco.Entity.TypeConfiguration;
using Xogum.Dominio;


namespace Xogum.AcessoBanco.Entity.Contexto
{
    public class XogumDbContexto : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConve‌​ntion>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new TipoUsuarioTypeConfiguration());
            modelBuilder.Configurations.Add(new UsuarioTypeConfiguration());
            modelBuilder.Configurations.Add(new MotoristaTypeConfiguration());
            modelBuilder.Configurations.Add(new VeiculoTypeConfiguration());
            modelBuilder.Configurations.Add(new EnderecoTypeConfiguration());
            modelBuilder.Configurations.Add(new ContratoTypeConfiguration());
           
        }
    }
}
