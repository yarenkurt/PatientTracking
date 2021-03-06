using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientTracking.Entities.Concrete;

namespace PatientTracking.DataAccess.Mappings.EF
{
    public class PasswordChangeRequestMap : IEntityTypeConfiguration<PasswordChangeRequest>
    {
        public void Configure(EntityTypeBuilder<PasswordChangeRequest> builder)
        {
            builder.ToTable("PasswordChangeRequests");
            builder.HasIndex(x => x.Token).IsUnique();
            builder.Property(x => x.Token).HasMaxLength(255);
        }
    }
}
