﻿using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Domain.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Tests.Services.DriverService
{
    public class UpdateDriverServiceTests
    {
        private readonly Mock<IRepository<Driver>> _repository;
        private readonly Mock<IMapper> _mapper;

        public UpdateDriverServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Driver>>();
        }

        [Test]
        public async Task Update_Driver_Tests()
        {
            ulong driverId = 5;
            var driver = new Driver() { Address = "Restourant Forel" };
            var driverRequest = new UpdateDriverRequest() { Address = "Restaurant Orzu" };
            var driverResponse = new UpdateDriverResponse() { Address = "Restaurant Orzu" };

            _repository.Setup(p => p.FindAsync(driverId, CancellationToken.None));

            _mapper.Setup(m => m.Map<UpdateDriverRequest, Driver>(driverRequest)).Returns(driver);
            _mapper.Setup(m => m.Map<Driver, UpdateDriverResponse>(driver)).Returns(driverResponse);

            var service = new Application.Services.DriverService(_repository.Object, _mapper.Object);
            var entity = await service.Update(driverRequest, driverId, CancellationToken.None);

            _repository.Verify(m => m.FindAsync(driverId, CancellationToken.None));
            _repository.Verify(m => m.Update(It.IsAny<Driver>()));
            _repository.Verify(m => m.SaveChangesAsync(CancellationToken.None));

            var result = entity as UpdateDriverResponse;

            Assert.That(driverResponse.Address, Is.EqualTo(result.Address));
        }
    }
}