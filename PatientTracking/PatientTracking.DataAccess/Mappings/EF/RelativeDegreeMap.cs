using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientTracking.Entities.Concrete;

namespace PatientTracking.DataAccess.Mappings.EF
{
    public class RelativeDegreeMap : IEntityTypeConfiguration<RelativeDegree>
    {
        public void Configure(EntityTypeBuilder<RelativeDegree> builder)
        {
            builder.ToTable("RelativeDegrees");
        }
    }
}
