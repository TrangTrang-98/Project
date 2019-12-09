using ApplicationCore.Interfaces;
using ApplicationCore.Entities.DoctorAggregate;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.DTO;
using ApplicationCore.Entities;
using AutoMapper;
namespace Infrastructure.Persistence.Repository
{
    public class EnrollmentRepository : EFRepository<Enrollment>,  IEnrollmentRepository
    {
        
       public EnrollmentRepository(RegisterContext context) : base(context)
       {
           
       }

       

        // public IEnumerable<EnrollmentsDTO> GetAllEnrollments()
        // {
     
        //     IEnumerable<EnrollmentsDTO> all = from e in Context.Enrollments select e;
        //     return all;
        // }
        
        protected new RegisterContext Context => base.Context as RegisterContext;
    }
    
}