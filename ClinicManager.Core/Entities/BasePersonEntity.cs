using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Core.Entities
{
    public abstract class BasePersonEntity : BaseEntity
    {
        public BasePersonEntity() 
        {

        }

        public BasePersonEntity(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string cpf, EBloodType bloodType, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = new PhoneNumber();
            Email = new Email();
            Cpf = new Cpf();
            BloodType = bloodType;
            Address = new Address();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Email Email { get; private set; }

        public Cpf Cpf { get; private set; }

        public EBloodType BloodType { get; private set; }

        public Address Address { get; private set; }
    }
}
