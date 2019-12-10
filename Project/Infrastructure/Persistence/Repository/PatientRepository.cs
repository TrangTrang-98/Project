using ApplicationCore.Interfaces;
using ApplicationCore.Entities.PatientAggregate;
using Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Repository
{
    public class PatientRepository : EFRepository<Patient>, IPatientRepository
    {
        public PatientRepository(RegisterContext context) : base(context)
        {
            
        }

        // must implement every member in the specified interface (I---Repository)
         public IEnumerable<string> GetNames()
        {
            return Context.Patients
                            .Select(m => m.Name)
                            .Distinct().ToList();
        }

        public Patient GetPatientIDByAccountID(string user)
        {
            return Context.Patients.Where(p => p.Account.Username == user).FirstOrDefault();
             
        }

        public IEnumerable<string> AllPatientId()
       {
           return Context.Patients
                                .Select(p => p.Id)
                                .Distinct().ToList();
       }

      
        // if it has not base., it will stack overflow
        protected new RegisterContext Context => base.Context as RegisterContext;
    }
}