namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoMotosita : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MOT_MOTORISTA",
                c => new
                    {
                        MOT_ID = c.Int(nullable: false, identity: true),
                        MOT_CNH = c.String(nullable: false),
                        MOT_CERTIDAO_CRIMINAL = c.String(nullable: false),
                        MOT_STATUS = c.String(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MOT_ID)
                .ForeignKey("dbo.USU_USUARIO", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MOT_MOTORISTA", "UsuarioId", "dbo.USU_USUARIO");
            DropIndex("dbo.MOT_MOTORISTA", new[] { "UsuarioId" });
            DropTable("dbo.MOT_MOTORISTA");
        }
    }
}
