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
             if(!context.Accounts.Any())
            {
                context.Accounts.AddRange(
                    new Account("admin", "123456","Admin")
                );
                context.SaveChanges();
            }
             
             var patients = new Patient[]
            {

                 new Patient
                {
                   Id="A001", 
                   Name="Nguyễn Hà Thu",
                   BirthDay = System.DateTime.Parse("1989-12-6"),
                    Gender = Gender.female,
                   Address = new Address("198","Đường số 12","Quận 1", "TPHCM","Việt Nam"),
                   Phone = "0337859647", 
                   Email="trangcute011298@gmail.com",
                   Account = new Account("SuKa", "123" ,"Bệnh Nhân"),
                   MedicalRecord = new MedicalRecord ("A001", "Thai Nhi Bình Thường","Lê Thị Hà Giang" ) 
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
                    Account = new Account("HelloKiTy", "456",  "Bệnh Nhân")  ,
                    MedicalRecord = new MedicalRecord ("B004", "Suy Dinh Dưỡng","Nguyễn Thị Tuyết Trang" )            
                   },
                new Patient
                {
                   Id = "B008", 
                   Name="Nguyễn Hà Nam",
                  
                   BirthDay = System.DateTime.Parse("1996-9-9"),
                    Gender = Gender.male,
                   Address = new Address("19","Nguyễn Thượng Hiền","Quận 1", "TPHCM","Việt Nam"),
                   Phone = "09794567895" ,
                   Email="nguyenha1998@gmail.com",
                    Account = new Account("SayHi", "nam",  "Bệnh Nhân") ,
                     MedicalRecord = new MedicalRecord ("B008", "Gan nhiễm mỡ","Châu Văn Thành" )             
                   },
                new Patient
                {
                   Id = "S014", 
                   Name="Nguyễn Văn Anh",
                  
                   BirthDay = System.DateTime.Parse("1996-8-9"),
                    Gender = Gender.female,
                   Address = new Address("19","Nguyễn Thượng Hiền","Quận 1", "TPHCM","Việt Nam"),
                   Phone = "09794567895" ,
                   Email="nguyenha1998@gmail.com",
                    Account = new Account("AnhKiuKiu", "kiukiu",  "Bệnh Nhân"),
                    MedicalRecord = new MedicalRecord ("S014", "Thai Nhi Bình Thường","Lê Thị Hà Giang" )               
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
                new Doctor("NG008","Châu Văn Thành",System.DateTime.Parse("1995-2-2"), Gender.male, "0975658745",new Account("Bác Sĩ Thành", "123", "Bác Sĩ"),"NG"),
                new Doctor("SA014","Lê Thị Hà Giang",System.DateTime.Parse("1993-5-6"), Gender.female, "0975658745",new Account("Bác Sĩ Giang", "456", "Bác Sĩ"),"SA"),
                new Doctor("PT985","Lương Thế Vinh", System.DateTime.Parse("1989-12-1"),Gender.male, "0975658745",new Account("Bác Sĩ Vinh", "789", "Bác Sĩ"),"PT"),
                new Doctor("PT246","Phạm Văn Khánh", System.DateTime.Parse("1989-8-1"),Gender.male, "0975658885",new Account("Bác Sĩ Khánh", "222", "Bác Sĩ"),"PT"),
                new Doctor("DD985","Nguyễn Thị Tuyết Trang", System.DateTime.Parse("1998-12-1"),Gender.female, "0338147631",new Account("Bác Sĩ Trang", "bstrang", "Bác Sĩ"),"DD"),
                new Doctor("TM784","Nguyễn Thị Thùy Trang", System.DateTime.Parse("1998-6-9"),Gender.female, "097565845",new Account("Bác Sĩ TT", "789", "Bác Sĩ"),"TM"),
                new Doctor("RH734","Nguyễn Phú Đạt", System.DateTime.Parse("1999-5-9"),Gender.male, "087436845",new Account("Bác Sĩ Đạt", "202", "Bác Sĩ"),"RH"),
                new Doctor("NG994","Châu Vĩ Khanh", System.DateTime.Parse("1987-10-10"),Gender.male, "083565845",new Account("Bác Sĩ Khanh", "701", "Bác Sĩ"),"NG"),
                new Doctor("DD342","Lê Thị Ái Hương", System.DateTime.Parse("1974-9-5"),Gender.female, "022565845",new Account("Bác Sĩ Hương", "808", "Bác Sĩ"),"DD"),
                new Doctor("CA774","Phạm Thị Hương", System.DateTime.Parse("1985-10-3"),Gender.female, "0224512356",new Account("Bác Sĩ TH", "999", "Bác Sĩ"),"CA"),
                new Doctor("TK764","Lương Thế Hà", System.DateTime.Parse("1974-9-9"),Gender.male, "0331245789",new Account("Bác Sĩ Hà", "888", "Bác Sĩ"),"TK"),
                new Doctor("NT783","Hà Văn Vũ", System.DateTime.Parse("1984-8-9"),Gender.male, "0331245455",new Account("Bác Sĩ Vũ", "333", "Bác Sĩ"),"NT"),
                new Doctor("CT799","Lâm Thị Bích", System.DateTime.Parse("1979-12-10"),Gender.female, "0369248799",new Account("Bác Sĩ Bích", "512", "Bác Sĩ"),"CT"),
                new Doctor("KS451","Đoàn Văn Thanh", System.DateTime.Parse("1979-10-9"),Gender.male, "0369778799",new Account("Bác Sĩ Thanh", "555", "Bác Sĩ"),"KS"),
                new Doctor("TH564","Nguyễn Thị Lan", System.DateTime.Parse("1980-7-8"),Gender.female, "0234578941",new Account("Bác Sĩ Lan", "444", "Bác Sĩ"),"TH")

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
                },
                 new Department
                {
                    DeptId = "TH",
                    DeptName = "Khoa Tai Mũi Họng",
                    // single: tra ve 1 doi tuong duoc tim thay neu trung khop
                    //DoctorHead = doctors.Single(d => d.Id == "NG008").Name
                },
                new Department
                {
                    DeptId = "TM",
                    DeptName = "Khoa Tim Mạch",
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
                    PatientId = patients.Single(e => e.Name == "Nguyễn Hà Thu").Id,
                    DoctorId = doctors.Single(d => d.Name == "Châu Văn Thành").Id,
                   EnrollmentDate = System.DateTime.Parse("1998-2-24")
                },
                new Enrollment
                {
                    PatientId = patients.Single(e => e.Name == "Van Duc").Id,
                    DoctorId = doctors.Single(d => d.Name == "Lương Thế Vinh").Id,
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
            }
            
        }
    }
}