namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteração : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MOT_MOTORISTA", "AVALIACAO", c => c.Int(nullable: false));
            AddColumn("dbo.MOT_MOTORISTA", "MOT_FOTO_CNH", c => c.String(nullable: false));
            AddColumn("dbo.MOT_MOTORISTA", "MOT_VERIFICACAO", c => c.Boolean(nullable: false));
            AddColumn("dbo.USU_USUARIO", "USU_LOCALIZACAO", c => c.String());
            AddColumn("dbo.USU_USUARIO", "USU_AVALIACAO", c => c.Int(nullable: false));
            AddColumn("dbo.USU_USUARIO", "USU_DATA_NASCIMENTO", c => c.DateTime(nullable: false));
            AddColumn("dbo.VEI_VEICULO", "VEI_VERIFICACAO", c => c.Boolean(nullable: false));


        }
        
        public override void Down()
        {
            AddColumn("dbo.MOT_MOTORISTA", "MOT_LOCALIZACAO", c => c.String(nullable: false));
            DropColumn("dbo.VEI_VEICULO", "VEI_VERIFICACAO");
            DropColumn("dbo.USU_USUARIO", "USU_DATA_NASCIMENTO");
            DropColumn("dbo.USU_USUARIO", "USU_AVALIACAO");
            DropColumn("dbo.MOT_MOTORISTA", "MOT_VERIFICACAO");
            DropColumn("dbo.MOT_MOTORISTA", "AVALIACAO");
            DropColumn("dbo.MOT_MOTORISTA", "MOT_FOTO_CNH");
        }
    }
}
