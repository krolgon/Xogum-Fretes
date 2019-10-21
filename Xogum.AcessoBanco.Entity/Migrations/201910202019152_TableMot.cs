namespace Xogum.AcessoBanco.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableMot : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MOT_MOTORISTA", name: "DataCriacao", newName: "MOT_DATA_CRIACAO");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.MOT_MOTORISTA", name: "MOT_DATA_CRIACAO", newName: "DataCriacao");
        }
    }
}
