using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Core.Entities
{
    public class ServiceNote : BaseEntity
    {
        public ServiceNote()
        {
            
        }

        public ServiceNote(string name, string description, decimal value, int durationTime)
        {
            Name = name;
            Description = description;
            Value = value;
            DurationTime = durationTime;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Value { get; private set; }

        public int DurationTime { get; private set; }

    }
}
