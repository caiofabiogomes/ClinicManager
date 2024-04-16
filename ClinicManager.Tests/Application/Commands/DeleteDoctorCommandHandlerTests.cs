using AutoMapper;
using ClinicManager.Application.Commands.Doctor;
using ClinicManager.Application.ViewModels;
using ClinicManager.Core.Entities;
using ClinicManager.Core.Enums;
using ClinicManager.Core.IRepositories;
using ClinicManager.Core.ValueObjects;
using ClinicManager.Infrastructure.Persistence;
using Moq;

namespace ClinicManager.Tests.Application.Commands
{
    public class DeleteDoctorCommandHandlerTests
    {
        private readonly IMapper _mapper;

        public DeleteDoctorCommandHandlerTests()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DoctorViewModel, Doctor>();
                cfg.CreateMap<Doctor, DoctorViewModel>();
            });

            _mapper = new Mapper(configuration);
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldDeleteDoctorSuccessfully()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>(); 
            var mockDoctorRepository = new Mock<IDoctorRepository>();
              
            var guid = new Guid("12345678-1234-1234-1234-123456789012");

            var doctorViewModel = new DoctorViewModel("John", "Doe", new DateTime(1980, 1, 1),
                new PhoneNumber("31993087574"), new Email("john.doe@example.com"), new Cpf("12345678901"),
                EBloodType.APositive, new Address("123 Street", "City", "State", "12345-234", "11", null),
                "Cardiology", new Crm("12345"), guid, DateTime.Now
                );
             
            var doctor = _mapper.Map<Doctor>(doctorViewModel);

            mockDoctorRepository.Setup(d => d.GetByIdAsync(guid)).ReturnsAsync(doctor);

            mockUnitOfWork.Setup(u => u.Doctors).Returns(mockDoctorRepository.Object); 

            var deleteDoctorCommand = new DeleteDoctorCommand(guid);

            var handler = new DeleteDoctorCommandHandler(mockUnitOfWork.Object);

            var result = await handler.Handle(deleteDoctorCommand, CancellationToken.None);

            Assert.True(result.IsSuccess);
            Assert.Equal(guid, result.Data);
        }

        [Fact]
        public async Task Handle_inValidCommand_ShouldntDeleteDoctorSuccessfully()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockDoctorRepository = new Mock<IDoctorRepository>();

            var guidToSend = new Guid("12345678-1234-1234-1234-123456789012");
            var guidExpected = new Guid("12345678-1234-1234-1234-123456789016");

            var doctorViewModel = new DoctorViewModel("John", "Doe", new DateTime(1980, 1, 1),
                new PhoneNumber("31993087574"), new Email("john.doe@example.com"), new Cpf("12345678901"),
                EBloodType.APositive, new Address("123 Street", "City", "State", "12345-234", "11", null),
                "Cardiology", new Crm("12345"), guidExpected, DateTime.Now
                );

            var doctor = _mapper.Map<Doctor>(doctorViewModel);

            mockDoctorRepository.Setup(d => d.GetByIdAsync(guidExpected)).ReturnsAsync(doctor);

            mockUnitOfWork.Setup(u => u.Doctors).Returns(mockDoctorRepository.Object);

            var deleteDoctorCommand = new DeleteDoctorCommand(guidToSend);

            var handler = new DeleteDoctorCommandHandler(mockUnitOfWork.Object);

            var result = await handler.Handle(deleteDoctorCommand, CancellationToken.None);

            Assert.False(result.IsSuccess);
            Assert.False(result.IsFound);
            Assert.Equal(Guid.Empty, result.Data);
        }
    }
}
