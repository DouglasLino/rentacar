namespace renta_autos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cambios1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehiculos", "Foto", c => c.String(nullable: false));
            AlterColumn("dbo.Alquilers", "Telefono", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.Alquilers", "Dui", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alquilers", "Dui", c => c.String(nullable: false));
            AlterColumn("dbo.Alquilers", "Telefono", c => c.String(nullable: false));
            DropColumn("dbo.Vehiculos", "Foto");
        }
    }
}
