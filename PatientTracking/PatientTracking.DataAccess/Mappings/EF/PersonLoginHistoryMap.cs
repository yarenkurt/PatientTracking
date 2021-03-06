using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientTracking.Entities.Concrete;

namespace PatientTracking.DataAccess.Mappings.EF
{
    public class PersonLoginHistoryMap : IEntityTypeConfiguration<PersonLoginHistory>
    {
        public void Configure(EntityTypeBuilder<PersonLoginHistory> builder)
        {
            builder.ToTable("PersonLoginHistories");
            builder.Property(x => x.IpAddress).HasMaxLength(15);
        }
    }
}
