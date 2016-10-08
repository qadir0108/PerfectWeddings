using PerfectWeddings.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace PerfectWeddings.Data.Entities
{
    public class PerfectWeddingsDBInitializer : CreateDatabaseIfNotExists<PerfectWeddingsContext>
    {
        protected override void Seed(PerfectWeddings.Data.Entities.PerfectWeddingsContext context)
        {
            //  This method will be called after migrating to the latest version.

            foreach (var category in EnumHelper.GetDescriptions(typeof(SupplierCategoryEnum)))
            {
                context.SupplierCategorys.Add(new Entities.SupplierCategory()
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

            base.Seed(context);
        }
    }
}
