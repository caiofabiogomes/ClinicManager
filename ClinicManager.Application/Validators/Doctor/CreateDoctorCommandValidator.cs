using ClinicManager.Application.Commands.Doctor;
using FluentValidation;

namespace ClinicManager.Application.Validators.Doctor
{
    public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required");

            RuleFor(x => x.Email.Value)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");

            RuleFor(x => x.Cpf.Value)
                .NotEmpty().WithMessage("CPF is required")
                .Must(BeValidCpf).WithMessage("Invalid CPF");

            RuleFor(x => x.BloodType)
                .NotEmpty().WithMessage("Blood type is required");

            RuleFor(x => x.Specialty)
                .NotEmpty().WithMessage("Specialty is required");

            RuleFor(x => x.Crm.Value)
                .NotEmpty().WithMessage("CRM is required");

            RuleFor(x => x.Address.City)
                .NotEmpty().WithMessage("City is required");

            RuleFor(x => x.Address.HouseNumber)
                .NotEmpty().WithMessage("HouseNumber is required");

            RuleFor(x => x.Address.State)
                .NotEmpty().WithMessage("State is required");

            RuleFor(x => x.Address.Street)
                .NotEmpty().WithMessage("Street is required");

            RuleFor(x => x.Address.ZipCode)
                .NotEmpty().Must(BeValidZipCode).WithMessage("Invalid ZipCode");

        }

        private bool BeValidCpf(string cpf)
        {
            var cpfFormatted = cpf.Replace(".", "").Replace("-", "");

            bool isNumeric = cpfFormatted.All(char.IsDigit);

            return isNumeric && cpfFormatted.Length == 11;
        }

        private bool BeValidZipCode(string zipCode)
        {
            var zipCodeFormatted = zipCode.Replace("-", "");

            bool isNumeric = zipCodeFormatted.All(char.IsDigit);

            return isNumeric && zipCodeFormatted.Length == 8;
        }


    }
}
