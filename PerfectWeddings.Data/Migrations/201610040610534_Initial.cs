namespace PerfectWeddings.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogEntryCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Description = c.String(),
                        ProfileImage = c.String(),
                        MethodToContact = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        LastLogin = c.DateTime(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        WeddingDate = c.DateTime(),
                        WeddingCity = c.String(),
                        WeddingState = c.String(),
                        DateOfBirth = c.DateTime(),
                        Gender = c.Int(),
                        PartnerFirstName = c.String(),
                        PartnerLastName = c.String(),
                        PartnerDateOfBirth = c.DateTime(),
                        PartnerGender = c.Int(),
                        Name = c.String(),
                        WhySpecial = c.String(),
                        VideoURL = c.String(),
                        Category = c.Int(),
                        AccountType = c.Int(),
                        AccountExpiryDate = c.DateTime(),
                        NumberOfAdAllowed = c.Int(),
                        IsVerified = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        CreatedBy_Id = c.Guid(),
                        Budget_Id = c.Guid(),
                        WebSite_Id = c.Guid(),
                        Company_Id = c.Guid(),
                        Location_Id = c.Guid(),
                        NormalUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.BudgetSummary", t => t.Budget_Id)
                .ForeignKey("dbo.WebSite", t => t.WebSite_Id)
                .ForeignKey("dbo.SupplierCompany", t => t.Company_Id)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .ForeignKey("dbo.User", t => t.NormalUser_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Budget_Id)
                .Index(t => t.WebSite_Id)
                .Index(t => t.Company_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.NormalUser_Id);
            
            CreateTable(
                "dbo.SocialAccount",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.BudgetSummary",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoOfGuests = c.Int(nullable: false),
                        TotalBudgetedCost = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.BudgetList",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BudgetItemName = c.String(),
                        Category = c.Int(nullable: false),
                        BudgetCost = c.Double(nullable: false),
                        ActualCost = c.Double(nullable: false),
                        PaidCost = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        BudgetSummary_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.BudgetSummary", t => t.BudgetSummary_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.BudgetSummary_Id);
            
            CreateTable(
                "dbo.CheckList",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        TimeFrame = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        NormalUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.User", t => t.NormalUser_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.NormalUser_Id);
            
            CreateTable(
                "dbo.CheckListComment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Comment = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        CheckList_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.CheckList", t => t.CheckList_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.CheckList_Id);
            
            CreateTable(
                "dbo.Guest",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Address = c.String(),
                        IsSpecialMeal = c.Boolean(nullable: false),
                        IsChild = c.Boolean(nullable: false),
                        Category = c.Int(nullable: false),
                        Notes = c.String(),
                        IsInvitationSent = c.Boolean(nullable: false),
                        IsAttending = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        NormalUser_Id = c.Guid(),
                        Event_Id = c.Guid(),
                        EventSeatingTable_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.User", t => t.NormalUser_Id)
                .ForeignKey("dbo.Event", t => t.Event_Id)
                .ForeignKey("dbo.EventSeatingTable", t => t.EventSeatingTable_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.NormalUser_Id)
                .Index(t => t.Event_Id)
                .Index(t => t.EventSeatingTable_Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        IsRead = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Reciever_Id = c.Guid(),
                        Sender_Id = c.Guid(),
                        NormalUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.User", t => t.Reciever_Id)
                .ForeignKey("dbo.User", t => t.Sender_Id)
                .ForeignKey("dbo.User", t => t.NormalUser_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Reciever_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.NormalUser_Id);
            
            CreateTable(
                "dbo.WebSite",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Settings_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.WebSiteSettings", t => t.Settings_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Settings_Id);
            
            CreateTable(
                "dbo.WebSitePage",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        PageOrder = c.Int(nullable: false),
                        IsPasswordProtected = c.Boolean(nullable: false),
                        Password = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        WebSite_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.WebSite", t => t.WebSite_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.WebSite_Id);
            
            CreateTable(
                "dbo.WebSiteSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        URL = c.String(),
                        IsPasswordProtected = c.Boolean(nullable: false),
                        Password = c.String(),
                        Theme = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.SupplierAdvertisement",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Category = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Location_Id = c.Guid(),
                        Supplier_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .ForeignKey("dbo.User", t => t.Supplier_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.SupplierCompany",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        WebAddress = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.SupplierCoupon",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Image = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Supplier_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.User", t => t.Supplier_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.SupplierEnquiry",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EnquirerName = c.String(),
                        EnquirerPhone = c.String(),
                        EnquirerEmail = c.String(),
                        EnquirerWeddingDate = c.DateTime(nullable: false),
                        NoOfGuests = c.Int(nullable: false),
                        IsSendInfoEmail = c.Boolean(nullable: false),
                        IsNeedCallback = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Supplier_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.User", t => t.Supplier_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.SupplierFacility",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Supplier_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.User", t => t.Supplier_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.SupplierReview",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ReviewStars = c.Int(nullable: false),
                        ReviewTitle = c.String(),
                        ReviewDetail = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Reviewer_Id = c.Guid(),
                        Supplier_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.User", t => t.Reviewer_Id)
                .ForeignKey("dbo.User", t => t.Supplier_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Reviewer_Id)
                .Index(t => t.Supplier_Id);
            
            CreateTable(
                "dbo.BlogEntryComment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Subject = c.String(),
                        Comment = c.String(),
                        CommenterName = c.String(),
                        CommenterEmail = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        BlogEntry_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.BlogEntry", t => t.BlogEntry_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.BlogEntry_Id);
            
            CreateTable(
                "dbo.BlogEntry",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Image = c.String(),
                        Content = c.String(),
                        Type = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Category_Id = c.Guid(),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogEntryCategory", t => t.Category_Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.BlogEntryTag",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        BlogEntry_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.BlogEntry", t => t.BlogEntry_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.BlogEntry_Id);
            
            CreateTable(
                "dbo.Enquirer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EnquiryCategory = c.Int(nullable: false),
                        Message = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Icon = c.String(),
                        Date = c.DateTime(nullable: false),
                        Time = c.Int(nullable: false),
                        IsTime24 = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.EventSeatingTable",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TableName = c.String(),
                        NoOfSeats = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                        Event_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Event", t => t.Event_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.HoneyMoonPackage",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Cost = c.Double(nullable: false),
                        Content = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Flights = c.String(),
                        Terms = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.SupplierCategory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplierCategory", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.HoneyMoonPackage", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.EventSeatingTable", "Event_Id", "dbo.Event");
            DropForeignKey("dbo.Guest", "EventSeatingTable_Id", "dbo.EventSeatingTable");
            DropForeignKey("dbo.EventSeatingTable", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.Guest", "Event_Id", "dbo.Event");
            DropForeignKey("dbo.Event", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.Enquirer", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.BlogEntryTag", "BlogEntry_Id", "dbo.BlogEntry");
            DropForeignKey("dbo.BlogEntryTag", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.BlogEntry", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.BlogEntryComment", "BlogEntry_Id", "dbo.BlogEntry");
            DropForeignKey("dbo.BlogEntry", "Category_Id", "dbo.BlogEntryCategory");
            DropForeignKey("dbo.BlogEntryComment", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.BlogEntryCategory", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.User", "NormalUser_Id", "dbo.User");
            DropForeignKey("dbo.SupplierReview", "Supplier_Id", "dbo.User");
            DropForeignKey("dbo.SupplierReview", "Reviewer_Id", "dbo.User");
            DropForeignKey("dbo.SupplierReview", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.User", "Location_Id", "dbo.Location");
            DropForeignKey("dbo.SupplierFacility", "Supplier_Id", "dbo.User");
            DropForeignKey("dbo.SupplierFacility", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.SupplierEnquiry", "Supplier_Id", "dbo.User");
            DropForeignKey("dbo.SupplierEnquiry", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.SupplierCoupon", "Supplier_Id", "dbo.User");
            DropForeignKey("dbo.SupplierCoupon", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.User", "Company_Id", "dbo.SupplierCompany");
            DropForeignKey("dbo.SupplierCompany", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.SupplierAdvertisement", "Supplier_Id", "dbo.User");
            DropForeignKey("dbo.SupplierAdvertisement", "Location_Id", "dbo.Location");
            DropForeignKey("dbo.Location", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.SupplierAdvertisement", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.User", "WebSite_Id", "dbo.WebSite");
            DropForeignKey("dbo.WebSite", "Settings_Id", "dbo.WebSiteSettings");
            DropForeignKey("dbo.WebSiteSettings", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.WebSitePage", "WebSite_Id", "dbo.WebSite");
            DropForeignKey("dbo.WebSitePage", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.WebSite", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.Message", "NormalUser_Id", "dbo.User");
            DropForeignKey("dbo.Message", "Sender_Id", "dbo.User");
            DropForeignKey("dbo.Message", "Reciever_Id", "dbo.User");
            DropForeignKey("dbo.Message", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.Guest", "NormalUser_Id", "dbo.User");
            DropForeignKey("dbo.Guest", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.CheckList", "NormalUser_Id", "dbo.User");
            DropForeignKey("dbo.CheckList", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.CheckListComment", "CheckList_Id", "dbo.CheckList");
            DropForeignKey("dbo.CheckListComment", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.User", "Budget_Id", "dbo.BudgetSummary");
            DropForeignKey("dbo.BudgetSummary", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.BudgetList", "BudgetSummary_Id", "dbo.BudgetSummary");
            DropForeignKey("dbo.BudgetList", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.SocialAccount", "CreatedBy_Id", "dbo.User");
            DropForeignKey("dbo.User", "CreatedBy_Id", "dbo.User");
            DropIndex("dbo.SupplierCategory", new[] { "CreatedBy_Id" });
            DropIndex("dbo.HoneyMoonPackage", new[] { "CreatedBy_Id" });
            DropIndex("dbo.EventSeatingTable", new[] { "Event_Id" });
            DropIndex("dbo.EventSeatingTable", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Event", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Enquirer", new[] { "CreatedBy_Id" });
            DropIndex("dbo.BlogEntryTag", new[] { "BlogEntry_Id" });
            DropIndex("dbo.BlogEntryTag", new[] { "CreatedBy_Id" });
            DropIndex("dbo.BlogEntry", new[] { "CreatedBy_Id" });
            DropIndex("dbo.BlogEntry", new[] { "Category_Id" });
            DropIndex("dbo.BlogEntryComment", new[] { "BlogEntry_Id" });
            DropIndex("dbo.BlogEntryComment", new[] { "CreatedBy_Id" });
            DropIndex("dbo.SupplierReview", new[] { "Supplier_Id" });
            DropIndex("dbo.SupplierReview", new[] { "Reviewer_Id" });
            DropIndex("dbo.SupplierReview", new[] { "CreatedBy_Id" });
            DropIndex("dbo.SupplierFacility", new[] { "Supplier_Id" });
            DropIndex("dbo.SupplierFacility", new[] { "CreatedBy_Id" });
            DropIndex("dbo.SupplierEnquiry", new[] { "Supplier_Id" });
            DropIndex("dbo.SupplierEnquiry", new[] { "CreatedBy_Id" });
            DropIndex("dbo.SupplierCoupon", new[] { "Supplier_Id" });
            DropIndex("dbo.SupplierCoupon", new[] { "CreatedBy_Id" });
            DropIndex("dbo.SupplierCompany", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Location", new[] { "CreatedBy_Id" });
            DropIndex("dbo.SupplierAdvertisement", new[] { "Supplier_Id" });
            DropIndex("dbo.SupplierAdvertisement", new[] { "Location_Id" });
            DropIndex("dbo.SupplierAdvertisement", new[] { "CreatedBy_Id" });
            DropIndex("dbo.WebSiteSettings", new[] { "CreatedBy_Id" });
            DropIndex("dbo.WebSitePage", new[] { "WebSite_Id" });
            DropIndex("dbo.WebSitePage", new[] { "CreatedBy_Id" });
            DropIndex("dbo.WebSite", new[] { "Settings_Id" });
            DropIndex("dbo.WebSite", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Message", new[] { "NormalUser_Id" });
            DropIndex("dbo.Message", new[] { "Sender_Id" });
            DropIndex("dbo.Message", new[] { "Reciever_Id" });
            DropIndex("dbo.Message", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Guest", new[] { "EventSeatingTable_Id" });
            DropIndex("dbo.Guest", new[] { "Event_Id" });
            DropIndex("dbo.Guest", new[] { "NormalUser_Id" });
            DropIndex("dbo.Guest", new[] { "CreatedBy_Id" });
            DropIndex("dbo.CheckListComment", new[] { "CheckList_Id" });
            DropIndex("dbo.CheckListComment", new[] { "CreatedBy_Id" });
            DropIndex("dbo.CheckList", new[] { "NormalUser_Id" });
            DropIndex("dbo.CheckList", new[] { "CreatedBy_Id" });
            DropIndex("dbo.BudgetList", new[] { "BudgetSummary_Id" });
            DropIndex("dbo.BudgetList", new[] { "CreatedBy_Id" });
            DropIndex("dbo.BudgetSummary", new[] { "CreatedBy_Id" });
            DropIndex("dbo.SocialAccount", new[] { "CreatedBy_Id" });
            DropIndex("dbo.User", new[] { "NormalUser_Id" });
            DropIndex("dbo.User", new[] { "Location_Id" });
            DropIndex("dbo.User", new[] { "Company_Id" });
            DropIndex("dbo.User", new[] { "WebSite_Id" });
            DropIndex("dbo.User", new[] { "Budget_Id" });
            DropIndex("dbo.User", new[] { "CreatedBy_Id" });
            DropIndex("dbo.BlogEntryCategory", new[] { "CreatedBy_Id" });
            DropTable("dbo.SupplierCategory");
            DropTable("dbo.HoneyMoonPackage");
            DropTable("dbo.EventSeatingTable");
            DropTable("dbo.Event");
            DropTable("dbo.Enquirer");
            DropTable("dbo.BlogEntryTag");
            DropTable("dbo.BlogEntry");
            DropTable("dbo.BlogEntryComment");
            DropTable("dbo.SupplierReview");
            DropTable("dbo.SupplierFacility");
            DropTable("dbo.SupplierEnquiry");
            DropTable("dbo.SupplierCoupon");
            DropTable("dbo.SupplierCompany");
            DropTable("dbo.Location");
            DropTable("dbo.SupplierAdvertisement");
            DropTable("dbo.WebSiteSettings");
            DropTable("dbo.WebSitePage");
            DropTable("dbo.WebSite");
            DropTable("dbo.Message");
            DropTable("dbo.Guest");
            DropTable("dbo.CheckListComment");
            DropTable("dbo.CheckList");
            DropTable("dbo.BudgetList");
            DropTable("dbo.BudgetSummary");
            DropTable("dbo.SocialAccount");
            DropTable("dbo.User");
            DropTable("dbo.BlogEntryCategory");
        }
    }
}
