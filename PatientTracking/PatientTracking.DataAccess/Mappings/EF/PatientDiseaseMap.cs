using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientTracking.Entities.Concrete;

namespace PatientTracking.DataAccess.Mappings.EF
{
    public class PatientDiseaseMap : IEntityTypeConfiguration<PatientDisease>
    {
        public void Configure(EntityTypeBuilder<PatientDisease> builder)
        {
            builder.ToTable("PatientDiseases");
            builder.HasIndex(x => new {x.PatientId,x.DiseaseId }).IsUnique();
        }
    }
}
