namespace RestRoomApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Habitacions",
                c => new
                    {
                        HabitacionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Numero = c.String(),
                        Planta = c.String(),
                        Camas = c.Int(nullable: false),
                        EstaDisponible = c.Boolean(nullable: false),
                        Descripcion = c.String(),
                        Fotos = c.String(),
                        Precio = c.Double(nullable: false),
                        Categoria = c.Int(nullable: false),
                        Notas = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HabitacionId);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        ReservaID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        HabitacionID = c.Int(nullable: false),
                        HorasReservacion = c.Int(nullable: false),
                        HoraInicioReservacion = c.Int(nullable: false),
                        FechaReservacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservaID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Habitacions", t => t.HabitacionID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.HabitacionID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Correo = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "HabitacionID", "dbo.Habitacions");
            DropForeignKey("dbo.Reservas", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Reservas", new[] { "HabitacionID" });
            DropIndex("dbo.Reservas", new[] { "ClienteID" });
            DropTable("dbo.Clientes");
            DropTable("dbo.Reservas");
            DropTable("dbo.Habitacions");
        }
    }
}
