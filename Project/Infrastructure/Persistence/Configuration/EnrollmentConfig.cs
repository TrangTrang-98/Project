using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.Entities.PatientAggregate;
namespace Infrastructure.Persistence.Configuration
{
    public class EnrollmentConfig : IEntityTypeConfiguration<Enrollment> {
    public void Configure(EntityTypeBuilder<Enrollment> builder) {
       // builder.ToTable("Enrollment");

        //builder.HasNoKey();
        builder.HasOne<Patient>(i => i.Patient);

       builder.HasOne<Doctor>(i => i.Doctor);

        //builder.Property(i => i.DoctorId);

         builder.HasKey(i => new{i.PatientId,i.DoctorId} );
        
        
        builder.Property(i => i.EnrollmentDate);

        builder.Property(i => i.DeptName);   
        }
    }
}