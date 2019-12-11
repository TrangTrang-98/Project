using ApplicationCore.Entities;
using System.Collections.Generic;
using ApplicationCore.DTO;
using System.Linq;
namespace ApplicationCore.Interfaces
{
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        
         Enrollment GetIdEnroll(string IDPatient, string IDDoctor);
        
    }
}