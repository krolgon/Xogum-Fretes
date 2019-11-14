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
                        CON_COMPLEMENTO = c.String(),
                        CON_BAIRRO = c.String(nullable: false, maxLength: 100),
                        CON_CIDADE = c.String(nullable: false, maxLength: 100),
                        CON_ESTADO = c.String(nullable: false, maxLength: 50),
                        Cep = c.String(),
                        UsuarioId = c.Int(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                        VeiculoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CON_ID)
                .ForeignKey("dbo.END_ENDERECO", t => t.EnderecoId)
                .ForeignKey("dbo.USU_USUARIO", t => t.UsuarioId)
                .ForeignKey("dbo.VEI_VEICULO", t => t.VeiculoId)
                .Index(t => t.UsuarioId)
                .Index(t => t.EnderecoId)
                .Index(t => t.VeiculoId);
            
            CreateTable(
                "dbo.END_ENDERECO",
                c => new
                    {
                        END_ID = c.Int(nullable: false, identity: true),
                        END_DESCRICAO = c.String(nullable: false, maxLength: 1000),
                        END_AVALIACAO = c.Int(nullable: false),
                        END_STATUS = c.Boolean(nullable: false),
                        END_DATA = c.DateTime(nullable: false, storeType: "date"),
                        END_AJUDANTE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.END_ID);
            
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
            DropForeignKey("dbo.CON_CONTRATO", "VeiculoId", "dbo.VEI_VEICULO");
            DropForeignKey("dbo.CON_CONTRATO", "UsuarioId", "dbo.USU_USUARIO");
            DropForeignKey("dbo.CON_CONTRATO", "EnderecoId", "dbo.END_ENDERECO");
            DropIndex("dbo.CON_CONTRATO", new[] { "VeiculoId" });
            DropIndex("dbo.CON_CONTRATO", new[] { "EnderecoId" });
            DropIndex("dbo.CON_CONTRATO", new[] { "UsuarioId" });
            AlterColumn("dbo.MOT_MOTORISTA", "MOT_DATA_CRIACAO", c => c.DateTime(nullable: false));
            DropTable("dbo.END_ENDERECO");
            DropTable("dbo.CON_CONTRATO");
            AddForeignKey("dbo.USU_USUARIO", "TipoUsuarioId", "dbo.TIP_TIPO_USUARIO", "TIP_ID", cascadeDelete: true);
            AddForeignKey("dbo.VEI_VEICULO", "MotoristaId", "dbo.MOT_MOTORISTA", "MOT_ID", cascadeDelete: true);
            AddForeignKey("dbo.MOT_MOTORISTA", "UsuarioId", "dbo.USU_USUARIO", "USU_ID", cascadeDelete: true);
        }
    }
}
