using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities
{
    public class Account : IAggregateRoot

    {
        // public string Id{get; set;}
        public string Username{get; set;}
        public string Password{get; set;}
        public string Roles{get; set;}
        public string PersonID { get; set; }

         public Account() { }

        public Account(string Username, string Password, string Roles, string personID)
        {
            this.Username = Username;
            this.Password = Password;
            this.Roles = Roles;
            this.PersonID = personID;
        }

        public Account(Account acc)
        {
            this.Username = acc.Username;
            this.Password = acc.Password;
            this.Roles = acc.Roles;
            this.PersonID = acc.PersonID;
        }

    }

    
}