using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using ApplicationCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ApplicationCore.Entities.PatientAggregate
{
     [Owned]
    public class MedicalRecord : IAggregateRoot
    {
    
        public string PersonId{get; set;}
        // public Patient Patient{get; set;}
       // public string MedicalRecordId{get;set;}
        public string Diagnostic{get;set;}

        public string AttendingDoctorName{get;set;}

    
       
        public MedicalRecord(){}
       public MedicalRecord(string personId, string diagnostic, string attendingdoctorname) 
        {
            this.PersonId = personId;
            this.Diagnostic = diagnostic;
            this.AttendingDoctorName = attendingdoctorname;

        }

    }

}