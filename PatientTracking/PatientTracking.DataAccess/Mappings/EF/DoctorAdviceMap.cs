using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientTracking.Entities.Concrete;

namespace PatientTracking.DataAccess.Mappings.EF
{
    public class DoctorAdviceMap : IEntityTypeConfiguration<DoctorAdvice>
    {
        public void Configure(EntityTypeBuilder<DoctorAdvice> builder)
        {
            builder.ToTable("DoctorAdvices");
        }
    }
}
