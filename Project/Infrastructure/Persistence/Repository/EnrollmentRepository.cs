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

       

        // public Enrollment GetIdEnroll(string IDPatient, string IDDoctor)
        // {
        //      return Context.Enrollments
        //                         .Where(e => e.PatientId == IDPatient )
        //                         .Where( e => e.DoctorId == IDDoctor)
        //                         .First();
        // }

        public Enrollment GetIdEnrollIdPatient(string IDPatient)
        {
             return Context.Enrollments
                                .Where(e => e.PatientId == IDPatient )
                            
                                .FirstOrDefault();
        }

        public Enrollment GetIdEnroll(string IDPatient)
        {
            return Context.Enrollments
                                .Where(e => e.PatientId == IDPatient )
                                .FirstOrDefault();
        }
        
        protected new RegisterContext Context => base.Context as RegisterContext;
    }
    
}