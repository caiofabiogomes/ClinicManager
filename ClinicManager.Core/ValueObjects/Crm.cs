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
             
            if (crm.Length != 6 && !crm.All(char.IsDigit))
                return false;


            return true;
        }

       
    }
}
