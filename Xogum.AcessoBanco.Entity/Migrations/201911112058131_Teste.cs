namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.USU_USUARIO", "USU_DATA_NASCIMENTO", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.USU_USUARIO", "USU_DATA_NASCIMENTO", c => c.DateTime(nullable: false));
        }
    }
}
