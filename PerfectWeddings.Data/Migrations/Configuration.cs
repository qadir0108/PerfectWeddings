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
    }
}
