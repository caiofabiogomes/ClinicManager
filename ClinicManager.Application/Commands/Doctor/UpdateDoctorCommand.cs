using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;
using MediatR;

namespace ClinicManager.Application.Commands.Doctor
{
    public class UpdateDoctorCommand : IRequest<Result<DoctorViewModel>>
    {
        public UpdateDoctorCommand(Guid id, string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, Cpf cpf, EBloodType bloodType, Address address, string speciality, Crm crm)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Cpf = cpf;
            BloodType = bloodType;
            Address = address;
            Specialty = speciality;
            Crm = crm;
        }

        public Guid Id { get; private set; }

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
