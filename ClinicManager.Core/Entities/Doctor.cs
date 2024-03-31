using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicManager.Core.Entities
{
    public class Doctor : BasePersonEntity
    {
        public Doctor()
        {

        }

        public Doctor(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string cpf, EBloodType bloodType, string address, string specialty, string crm) : base(firstName, lastName, dateOfBirth, phoneNumber, email, cpf, bloodType, address)
        {
            Specialty = specialty;
            Crm = new Crm();
        }

        public string Specialty { get; private set; }

        public Crm Crm { get; private set; }
    }
}
