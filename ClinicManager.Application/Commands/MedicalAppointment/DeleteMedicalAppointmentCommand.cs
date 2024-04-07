using ClinicManager.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.MedicalAppointment
{
    public class DeleteMedicalAppointmentCommand : IRequest<Result<Guid>>
    {
        public DeleteMedicalAppointmentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
