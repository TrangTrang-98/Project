using ApplicationCore.Entities.PatientAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Configuration
{
     public class MedicalRecordConfig : IEntityTypeConfiguration<MedicalRecord> {
    public void Configure(EntityTypeBuilder<MedicalRecord> builder) {
        //builder.ToTable("Patients");

        //var ownedPatient = entity.OwnsOne(x => x.Patient);


        
        builder.HasKey(i => i.MedicalRecordId);

        builder.Property(i => i.Id)
             .HasMaxLength(40)
            .IsRequired(true);


        builder.Property(i => i.Name)
            .HasMaxLength(40)
            .IsRequired(true);

        builder.Property(i => i.Gender)
            .HasMaxLength(84)
            .IsRequired(true);

        builder.Property(i => i.BirthDay)
            .IsRequired(true);
        
        builder.OwnsOne(i => i.Address)
             .Property(x => x.NumHouse).HasColumnName("NumHouse");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Street).HasColumnName("Street");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.District).HasColumnName("District");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.City).HasColumnName("City");

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Country).HasColumnName("Country");

        builder.Property(i => i.Phone)
            .HasMaxLength(10)
            .IsRequired(true);


            
        builder.Property(i => i.Diagnostic)
            .HasMaxLength(40)
            .IsRequired(true);

            
        builder.Property(i => i.AttendingDoctorName)
            .HasMaxLength(40)
            .IsRequired(true);
            
       
    }
}
}