﻿using RestRoomApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RestRoomApp.DAL
{
    public class RestRoomAppContext : DbContext
    {
        public RestRoomAppContext() : base("IdentityASPNETDB")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservaciones { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }

        public DbSet<Administrador> Administradors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}