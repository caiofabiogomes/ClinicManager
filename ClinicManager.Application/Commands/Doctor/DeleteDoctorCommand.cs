using ClinicManager.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.Doctor
{
    public class DeleteDoctorCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; private set; }

        public DeleteDoctorCommand(Guid id)
        {
            Id = id;
        }
    }
}
