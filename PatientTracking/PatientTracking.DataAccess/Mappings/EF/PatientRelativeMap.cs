using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientTracking.Entities.Concrete;

namespace PatientTracking.DataAccess.Mappings.EF
{
    public class PatientRelativeMap : IEntityTypeConfiguration<PatientRelative>
    {
        public void Configure(EntityTypeBuilder<PatientRelative> builder)
        {
            builder.ToTable("PatientRelatives");
        }
    }
}
