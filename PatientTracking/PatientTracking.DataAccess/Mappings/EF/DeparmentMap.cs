using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientTracking.Entities.Concrete;

namespace PatientTracking.DataAccess.Mappings.EF
{
    public class DeparmentMap : IEntityTypeConfiguration<Deparment>
    {
        public void Configure(EntityTypeBuilder<Deparment> builder)
        {
            builder.ToTable("Deparments");
        }
    }
}
