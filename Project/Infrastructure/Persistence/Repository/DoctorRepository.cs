using ApplicationCore.Interfaces;
using ApplicationCore.Entities.DoctorAggregate;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.DTO;
namespace Infrastructure.Persistence.Repository
{
    public class DoctorRepository : EFRepository<Doctor>,  IDoctorRepository
    {
       public DoctorRepository(RegisterContext context) : base(context)
       {
           
       }

        public IEnumerable<string> GetNames()
        {
            return Context.Doctors
                            .Select(m => m.Name)
                           //.Where(m => m.DeptId == deptId).Single()
                            .Distinct().ToList();
        }

        public Doctor[] getIdsByDept(string dept)
        {
            return Context.Doctors.Where(d => d.DeptId == dept).ToArray();
            
        }

         public IEnumerable<string> AllDoctorId()
         {
                return Context.Doctors
                                .Select(p => p.Id)
                                .Distinct().ToList();
         }
        // public IEnumerable<Doctor> GetAllDoctors()
        // {
        //      IQueryable<Doctor> all = from d in Context.Doctors select d;
        //      return all;
            
        // }

        public Doctor[] getIdsByDept(string dept)
        {
            return Context.Doctors.Where(d => d.DeptId == dept).ToArray();
            
        }
        
        protected new RegisterContext Context => base.Context as RegisterContext;
    }
    
}