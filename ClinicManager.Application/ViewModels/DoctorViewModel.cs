using ClinicManager.Core.Entities;
using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.ViewModels
{
    public class DoctorViewModel
    {
        public DoctorViewModel(Doctor doctor)
        {
            FirstName = doctor.FirstName;
            LastName = doctor.LastName;
            DateOfBirth = doctor.DateOfBirth;
            PhoneNumber = doctor.PhoneNumber;
            Email = doctor.Email;
            Cpf = doctor.Cpf;
            BloodType = doctor.BloodType;
            Address = doctor.Address;
            Specialty = doctor.Specialty;
            Crm = doctor.Crm;
            Id = doctor.Id;
            CreatedAt = doctor.CreatedAt;
            
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

        public Guid Id { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}
