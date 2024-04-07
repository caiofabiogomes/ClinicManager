using ClinicManager.Application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Application.Commands.Patient
{
    public class DeletePatientCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; private set; }

        public DeletePatientCommand(Guid id)
        {
            Id = id;
        }
    }
}
