using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;
using MediatR;

namespace ClinicManager.Application.Commands.Patient
{
    public class CreatePatientCommand : IRequest<Result<PatientViewModel>>
    {
        public CreatePatientCommand(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, Cpf cpf, EBloodType bloodType, Address address, double height, double weight)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Cpf = cpf;
            BloodType = bloodType;
            Address = address;
            Height = height;
            Weight = weight;
        }

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

    }
}
