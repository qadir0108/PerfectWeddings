namespace PerfectWeddings.Data.Migrations
{
    using PerfectWeddings.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PerfectWeddings.Data.Entities.PerfectWeddingsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PerfectWeddings.Data.Entities.PerfectWeddingsContext context)
        {
            //  This method will be called after migrating to the latest version.

            foreach (var category in EnumHelper.GetDescriptions(typeof(SupplierCategoryEnum)))
            {
                context.SupplierCategorys.AddOrUpdate(new Entities.SupplierCategory()
                {
                    Id = Guid.NewGuid(),
                    Name = category,
                    CreatedAt = DateTime.Now
                });
            }

            context.Locations.Add(new Entities.Location()
            {
                Id = Guid.NewGuid(),
                City = "Flacq",
                Lat = 34.23123,
                Long = 73.423423,
                CreatedAt = DateTime.Now
            });
            context.Locations.Add(new Entities.Location()
            {
                Id = Guid.NewGuid(),
                City = "Grand Port",
                Lat = 35.223423,
                Long = 73.423423,
                CreatedAt = DateTime.Now
            });
            context.Locations.Add(new Entities.Location()
            {
                Id = Guid.NewGuid(),
                City = "Moka",
                Lat = 34.23123,
                Long = 73.423423,
                CreatedAt = DateTime.Now
            });
            context.Locations.Add(new Entities.Location()
            {
                Id = Guid.NewGuid(),
                City = "Pamplemousses",
                Lat = 34.23123,
                Long = 73.423423,
                CreatedAt = DateTime.Now
            });
            context.Locations.Add(new Entities.Location()
            {
                Id = Guid.NewGuid(),
                City = "Plaines Wilhems",
                Lat = 34.23123,
                Long = 73.423423,
                CreatedAt = DateTime.Now
            });
            context.Locations.Add(new Entities.Location()
            {
                Id = Guid.NewGuid(),
                City = "Port Louis",
                Lat = 34.23123,
                Long = 73.423423,
                CreatedAt = DateTime.Now
            });
            context.Locations.Add(new Entities.Location()
            {
                Id = Guid.NewGuid(),
                City = "Rivière du Rempart",
                Lat = 34.23123,
                Long = 73.423423,
                CreatedAt = DateTime.Now
            });
            context.Locations.Add(new Entities.Location()
            {
                Id = Guid.NewGuid(),
                City = "Rivière Noire",
                Lat = 34.23123,
                Long = 73.423423,
                CreatedAt = DateTime.Now
            });
            context.Locations.Add(new Entities.Location()
            {
                Id = Guid.NewGuid(),
                City = "Savanne",
                Lat = 34.23123,
                Long = 73.423423,
                CreatedAt = DateTime.Now
            });
            context.Locations.Add(new Entities.Location()
            {
                Id = Guid.NewGuid(),
                City = "Rodrigues",
                Lat = 34.23123,
                Long = 73.423423,
                CreatedAt = DateTime.Now
            });

            context.SaveChanges();   
        }
    }
}
