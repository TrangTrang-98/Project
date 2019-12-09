using ApplicationCore.Entities;
namespace ApplicationCore.Specifications
{
    public class DeptSpecification : Specification<Department>
    {
         public DeptSpecification(int pageIndex, int pageSize)
            : base(m => true)
        {
            ApplyPaging(pageIndex, pageSize);
        }
    }
}