using AutoMapper;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Application.Response.SenderResponse;
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
    public class GetByIdDriverServiceTests
    {
        private readonly Mock<IRepository<Driver>> _repository;
        private readonly Mock<IMapper> _mapper;

        public GetByIdDriverServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IRepository<Driver>>();
        }

        [Test]
        public async Task GetById_Driver_Tests()
        {
            ulong driverId = 1;
            var driver = new Driver() { Address = "Ulitsa A.Samadov, Dom 24", FirstName = "Alijon" };
            var driverResponse = new GetDriverResponse() { Address = "Ulitsa A.Samadov, Dom 24", FirstName = "Alijon" };

            _repository.Setup(d => d.FindAsync(driverId, CancellationToken.None)).ReturnsAsync(driver);
            _mapper.Setup(m=>m.Map<Driver, DriverResponse>(driver)).Returns(driverResponse);

            var service = new Application.Services.DriverService(_repository.Object, _mapper.Object);
            var entity = await service.Get(driverId, CancellationToken.None);

            _repository.Verify(d => d.FindAsync(driverId, CancellationToken.None));
            var result = entity as GetDriverResponse;
            Assert.That("Alijon", Is.EqualTo(result.FirstName));
        }




    }
}
