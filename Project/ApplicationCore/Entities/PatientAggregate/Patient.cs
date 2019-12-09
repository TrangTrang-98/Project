using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using ApplicationCore;
namespace ApplicationCore.Entities.PatientAggregate
{
    public class Patient : Person, IAggregateRoot
    {
        public Patient() : base(){}
        

        public string Email{get; set;}
       
        
       public Patient(string id, string name, DateTime birthDay, Gender gender, string phone, Address address,
                Account account, string email) : base(id, name, birthDay, gender, phone, address, account)
        {
            this.Email = email;

        }

    }

}