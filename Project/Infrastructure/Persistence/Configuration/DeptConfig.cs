using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities.DoctorAggregate;
namespace Infrastructure.Persistence.Configuration
{
    public class DeptConfig: IEntityTypeConfiguration<Department> {
    public void Configure(EntityTypeBuilder<Department> builder) {
       // builder.ToTable("Enrollment");

           
        builder.HasKey(i => i.DeptId);

        builder.Property(i => i.DeptName);


        builder.HasOne<Doctor>(i => i.Doctor);
                
    
         builder.HasMany<Doctor>(i => i.Doctors);   
           
        }
    }
}