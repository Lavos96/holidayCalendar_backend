using Microsoft.EntityFrameworkCore;
using HolidaysCalendar.Core.Models;
using HolidaysCalendar.DAL.Configurations;

namespace HolidaysCalendar.DAL
{
    public class HolidaysCalendarDbContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public HolidaysCalendarDbContext(DbContextOptions<HolidaysCalendarDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new RequestConfiguration());

            builder
                .ApplyConfiguration(new TypeConfiguration());

            builder
                .ApplyConfiguration(new StatusConfiguration());
        }
    }
}