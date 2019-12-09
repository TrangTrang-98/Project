using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;
namespace Infrastructure.Persistence.Repository
{
    public class DeptRepository : EFRepository<Department>, IDepartmentRepository
    {
        public DeptRepository(RegisterContext context) : base(context)
        {
            
        }
         public IEnumerable<string> GetNames()
            {
                return Context.Departments
                                .Select(m => m.DeptName)
                                .Distinct().ToList();
            }
         public IEnumerable<string> GetDeptIds()
            {
                return Context.Departments
                                .Select(m => m.DeptId)
                                .Distinct().ToList();
            }

       
        protected new RegisterContext Context => base.Context as RegisterContext;
        }
    
}