namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnderecoContrato : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MOT_MOTORISTA", "UsuarioId", "dbo.USU_USUARIO");
            DropForeignKey("dbo.VEI_VEICULO", "MotoristaId", "dbo.MOT_MOTORISTA");
            DropForeignKey("dbo.USU_USUARIO", "TipoUsuarioId", "dbo.TIP_TIPO_USUARIO");
            CreateTable(
                "dbo.CON_CONTRATO",
                c => new
                    {
                        CON_ID = c.Int(nullable: false, identity: true),
                        CON_DESCRICAO = c.String(nullable: false, maxLength: 1000),
                        CON_AVALIACAO = c.Int(nullable: false),
                        CON_STATUS = c.Boolean(nullable: false),
                        CON_DATA = c.DateTime(nullable: false, storeType: "date"),
                        CON_AJUDANTE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CON_ID);
            
            CreateTable(
                "dbo.END_ENDERECO",
                c => new
                    {
                        END_ID = c.Int(nullable: false, identity: true),
                        END_ENDERECO_INCIAL = c.String(nullable: false, maxLength: 100),
                        END_NUMERO_INICIAL = c.String(nullable: false, maxLength: 100),
                        END_ENDERECO_FINAL = c.String(nullable: false, maxLength: 100),
                        END_NUMERO_FINAL = c.String(nullable: false, maxLength: 100),
                        END_COMPLEMENTO = c.String(),
                        END_BAIRRO = c.String(nullable: false, maxLength: 100),
                        END_CIDADE = c.String(nullable: false, maxLength: 100),
                        END_ESTADO = c.String(nullable: false, maxLength: 50),
                        Cep = c.String(),
                        UsuarioId = c.Int(nullable: false),
                        VeiculoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.END_ID)
                .ForeignKey("dbo.USU_USUARIO", t => t.UsuarioId)
                .ForeignKey("dbo.VEI_VEICULO", t => t.VeiculoId)
                .Index(t => t.UsuarioId)
                .Index(t => t.VeiculoId);
            
            AlterColumn("dbo.MOT_MOTORISTA", "MOT_DATA_CRIACAO", c => c.DateTime(nullable: false, storeType: "date"));
            AddForeignKey("dbo.MOT_MOTORISTA", "UsuarioId", "dbo.USU_USUARIO", "USU_ID");
            AddForeignKey("dbo.VEI_VEICULO", "MotoristaId", "dbo.MOT_MOTORISTA", "MOT_ID");
            AddForeignKey("dbo.USU_USUARIO", "TipoUsuarioId", "dbo.TIP_TIPO_USUARIO", "TIP_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.USU_USUARIO", "TipoUsuarioId", "dbo.TIP_TIPO_USUARIO");
            DropForeignKey("dbo.VEI_VEICULO", "MotoristaId", "dbo.MOT_MOTORISTA");
            DropForeignKey("dbo.MOT_MOTORISTA", "UsuarioId", "dbo.USU_USUARIO");
            DropForeignKey("dbo.END_ENDERECO", "VeiculoId", "dbo.VEI_VEICULO");
            DropForeignKey("dbo.END_ENDERECO", "UsuarioId", "dbo.USU_USUARIO");
            DropIndex("dbo.END_ENDERECO", new[] { "VeiculoId" });
            DropIndex("dbo.END_ENDERECO", new[] { "UsuarioId" });
            AlterColumn("dbo.MOT_MOTORISTA", "MOT_DATA_CRIACAO", c => c.DateTime(nullable: false));
            DropTable("dbo.END_ENDERECO");
            DropTable("dbo.CON_CONTRATO");
            AddForeignKey("dbo.USU_USUARIO", "TipoUsuarioId", "dbo.TIP_TIPO_USUARIO", "TIP_ID", cascadeDelete: true);
            AddForeignKey("dbo.VEI_VEICULO", "MotoristaId", "dbo.MOT_MOTORISTA", "MOT_ID", cascadeDelete: true);
            AddForeignKey("dbo.MOT_MOTORISTA", "UsuarioId", "dbo.USU_USUARIO", "USU_ID", cascadeDelete: true);
        }
    }
}
