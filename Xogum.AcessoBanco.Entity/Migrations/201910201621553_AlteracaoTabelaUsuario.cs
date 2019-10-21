namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoTabelaUsuario : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MOT_MOTORISTA", "MOT_STATUS", c => c.Boolean(nullable: false));
            AlterColumn("dbo.VEI_VEICULO", "VEI_STATUS", c => c.Boolean(nullable: false));
            DropColumn("dbo.USU_USUARIO", "USU_DATA_NASCIMENTO");
            DropColumn("dbo.USU_USUARIO", "USU_RG");
            DropColumn("dbo.USU_USUARIO", "USU_COMPLEMENTO");
            DropColumn("dbo.USU_USUARIO", "USU_NUMERO_COMPLEMENTO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.USU_USUARIO", "USU_NUMERO_COMPLEMENTO", c => c.String(maxLength: 50));
            AddColumn("dbo.USU_USUARIO", "USU_COMPLEMENTO", c => c.String(maxLength: 200));
            AddColumn("dbo.USU_USUARIO", "USU_RG", c => c.String(nullable: false));
            AddColumn("dbo.USU_USUARIO", "USU_DATA_NASCIMENTO", c => c.DateTime(nullable: false));
            AlterColumn("dbo.VEI_VEICULO", "VEI_STATUS", c => c.String(nullable: false));
            AlterColumn("dbo.MOT_MOTORISTA", "MOT_STATUS", c => c.String(nullable: false));
        }
    }
}
