namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnderecoContratoAtualizacao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.END_ENDERECO", "UsuarioId", "dbo.USU_USUARIO");
            DropForeignKey("dbo.END_ENDERECO", "VeiculoId", "dbo.VEI_VEICULO");
            DropIndex("dbo.END_ENDERECO", new[] { "UsuarioId" });
            DropIndex("dbo.END_ENDERECO", new[] { "VeiculoId" });
            AddColumn("dbo.CON_CONTRATO", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.CON_CONTRATO", "VeiculoId", c => c.Int(nullable: false));
            AddColumn("dbo.CON_CONTRATO", "MotoristaId", c => c.Int(nullable: false));
            AddColumn("dbo.CON_CONTRATO", "EnderecoId", c => c.Int(nullable: false));
            AddColumn("dbo.END_ENDERECO", "END_ENDERECO_FRETE", c => c.String());
            AddColumn("dbo.END_ENDERECO", "Numero", c => c.String());
            CreateIndex("dbo.CON_CONTRATO", "UsuarioId");
            CreateIndex("dbo.CON_CONTRATO", "VeiculoId");
            CreateIndex("dbo.CON_CONTRATO", "MotoristaId");
            CreateIndex("dbo.CON_CONTRATO", "EnderecoId");
            AddForeignKey("dbo.CON_CONTRATO", "EnderecoId", "dbo.END_ENDERECO", "END_ID");
            AddForeignKey("dbo.CON_CONTRATO", "MotoristaId", "dbo.MOT_MOTORISTA", "MOT_ID");
            AddForeignKey("dbo.CON_CONTRATO", "UsuarioId", "dbo.USU_USUARIO", "USU_ID");
            AddForeignKey("dbo.CON_CONTRATO", "VeiculoId", "dbo.VEI_VEICULO", "VEI_ID");
            DropColumn("dbo.END_ENDERECO", "END_ENDERECO_INCIAL");
            DropColumn("dbo.END_ENDERECO", "END_NUMERO_INICIAL");
            DropColumn("dbo.END_ENDERECO", "END_ENDERECO_FINAL");
            DropColumn("dbo.END_ENDERECO", "END_NUMERO_FINAL");
            DropColumn("dbo.END_ENDERECO", "UsuarioId");
            DropColumn("dbo.END_ENDERECO", "VeiculoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.END_ENDERECO", "VeiculoId", c => c.Int(nullable: false));
            AddColumn("dbo.END_ENDERECO", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.END_ENDERECO", "END_NUMERO_FINAL", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.END_ENDERECO", "END_ENDERECO_FINAL", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.END_ENDERECO", "END_NUMERO_INICIAL", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.END_ENDERECO", "END_ENDERECO_INCIAL", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.CON_CONTRATO", "VeiculoId", "dbo.VEI_VEICULO");
            DropForeignKey("dbo.CON_CONTRATO", "UsuarioId", "dbo.USU_USUARIO");
            DropForeignKey("dbo.CON_CONTRATO", "MotoristaId", "dbo.MOT_MOTORISTA");
            DropForeignKey("dbo.CON_CONTRATO", "EnderecoId", "dbo.END_ENDERECO");
            DropIndex("dbo.CON_CONTRATO", new[] { "EnderecoId" });
            DropIndex("dbo.CON_CONTRATO", new[] { "MotoristaId" });
            DropIndex("dbo.CON_CONTRATO", new[] { "VeiculoId" });
            DropIndex("dbo.CON_CONTRATO", new[] { "UsuarioId" });
            DropColumn("dbo.END_ENDERECO", "Numero");
            DropColumn("dbo.END_ENDERECO", "END_ENDERECO_FRETE");
            DropColumn("dbo.CON_CONTRATO", "EnderecoId");
            DropColumn("dbo.CON_CONTRATO", "MotoristaId");
            DropColumn("dbo.CON_CONTRATO", "VeiculoId");
            DropColumn("dbo.CON_CONTRATO", "UsuarioId");
            CreateIndex("dbo.END_ENDERECO", "VeiculoId");
            CreateIndex("dbo.END_ENDERECO", "UsuarioId");
            AddForeignKey("dbo.END_ENDERECO", "VeiculoId", "dbo.VEI_VEICULO", "VEI_ID");
            AddForeignKey("dbo.END_ENDERECO", "UsuarioId", "dbo.USU_USUARIO", "USU_ID");
        }
    }
}
