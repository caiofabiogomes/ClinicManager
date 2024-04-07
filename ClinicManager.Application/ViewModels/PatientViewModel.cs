using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.ViewModels
{
    public class PatientViewModel
    {
        public PatientViewModel(string firstName, string lastName, DateTime dateOfBirth, PhoneNumber phoneNumber, 
            Email email, Cpf cpf, EBloodType bloodType, Address address, double height, 
            double weight, Guid id, DateTime createdAt)
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
            Id = id;
            CreatedAt = createdAt;
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

        public Guid Id { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}
