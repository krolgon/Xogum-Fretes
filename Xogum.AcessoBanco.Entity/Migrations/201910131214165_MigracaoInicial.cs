namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TIP_TIPO_USUARIO",
                c => new
                    {
                        TIP_ID = c.Int(nullable: false, identity: true),
                        TIP_DESCRICAO = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TIP_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TIP_TIPO_USUARIO");
        }
    }
}
