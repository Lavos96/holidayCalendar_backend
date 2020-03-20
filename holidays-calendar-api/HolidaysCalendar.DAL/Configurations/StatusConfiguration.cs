using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HolidaysCalendar.Core.Models;

namespace HolidaysCalendar.DAL.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder
                .HasKey(status => status.Id);

            builder
                .Property(status => status.Id)
                .UseIdentityColumn();
                
            builder
                .Property(status => status.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Statuses");
        }
    }
}