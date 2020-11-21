namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.String(nullable: false, maxLength: 128),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Date = c.DateTime(storeType: "date"),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        DayCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Speciality = c.String(),
                        Experiance = c.Int(nullable: false),
                        RegisterNo = c.String(nullable: false),
                        Email = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        OtherName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false),
                        ContactNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        OtherName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false),
                        ContactNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConfigurationDetails",
                c => new
                    {
                        ConfigDetailCode = c.String(nullable: false, maxLength: 128),
                        ConfigDetailName = c.String(),
                        ConfigDetailDescrp = c.String(),
                        Code = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ConfigDetailCode)
                .ForeignKey("dbo.SystemConfigurations", t => t.Code, cascadeDelete: true)
                .Index(t => t.Code);
            
            CreateTable(
                "dbo.SystemConfigurations",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ModuleId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        ModuleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SectionId)
                .ForeignKey("dbo.Modules", t => t.ModuleId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramCode = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Section_SectionId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProgramCode)
                .ForeignKey("dbo.Sections", t => t.Section_SectionId)
                .Index(t => t.Section_SectionId);
            
            CreateTable(
                "dbo.Priviladges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Add = c.Boolean(nullable: false),
                        Edit = c.Boolean(nullable: false),
                        Delete = c.Boolean(nullable: false),
                        View = c.Boolean(nullable: false),
                        Approve = c.Boolean(nullable: false),
                        Unapprove = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                        ProgramCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programs", t => t.ProgramCode)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ProgramCode);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        RoleCode = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programs", "Section_SectionId", "dbo.Sections");
            DropForeignKey("dbo.Priviladges", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Priviladges", "ProgramCode", "dbo.Programs");
            DropForeignKey("dbo.Sections", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.ConfigurationDetails", "Code", "dbo.SystemConfigurations");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Priviladges", new[] { "ProgramCode" });
            DropIndex("dbo.Priviladges", new[] { "RoleId" });
            DropIndex("dbo.Programs", new[] { "Section_SectionId" });
            DropIndex("dbo.Sections", new[] { "ModuleId" });
            DropIndex("dbo.ConfigurationDetails", new[] { "Code" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Priviladges");
            DropTable("dbo.Programs");
            DropTable("dbo.Sections");
            DropTable("dbo.Modules");
            DropTable("dbo.SystemConfigurations");
            DropTable("dbo.ConfigurationDetails");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
