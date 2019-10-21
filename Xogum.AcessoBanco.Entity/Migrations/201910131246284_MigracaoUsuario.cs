namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.USU_USUARIO",
                c => new
                    {
                        USU_ID = c.Int(nullable: false, identity: true),
                        USU_NOME = c.String(nullable: false, maxLength: 150),
                        USU_EMAIL = c.String(nullable: false, maxLength: 100),
                        USU_SENHA = c.String(nullable: false, maxLength: 20),
                        USU_DATA_NASCIMENTO = c.DateTime(nullable: false),
                        USU_TELEFONE = c.String(maxLength: 11),
                        USU_CPF = c.String(nullable: false),
                        USU_RG = c.String(nullable: false),
                        USU_COMPLEMENTO = c.String(maxLength: 200),
                        USU_NUMERO_COMPLEMENTO = c.String(maxLength: 50),
                        USU_FOTO = c.String(),
                        TipoUsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.USU_ID)
                .ForeignKey("dbo.TIP_TIPO_USUARIO", t => t.TipoUsuarioId, cascadeDelete: true)
                .Index(t => t.TipoUsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.USU_USUARIO", "TipoUsuarioId", "dbo.TIP_TIPO_USUARIO");
            DropIndex("dbo.USU_USUARIO", new[] { "TipoUsuarioId" });
            DropTable("dbo.USU_USUARIO");
        }
    }
}
