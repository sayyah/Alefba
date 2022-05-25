using Alefba.Application.Commands;
using Alefba.Application.Handlers;
using Alefba.Application.Interfaces;
using Alefba.Application.Profiles;
using Alefba.Application.Queries;
using Alefba.Application.UnitTests.Mocks;
using Alefba.Domain.Entities;
using AutoMapper;
using Shouldly;

namespace Alefba.Application.UnitTests.Exchanges.Queries
{
    public class GetExchangeAverageInSpecificDateRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IExchangeRepository _mockRepository;
        private readonly IUnitOfWork _mockUnitOfWork;
        private readonly GetExchangeAverageInSpecificDateRequestHandler handlerAverage;
        private readonly CreateExchangeRequestHandler handlerCreate;

        public GetExchangeAverageInSpecificDateRequestHandlerTests()
        {
            //arrange
            _mockRepository = new MockExchangeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _mockUnitOfWork = new MockUnitOfWork(_mockRepository);

            handlerAverage = new GetExchangeAverageInSpecificDateRequestHandler(_mapper, _mockUnitOfWork);
            handlerCreate = new CreateExchangeRequestHandler(_mapper, _mockUnitOfWork);
        }

        [Fact]
        public async Task GetExchangeAverageInSpecificDateRequestHandler_should_returen_average()
        {
            //arrange
            double expect = 252500;
            var command = new GetExchangeAverageInSpecificDateRequest(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(+1));
            
            //act
            var actual = await handlerAverage.Handle(command, CancellationToken.None);

            //assert
            actual.ShouldBe(expect);
        }

        [Fact]
        public async Task Add_should_returen_Guid()
        {
            //arrange
            var createExchangeCommand = new CreateExchangeCommand(260000, "USD");

            //act
            var actual = await handlerCreate.Handle(createExchangeCommand, CancellationToken.None);

            //assert
            Assert.IsType<Guid>(actual);
        }
    }
}
