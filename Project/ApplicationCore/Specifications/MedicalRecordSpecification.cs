using ApplicationCore.Specifications;
using ApplicationCore.Entities.PatientAggregate;
namespace ApplicationCore.Specifications
{
    public class MedicalRecordSpecification : Specification<MedicalRecord>
    {
        public MedicalRecordSpecification(int pageIndex, int pageSize)
            : base(m => true)
        {
            ApplyPaging(pageIndex, pageSize);
        }
    }
}