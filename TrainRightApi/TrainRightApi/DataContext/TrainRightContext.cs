using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TrainRightApi.Models;

namespace TrainRightApi.DataContext
{
    public class TrainRightContext : DbContext
    {

        public DbSet<SinCategory> SinCategory { get; set; }

        public DbSet<SinSubCategory> SinSubCategory { get; set; }

        public DbSet<SinSubCatCrossRef> SinSubCatCrossRef { get; set; }

        public DbSet<SinSectionHeader> SinSectionHeader { get; set; }

        public DbSet<SinSection> SinSection { get; set; }

        public DbSet<InfoCommands> InfoCommands { get; set; }

        public DbSet<WhatHappens> WhatHappens { get; set; }

        public DbSet<Repentance> Repentance { get; set; }


        public TrainRightContext() : base("TrainRightConx")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}