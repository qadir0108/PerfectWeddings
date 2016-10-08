namespace PerfectWeddings.Data.Migrations
{
    using Entities;
    using PerfectWeddings.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<PerfectWeddings.Data.Entities.PerfectWeddingsContext>
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
                var alreadyCategory = context.SupplierCategorys.FirstOrDefault(m => m.Name == category);
                if (alreadyCategory == null)
                {
                    context.SupplierCategorys.Add(new Entities.SupplierCategory()
                    {
                        Id = Guid.NewGuid(),
                        Name = category,
                        CreatedAt = DateTime.Now
                    });
                }
            }

            Location[] locations = new Location[] {
                new Entities.Location()
                {
                    Id = Guid.NewGuid(),
                    City = "Flacq",
                    Lat = 34.23123,
                    Long = 73.423423,
                },
                new Entities.Location()
                {
                    Id = Guid.NewGuid(),
                    City = "Grand Port",
                    Lat = 35.223423,
                    Long = 73.423423,
                },
                new Entities.Location()
                {
                    Id = Guid.NewGuid(),
                    City = "Moka",
                    Lat = 34.23123,
                    Long = 73.423423,
                },
                new Entities.Location()
                {
                    Id = Guid.NewGuid(),
                    City = "Pamplemousses",
                    Lat = 34.23123,
                    Long = 73.423423,
                },
                new Entities.Location()
                {
                    Id = Guid.NewGuid(),
                    City = "Plaines Wilhems",
                    Lat = 34.23123,
                    Long = 73.423423,
                },
                new Entities.Location()
                {
                    Id = Guid.NewGuid(),
                    City = "Port Louis",
                    Lat = 34.23123,
                    Long = 73.423423,
                },
                new Entities.Location()
                {
                    Id = Guid.NewGuid(),
                    City = "Rivière du Rempart",
                    Lat = 34.23123,
                    Long = 73.423423,
                },
                new Entities.Location()
                {
                    Id = Guid.NewGuid(),
                    City = "Rivière Noire",
                    Lat = 34.23123,
                    Long = 73.423423,
                },
                new Entities.Location()
                {
                    Id = Guid.NewGuid(),
                    City = "Savanne",
                    Lat = 34.23123,
                    Long = 73.423423,
                },
                new Entities.Location()
                {
                    Id = Guid.NewGuid(),
                    City = "Rodrigues",
                    Lat = 34.23123,
                    Long = 73.423423,
                }
            };

            foreach (var location in locations)
            {
                var alreadyLocation = context.Locations.FirstOrDefault(m => m.City == location.City);
                if (alreadyLocation == null)
                {
                    location.CreatedAt = DateTime.Now;
                    context.Locations.Add(location);
                }
            }

            context.SaveChanges();

        }
    }
}
