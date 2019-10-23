namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudancaTblMotorista : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VEI_VEICULO", "VEI_RENAVAM");
            DropColumn("dbo.VEI_VEICULO", "VEI_CHASSI");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VEI_VEICULO", "VEI_CHASSI", c => c.String(nullable: false));
            AddColumn("dbo.VEI_VEICULO", "VEI_RENAVAM", c => c.String(nullable: false));
        }
    }
}
