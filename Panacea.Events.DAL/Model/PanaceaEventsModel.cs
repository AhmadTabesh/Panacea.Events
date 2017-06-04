namespace Panacea.Events.DAL.Model
{
    using DataObjects;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Utils;

    public class PanaceaEventsModel : DbContext
    {
        // Your context has been configured to use a 'PanaceaEventsModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Panacea.Events.DAL.Model.PanaceaEventsModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PanaceaEventsModel' 
        // connection string in the application configuration file.
        public PanaceaEventsModel()
            : base("name=PanaceaEventsModel")
        {
            Database.SetInitializer(new DbInitializer());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}