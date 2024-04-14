﻿using ClinicManager.Application.Abstractions;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Enums;
using MediatR;

namespace ClinicManager.Application.Commands.MedicalAppointment
{
    public class UpdateMedicalAppointmentCommand : IRequest<Result<MedicalAppointmentViewModel>>
    {
        public UpdateMedicalAppointmentCommand(Guid id, Guid patientId, Guid doctorId, Guid serviceNoteId, string medicalInsurance, DateTime startDate, DateTime endDate, EMedicalAppointmentType medicalAppointmentType)
        {
            Id = id;
            PatientId = patientId;
            DoctorId = doctorId;
            ServiceNoteId = serviceNoteId;
            MedicalInsurance = medicalInsurance;
            StartDate = startDate;
            EndDate = endDate;
            MedicalAppointmentType = medicalAppointmentType;
        }

        public Guid Id { get; private set; }

        public Guid PatientId { get; private set; } 

        public Guid DoctorId { get; private set; } 

        public Guid ServiceNoteId { get; private set; } 

        public string MedicalInsurance { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public EMedicalAppointmentType MedicalAppointmentType { get; private set; }
    }
}
