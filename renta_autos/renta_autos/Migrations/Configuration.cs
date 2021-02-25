namespace renta_autos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<renta_autos.Models.Contextoss>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "renta_autos.Models.Contexto";
        }

        protected override void Seed(renta_autos.Models.Contextoss context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
