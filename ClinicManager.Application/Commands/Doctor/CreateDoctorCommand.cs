using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;
using MediatR;

namespace ClinicManager.Application.Commands.Doctor
{
    public class CreateDoctorCommand : IRequest<Result<DoctorViewModel>>
    {
        public CreateDoctorCommand(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, Cpf cpf, EBloodType bloodType, string specialty, Crm crm, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Cpf = cpf;
            BloodType = bloodType;
            Specialty = specialty;
            Crm = crm;
            Address = address;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Email Email { get; private set; }

        public Cpf Cpf { get; private set; }

        public EBloodType BloodType { get; private set; }

        public Address Address { get; private set; }

        public string Specialty { get; private set; }

        public Crm Crm { get; private set; }

    }
}
