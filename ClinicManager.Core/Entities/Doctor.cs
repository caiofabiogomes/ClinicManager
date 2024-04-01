using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;

namespace ClinicManager.Core.Entities
{
    public class Doctor : BasePersonEntity
    {
        public Doctor()
        {

        }

        public Doctor(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, Cpf cpf, EBloodType bloodType, string specialty, Crm crm , Address address) : base(firstName, lastName, dateOfBirth, phoneNumber, email, cpf, bloodType,address)
        {
            Specialty = specialty;
            Crm = crm;
        }

        public string Specialty { get; private set; }

        public Crm Crm { get; private set; }
    }
}
