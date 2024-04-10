using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;

namespace ClinicManager.Application.ViewModels
{
    public class PatientViewModel
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Email Email { get; private set; }

        public Cpf Cpf { get; private set; }

        public EBloodType BloodType { get; private set; }

        public Address Address { get; private set; }

        public double Height { get; private set; }

        public double Weight { get; private set; }

        public Guid Id { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}
