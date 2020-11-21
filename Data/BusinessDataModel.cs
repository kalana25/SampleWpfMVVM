namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BusinessDataModel : DbContext
    {
        // Your context has been configured to use a 'BusinessDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Data.BusinessDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BusinessDataModel' 
        // connection string in the application configuration file.
        public BusinessDataModel()
            : base("name=BusinessDataModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role>  Roles { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Priviladge> Priviladges { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}