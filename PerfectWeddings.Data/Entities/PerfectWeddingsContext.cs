using PerfectWeddings.Data.Migrations;
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
    public class PerfectWeddingsContext : DbContext
    {
        public PerfectWeddingsContext()
            : base("PerfectWeddingsContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PerfectWeddingsContext, Configuration>());
        }

        public DbSet<BlogEntry> BlogEntrys { get; set; }
        public DbSet<BlogEntryCategory> BlogEntryCategorys { get; set; }
        public DbSet<BlogEntryComment> BlogEntryComments { get; set; }
        public DbSet<BlogEntryTag> BlogEntryTags { get; set; }

        public DbSet<BudgetList> BudgetLists { get; set; }
        public DbSet<BudgetSummary> BudgetSummarys { get; set; }

        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<CheckListComment> CheckListComments { get; set; }

        public DbSet<NormalUser> NormalUsers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventSeatingTable> EventSeatingTables { get; set; }
        public DbSet<Guest> Guests { get; set; }

        public DbSet<HoneyMoonPackage> HoneyMoonPackages { get; set; }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<SocialAccount> SocialAccounts { get; set; }
        public DbSet<SupplierAdvertisement> SupplierAdvertisements { get; set; }
        public DbSet<SupplierCategory> SupplierCategorys { get; set; }
        public DbSet<SupplierCompany> SupplierCompanys { get; set; }
        public DbSet<SupplierCoupon> SupplierCoupons { get; set; }

        public DbSet<SupplierEnquiry> SupplierEnquirys { get; set; }
        public DbSet<SupplierFacility> SupplierFacilitys { get; set; }
        public DbSet<SupplierReview> SupplierReviews { get; set; }
        
        public DbSet<WebSite> WebSites { get; set; }
        public DbSet<WebSitePage> WebSitePages { get; set; }
        public DbSet<WebSiteSettings> WebSiteSettings { get; set; }

        public DbSet<Enquirer> Enquirers { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #region Overrided
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            //catch (DbEntityValidationException vex)
            //{
            //    var exception = HandleDbEntityValidationException(vex);
            //    throw exception;
            //}
            catch (DbUpdateException dbu)
            {
                var exception = HandleDbUpdateException(dbu);
                throw exception;
            }
        }

        private Exception HandleDbUpdateException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            string message = builder.ToString();
            return new Exception(message, dbu);
        }
        #endregion
    }
}
