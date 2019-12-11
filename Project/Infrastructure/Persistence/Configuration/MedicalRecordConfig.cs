using ApplicationCore.Entities.PatientAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Configuration
{
     public class MedicalRecordConfig : IEntityTypeConfiguration<MedicalRecord> {
    public void Configure(EntityTypeBuilder<MedicalRecord> builder) {
       


        builder.HasNoKey();
        
        builder.Property(i => i.PersonId);
            
        builder.Property(i => i.Diagnostic)
            .HasMaxLength(40)
            .IsRequired(true);

            
        builder.Property(i => i.AttendingDoctorName)
            .HasMaxLength(40)
            .IsRequired(true);

        
            
       
    }
}
}