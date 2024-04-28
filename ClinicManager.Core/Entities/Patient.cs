using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;

namespace ClinicManager.Core.Entities
{
    public class Patient : BasePersonEntity
    {
        public Patient()
        {
            
        }

        public Patient(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email,string password, Cpf cpf, EBloodType bloodType, Address address, double height, double weight) : base(firstName, lastName, dateOfBirth, phoneNumber, email,password, cpf, bloodType, address)
        {
            Height = height;
            Weight = weight;
        }
         
        public double Height { get;  private set; }

        public double Weight { get; private set; }

        public void Update(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, Cpf cpf, EBloodType bloodType, Address address, double height, double weight)
        {
            base.Update(firstName, lastName, dateOfBirth, phoneNumber, email, cpf, bloodType, address);
            Height = height;
            Weight = weight;
        }
    }
}
