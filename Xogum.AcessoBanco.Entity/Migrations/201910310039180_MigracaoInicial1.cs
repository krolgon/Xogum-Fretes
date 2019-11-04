namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MOT_MOTORISTA", "MOT_AVALIACAO", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MOT_MOTORISTA", "MOT_AVALIACAO");
        }
    }
}
