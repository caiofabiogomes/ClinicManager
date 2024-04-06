using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Core.ValueObjects
{
    //Testar
    public sealed record Crm
    {
        public Crm()
        {
            
        }
        public Crm(string value)
        {
            if (!IsValid(value))
                throw new ArgumentException("CRM inválido.");

            Value = value;
        }

        public string Value { get; init; }

        public bool IsValid(string crm)
        {
            if (string.IsNullOrWhiteSpace(crm))
                return false;
             
            if (crm.Length < 7)
                return false;
             
            string[] parts = crm.Split('/');
            if (parts.Length != 2)
                return false;

            string numbersPart = parts[0];
            string statePart = parts[1];
             
            if (numbersPart.Length != 6 || !numbersPart.All(char.IsDigit))
                return false;
             
            if (!statePart.StartsWith("CRM"))
                return false;
             
            string state = statePart.Substring(3);  
            if (!state.All(char.IsLetter))
                return false; 


            return true;
        }

       
    }
}
