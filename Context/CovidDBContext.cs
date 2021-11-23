using Assignment2.Models;

namespace Assignment2.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CovidDBContext : DbContext
    {
        public CovidDBContext()
            : base("name=CovidDBContext")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<TestCentre> TestCentres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
