using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;

namespace ClinicManager.Core.Entities
{
    public abstract class BasePersonEntity : BaseEntity
    {
        public BasePersonEntity() 
        {

        }

        public BasePersonEntity(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, Cpf cpf, EBloodType bloodType, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Cpf = Cpf;
            BloodType = bloodType;
            Address = address;
            MedicalAppointments = new List<MedicalAppointment>();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Email Email { get; private set; }

        public Cpf Cpf { get; private set; }

        public EBloodType BloodType { get; private set; }

        public Address Address { get; private set; }

        public List<MedicalAppointment> MedicalAppointments { get; private set; }
    }
}
