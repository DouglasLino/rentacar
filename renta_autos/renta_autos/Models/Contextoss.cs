using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace renta_autos.Models
{
    public class Contextoss : DbContext
    {

        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Modelos> Modelos { get; set; }
        public DbSet<TipoVehiculos> TipoVehiculos { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }

    }
}