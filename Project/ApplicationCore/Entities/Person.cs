using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;
using ApplicationCore;
using ApplicationCore.Entities;
using System;
namespace ApplicationCore.Entities
{
    public class Person : IAggregateRoot
    {
         public string Id { get; set; }

        public string Name{get; set;}

        public DateTime BirthDay { get; set; }

        public Address Address { get; set; }

        public Account Account { get; set; }

         public string Phone { get; set; }

        public Gender Gender { get; set; }

        public Person() { }
        public Person(string id, string name, DateTime birthDay, Gender gender, string phone, Address address,  Account account)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDay = birthDay;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
            this.Account = account;

        }

        public Person(string id, string name, DateTime birthDay, Gender gender, string phone,  Account account)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDay = birthDay;
            this.Gender = gender;
            this.Phone = phone;
            this.Account = account;

        }

          public Person(string id, string name, DateTime birthDay, Gender gender, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDay = birthDay;
            this.Gender = gender;
            this.Phone = phone;

        }
    
       

    }

}