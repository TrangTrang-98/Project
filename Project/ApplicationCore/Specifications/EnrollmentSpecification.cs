using ApplicationCore.Specifications;
using ApplicationCore.Entities;
namespace ApplicationCore.Specifications
{
    public class EnrollmentSpecification : Specification<Enrollment>
    {
        public EnrollmentSpecification(int pageIndex, int pageSize)
            : base(m => true)
        {
            ApplyPaging(pageIndex, pageSize);
        }
    }
}