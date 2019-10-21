namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoVeiculo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VEI_VEICULO",
                c => new
                    {
                        VEI_ID = c.Int(nullable: false, identity: true),
                        VEI_PLACA = c.String(nullable: false, maxLength: 7),
                        VEI_CRLV = c.String(nullable: false),
                        VEI_RENAVAM = c.String(nullable: false),
                        VEI_MODELO = c.String(nullable: false),
                        VEI_COR = c.String(nullable: false, maxLength: 25),
                        VEI_CHASSI = c.String(nullable: false),
                        VEI_FOTO = c.String(nullable: false),
                        VEI_STATUS = c.String(nullable: false),
                        VEI_DATA_CRIACAO = c.DateTime(nullable: false),
                        MotoristaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VEI_ID)
                .ForeignKey("dbo.MOT_MOTORISTA", t => t.MotoristaId, cascadeDelete: true)
                .Index(t => t.MotoristaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VEI_VEICULO", "MotoristaId", "dbo.MOT_MOTORISTA");
            DropIndex("dbo.VEI_VEICULO", new[] { "MotoristaId" });
            DropTable("dbo.VEI_VEICULO");
        }
    }
}
