namespace renta_autos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alquilers",
                c => new
                    {
                        Id_alquiler = c.Int(nullable: false, identity: true),
                        Cliente = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Dui = c.String(nullable: false),
                        Fecha_inicio = c.DateTime(nullable: false),
                        Fecha_fin = c.DateTime(nullable: false),
                        Total = c.Double(nullable: false),
                        Id_vehiculo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_alquiler)
                .ForeignKey("dbo.Vehiculos", t => t.Id_vehiculo, cascadeDelete: true)
                .Index(t => t.Id_vehiculo);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id_marca = c.Int(nullable: false, identity: true),
                        Marca = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id_marca);
            
            CreateTable(
                "dbo.Vehiculos",
                c => new
                    {
                        Id_vehiculo = c.Int(nullable: false, identity: true),
                        Placa = c.String(nullable: false),
                        Anio = c.Int(nullable: false),
                        Transmision = c.String(nullable: false),
                        Precio_hora = c.Double(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        Id_marca = c.Int(nullable: false),
                        Id_modelo = c.Int(nullable: false),
                        Id_tipo_vehiculo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_vehiculo)
                .ForeignKey("dbo.Marcas", t => t.Id_marca, cascadeDelete: true)
                .ForeignKey("dbo.Modelos", t => t.Id_modelo, cascadeDelete: true)
                .ForeignKey("dbo.TipoVehiculos", t => t.Id_tipo_vehiculo, cascadeDelete: true)
                .Index(t => t.Id_marca)
                .Index(t => t.Id_modelo)
                .Index(t => t.Id_tipo_vehiculo);
            
            CreateTable(
                "dbo.Modelos",
                c => new
                    {
                        Id_modelo = c.Int(nullable: false, identity: true),
                        Modelo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id_modelo);
            
            CreateTable(
                "dbo.TipoVehiculos",
                c => new
                    {
                        Id_tipo_vehiculo = c.Int(nullable: false, identity: true),
                        Tipo_vehiculo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id_tipo_vehiculo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculos", "Id_tipo_vehiculo", "dbo.TipoVehiculos");
            DropForeignKey("dbo.Vehiculos", "Id_modelo", "dbo.Modelos");
            DropForeignKey("dbo.Vehiculos", "Id_marca", "dbo.Marcas");
            DropForeignKey("dbo.Alquilers", "Id_vehiculo", "dbo.Vehiculos");
            DropIndex("dbo.Vehiculos", new[] { "Id_tipo_vehiculo" });
            DropIndex("dbo.Vehiculos", new[] { "Id_modelo" });
            DropIndex("dbo.Vehiculos", new[] { "Id_marca" });
            DropIndex("dbo.Alquilers", new[] { "Id_vehiculo" });
            DropTable("dbo.TipoVehiculos");
            DropTable("dbo.Modelos");
            DropTable("dbo.Vehiculos");
            DropTable("dbo.Marcas");
            DropTable("dbo.Alquilers");
        }
    }
}
