namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoSenhaCaracteres : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.USU_USUARIO", "USU_SENHA", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.USU_USUARIO", "USU_SENHA", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
