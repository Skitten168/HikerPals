using Microsoft.EntityFrameworkCore;


namespace HikerPals.Models
{
    public class HikerContext : DbContext
    {
        public HikerContext (DbContextOptions<HikerContext> options) : base(options) { }
        public DbSet<Hiker> Hikers { get; set; }
        public DbSet<Trail> Trails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Hiker>().HasData(
                    new Hiker
                    {
                        Id = 1,
                        TrailName = "Low Branch",
                        Age = 45,
                        AverageDailyMiles = 15,
                        YearsExperience = 15,
                        email = "littleJimmy@aol.com"
                    },

                      new Hiker
                      {
                          Id = 2,
                          TrailName = "Ten Steps",
                          Age = 65,
                          AverageDailyMiles = 7,
                          YearsExperience = 30,
                          email = "ten@aol.com"
                      },

                      new Hiker
                      {
                          Id = 3,
                          TrailName = "Coach",
                          Age = 33,
                          AverageDailyMiles = 4,
                          YearsExperience = 2,
                          email = "coach@aol.com"
                      },
                      new Hiker
                      {
                          Id = 4,
                          TrailName = "The Captain",
                          Age = 35,
                          AverageDailyMiles = 4,
                          YearsExperience = 2,
                          email = "Cap@aol.com"
                      }
                );
            modelBuilder.Entity<Trail>().HasData(
                new Trail
                {
                    TrailId = 1,
                    TName ="Appalacian Trail",
                    Distance = 2190.0,
                    HikerId = 1
                }
                );


    }
    }
}
