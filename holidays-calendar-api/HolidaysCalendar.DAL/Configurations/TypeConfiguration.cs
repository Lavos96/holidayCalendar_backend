using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HolidaysCalendar.Core.Models;

namespace HolidaysCalendar.DAL.Configurations
{
    public class TypeConfiguration : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
            builder
                .HasKey(type => type.Id);

            builder
                .Property(type => type.Id)
                .UseIdentityColumn();
                
            builder
                .Property(type => type.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Types");
        }
    }
}