using ApplicationCore.Interfaces;
using System.Collections.Generic;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore.DTO;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using ApplicationCore.Specifications;
using System.Linq;
using ApplicationCore.Entities;
using Presentation.ViewModel;
using ApplicationCore.Entities.PatientAggregate;
namespace Presentation.Services
{
    public class EnrollmentService: IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private int pageSize = 5;
        public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

         public EnrollmentPageVM GetEnrollmentPageViewModel(int pageIndex = 1)
        {
       
            var rs = _unitOfWork.Enrollments.GetAll();
            var enrollments = _mapper.Map<IEnumerable<Enrollment>, IEnumerable<EnrollmentsDTO>>(rs);
            return new EnrollmentPageVM
            {
                ListEnrollment = PaginatedList<EnrollmentsDTO>.Create(enrollments, pageIndex, pageSize)
            };
        }

        public EnrollmentPageVM GetEnrollmentsByPatientID(string id,int pageIndex = 1)
        {
            var tempEnRoll = _unitOfWork.Enrollments.GetAll().Where(e => e.PatientId == id);
            var enrollments = _mapper.Map<IEnumerable<Enrollment>, IEnumerable<EnrollmentsDTO>>(tempEnRoll);
            return new EnrollmentPageVM
            {
                ListEnrollment = PaginatedList<EnrollmentsDTO>.Create(enrollments, pageIndex, pageSize)
            };
        }

        public Patient GetPatient(string id)
        {
            return _unitOfWork.Patients.GetBy(id);
        }
       
         public IEnumerable<string> AllPatientId()
         {
             return _unitOfWork.Patients.AllPatientId();
         }

        public IEnumerable<string> AllDoctorId()
        {
            return _unitOfWork.Doctors.AllDoctorId();
        }

         public void CreateEnrollment(Enrollment enrollment)
         {
             _unitOfWork.Enrollments.Add(enrollment);
             _unitOfWork.Complete();
         }

         public void UpdateEnrollment(Enrollment enrollment)
         {
            _unitOfWork.Doctors.AllDoctorId();
             _unitOfWork.Complete();
         }

        public string generateID()
        {
            int temp = _unitOfWork.countEnrollments();
            if(temp < 10)
                return ("E00" + temp);
            else if(temp < 100)
                return ("E0" + temp);
            else return ("E" + temp);
        }
    }
}