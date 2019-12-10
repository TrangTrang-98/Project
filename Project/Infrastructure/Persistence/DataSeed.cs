using ApplicationCore.Entities.PatientAggregate;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.DoctorAggregate;
using ApplicationCore;
using ApplicationCore.Entities;

namespace Infrastructure.Persistence
{
    public class DataSeed
    {
        public static void Initialize(RegisterContext context)
        {
           
            context.Database.EnsureCreated();
            
            // DB has seeded
            
             
            var patients = new Patient[]
            {
                 new Patient
                {
                   Id="A001", 
                   Name="Nguyen Ha",
                   BirthDay = System.DateTime.Parse("1989-12-6"),
                    Gender = Gender.female,
                   Address = new Address("198","Đường số 12","Quận 1", "TPHCM","Việt Nam"),
                   Phone = "0337859647", 
                   Email="trangcute011298@gmial.com",
                   Account = new Account("SuKa", "123","Bệnh Nhân", "P001")
                   },
                new Patient
                {
                   Id = "B004", 
                   Name="Van Duc",
                  
                   BirthDay = System.DateTime.Parse("1996-8-9"),
                    Gender = Gender.male,
                   Address = new Address("19","Nguyễn Thượng Hiền","Quận 1", "TPHCM","Việt Nam"),
                   Phone = "09794567895" ,
                   Email="nguyenha1998@gmail.com",
                    Account = new Account("HelloKiTy", "456", "Bệnh Nhân", "P002")              
                   }
            };
            if (!context.Patients.Any())
            {
                foreach (Patient p in patients)
                {
                    context.Patients.Add(p); 
                }
                context.SaveChanges();
            }


            var doctors = new Doctor[]
            {
                new Doctor("NG008","Châu Văn Thành",System.DateTime.Parse("1995-2-2"), Gender.male, "0975658745",new Account("Bác Sĩ Thành", "123", "Bác Sĩ", "D001"),"NG"),
                new Doctor("SA014","Lê Thị Hà Giang",System.DateTime.Parse("1993-5-6"), Gender.female, "0975658745",new Account("Bác Sĩ Giang", "456", "Bác Sĩ", "D002"),"SA"),
                new Doctor("PT985","Lương Thế Vinh", System.DateTime.Parse("1989-12-1"),Gender.male, "0975658745",new Account("Bác Sĩ Vinh", "789", "Bác Sĩ", "D003"),"PT"),
                new Doctor("PT246","Phạm Văn Khánh", System.DateTime.Parse("1989-8-1"),Gender.male, "0975658885",new Account("Bác Sĩ Khánh", "222", "Bác Sĩ","D004"),"PT")

            };
            if (!context.Doctors.Any())
            {
                foreach (Doctor d in doctors)
                {
                    context.Doctors.Add(d); 
                }    
            context.SaveChanges();

             }  
           
            var departments = new Department[]
            {
                new Department
                {
                    DeptId = "SA",
                    DeptName = "Khoa Sản",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    DoctorHead = doctors.Single(d => d.Id == "SA014").Name
                },
                new Department
                {
                    DeptId = "PT",
                    DeptName = "Khoa Phẫu Thuật",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    DoctorHead = doctors.Single(d => d.Id == "PT985").Name
                },
                new Department
                {
                    DeptId = "NG",
                    DeptName = "Khoa Ngoại Tổng Quát",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    DoctorHead = doctors.Single(d => d.Id == "NG008").Name
                },
                new Department
                {
                    DeptId = "TK",
                    DeptName = "Khoa Thần Kinh",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    //DoctorHead = doctors.Single(d => d.Id == "NG008").Name
                },
                 new Department
                {
                    DeptId = "DD",
                    DeptName = "Khoa Điều Dưỡng",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    //DoctorHead = doctors.Single(d => d.Id == "NG008").Name
                },
                 new Department
                {
                    DeptId = "NT",
                    DeptName = "Khoa Nội Tiêu Hóa",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    //DoctorHead = doctors.Single(d => d.Id == "NG008").Name
                },
                 new Department
                {
                    DeptId = "CA",
                    DeptName = "Khoa Cấp Cứu",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    //DoctorHead = doctors.Single(d => d.Id == "NG008").Name
                },
                new Department
                {
                    DeptId = "CT",
                    DeptName = "Khoa Chấn Thương Chỉnh Hình ",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    //DoctorHead = doctors.Single(d => d.Id == "NG008").Name
                },
                new Department
                {
                    DeptId = "RH",
                    DeptName = "Khoa Răng Hàm Mặt",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    //DoctorHead = doctors.Single(d => d.Id == "NG008").Name
                },
                 new Department
                {
                    DeptId = "KS",
                    DeptName = "Khoa Kiểm Soát Nhiễm Khuẫn",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    //DoctorHead = doctors.Single(d => d.Id == "NG008").Name
                },
                 new Department
                {
                    DeptId = "UB",
                    DeptName = "Khoa Ung Bứu",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    //DoctorHead = doctors.Single(d => d.Id == "NG008").Name
                }
                
            };

            if(!context.Departments.Any())
            {
                foreach (Department dept in departments)
                {
                    var DeptInData = context.Departments.Where(
                        dp =>
                                dp.Doctor.Id == dept.DoctorId).SingleOrDefault();

                    if (DeptInData == null)
                    {
                        context.Departments.Add(dept);
                    }

                }

                context.SaveChanges();
            }    

            var enrollments = new Enrollment[]
            {
                new Enrollment
                {
                    PatientId = patients.Single(e => e.Name == "Nguyen Ha").Id,
                    DoctorId = doctors.Single(d => d.Name == "Châu Văn Thành").Id,
                    // DeptName = departments.Single(dept => dept.DeptId.Equals(
                    //             doctors.Single(d => d.Name == "Châu Văn Thành").Id)).DeptName,
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                   EnrollmentDate = System.DateTime.Parse("1998-2-24")
                },
                new Enrollment
                {
                    PatientId = patients.Single(e => e.Name == "Van Duc").Id,
                    DoctorId = doctors.Single(d => d.Name == "Lương Thế Vinh").Id,
                    // DeptName = departments.Single(dept => dept.DeptId.Equals(  
                    //             doctors.Single(d => d.Name == "Lương Thế Vinh").Id)).DeptName,
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                   EnrollmentDate = System.DateTime.Parse("2000-1-1")
                }
            };
            if(!context.Enrollments.Any())
            {
                foreach (Enrollment e in enrollments)
                {
                    var EnrollInData = context.Enrollments.Where(
                        e =>
                                e.Doctor.Id == e.DoctorId &&
                                e.Patient.Id == e.PatientId).SingleOrDefault();

                    if (EnrollInData == null)
                    {
                        context.Enrollments.Add(e);
                    }
                     // cung ten voi DbSet<Patient> Patient trong RegisterContext

                }

                context.SaveChanges();

               
                context.Accounts.AddRange(
                    new Account("admin", "123456","Admin" ,"")
                );
                context.SaveChanges();
            }
        }
    }
}