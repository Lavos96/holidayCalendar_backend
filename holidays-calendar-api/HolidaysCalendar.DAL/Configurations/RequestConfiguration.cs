using HolidaysCalendar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HolidaysCalendar.DAL.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder
                .HasKey(request => request.Id);

            builder
                .Property(request => request.Id)
                .UseIdentityColumn();

            builder
                .Property(request => request.StartDate)
                .IsRequired();

            builder
                .Property(request => request.EndDate)
                .IsRequired();

            builder
                .HasOne(request => request.Type)
                .WithMany(type => type.Requests)
                .HasForeignKey(request => request.TypeId);

            builder
                .HasOne(request => request.Status)
                .WithMany(status => status.Requests)
                .HasForeignKey(request => request.StatusId);

            builder
                .ToTable("Requests");
        }
    }
}