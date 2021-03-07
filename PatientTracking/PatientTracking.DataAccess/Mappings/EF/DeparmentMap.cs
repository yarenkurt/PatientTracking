using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientTracking.Entities.Concrete;

namespace PatientTracking.DataAccess.Mappings.EF
{
    public class DeparmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Deparments");
        }
    }
}
