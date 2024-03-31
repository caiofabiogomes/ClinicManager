using ClinicManager.Core.Enums;
using ClinicManager.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Core.Entities
{
    public class Patient : BasePersonEntity
    {
        public Patient()
        {
            
        }

        public Patient(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string cpf, EBloodType bloodType, string address, double height, double weight) : base(firstName, lastName, dateOfBirth, phoneNumber, email, cpf, bloodType, address)
        {
            Height = height;
            Weight = weight;
        }
         
        public double Height { get;  private set; }

        public double Weight { get; private set; }
    }
}
