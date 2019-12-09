using ApplicationCore.Entities;
using System.Collections.Generic;
namespace ApplicationCore.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<string> GetNames();
        IEnumerable<string> GetDeptIds();
    }
}