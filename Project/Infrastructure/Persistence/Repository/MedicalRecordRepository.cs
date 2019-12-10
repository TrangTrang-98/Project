using ApplicationCore.Interfaces;
using ApplicationCore.Entities.PatientAggregate;
using Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Persistence.Repository
{
    public class MedicalRecordRepository : EFRepository<MedicalRecord>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(RegisterContext context) : base(context)
        {
            
        }

        // must implement every member in the specified interface (I---Repository)
         public IEnumerable<string> GetMedicalRecordNames()
        {
            return Context.MedicalRecords
                            .Select(m => m.Name)
                            .Distinct().ToList();
        }

        public IEnumerable<string> AllMedicalRecordId()
       {
           return Context.MedicalRecords
                                .Select(p => p.Id)
                                .Distinct().ToList();
       }

      
        // if it has not base., it will stack overflow
        protected new RegisterContext Context => base.Context as RegisterContext;
    }
}