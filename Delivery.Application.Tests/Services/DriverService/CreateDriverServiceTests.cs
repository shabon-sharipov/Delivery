using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Requests.SenderRequest;
using Delivery.Application.Validations.SenderValidations;
using Delivery.Domain.Model;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Tests.Services.DriverService
{
    public class CreateDriverServiceTests
    {
        private readonly Mock<IRepository<Driver>> _repository;
        private readonly Mock<IMapper> _mapper;
        private CreateDriverValidation _validator;

        public CreateDriverServiceTests()
        {
            _validator = new CreateDriverValidation();
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Driver>>();
        }

        [Test]
        public async Task Create_Driver_Tests()
        {
            var driverRequest = new CreateDriverRequest()
            {
                Address = "Restourant Forel",
                PhoneNumber = "+9924454445",
                FirstName = "Ali",
                LastName = "Vali"
            };

            var driver = new Driver()
            {
                Address = "Restourant Forel",
                PhoneNumber = "+9924454445",
                FirstName = "Ali",
                LastName = "Vali"
            };

            var driverResponse = new CreateDriverResponse()
            {
                FirstName = "Ali",
                LastName = "Vali"
            };
            _mapper.Setup(d => d.Map<CreateDriverRequest, Driver>(driverRequest)).Returns(driver);
            _mapper.Setup(d => d.Map<Driver, CreateDriverResponse>(driver)).Returns(driverResponse);

            var service = new Application.Services.DriverService(_repository.Object, _mapper.Object);
            var result = await service.Create(driverRequest, CancellationToken.None);

            _repository.Verify(a => a.AddAsync(It.IsAny<Driver>(), CancellationToken.None));
            _repository.Verify(a => a.SaveChangesAsync(CancellationToken.None));

            var entity = result as CreateDriverResponse;
            Assert.That(entity.FirstName, Is.EqualTo(driver.FirstName));
        }

        [Test]
        public void Should_have_error_when_Driver_FirstName_is_Empty()
        {
            var driver = new CreateDriverRequest() { FirstName = "" };
            var result = _validator.TestValidate(driver);
            result.ShouldHaveValidationErrorFor(d => d.FirstName);
        }
        
        [Test]
        public void should_have_error_when_Driver_FirstName_is_Null()
        {
            var driver = new CreateDriverRequest() { FirstName = null };
            var result = _validator.TestValidate(driver);
            result.ShouldHaveValidationErrorFor(d => d.FirstName); 
        }

        [Test]
        public void Shuold_have_error_when_Driver_Address_is_empty()
        {
            var driver = new CreateDriverRequest() { Address = "" };
            var result = _validator.TestValidate(driver);
            result.ShouldHaveValidationErrorFor(d => d.Address);
        }
        [Test]
        public void Should_have_error_when_Driver_Address_is_null()
        {
            var driver = new CreateDriverRequest() { Address = null };
            var result = _validator.TestValidate(driver);
            result.ShouldHaveValidationErrorFor(d => d.Address);
        }

        [Test]
        public void Should_have_error_when_Driver_LastName_is_Null()
        {
            var driver = new CreateDriverRequest() { LastName = null };
            var result = _validator.TestValidate(driver);
            result.ShouldHaveValidationErrorFor(d=>d.LastName);
        }

        [Test]
        public void Should_have_error_when_Driver_DateOfBirth_is_empty()
        {
            var driver = new CreateDriverRequest() { DataOfBirth = DateTime.Parse("2002-10-13T08:18:36.903Z") };
            var result = _validator.TestValidate(driver);
            result.ShouldNotHaveValidationErrorFor(d => d.DataOfBirth);
        }

        [Test]
        public void Should_have_error_when_Driver_PhoneNumber_is_empty()
        {
            var driver = new CreateDriverRequest() { PhoneNumber = "" };
            var result = _validator.TestValidate(driver);
            result.ShouldHaveValidationErrorFor(d => d.PhoneNumber);
        }

        [Test]
        public void Should_have_error_when_Driver_PhoneNumber_is_Null()
        {
            var driver = new CreateDriverRequest() { PhoneNumber = null };
            var result = _validator.TestValidate(driver);
            result.ShouldHaveValidationErrorFor(d => d.PhoneNumber);
        }
    }
}
