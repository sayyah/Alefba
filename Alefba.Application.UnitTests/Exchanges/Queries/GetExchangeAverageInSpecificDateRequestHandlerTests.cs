using Alefba.Application.Handlers;
using Alefba.Application.Interfaces;
using Alefba.Application.Profiles;
using Alefba.Application.Queries;
using Alefba.Application.UnitTests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Alefba.Application.UnitTests.Exchanges.Queries
{
    public class GetExchangeAverageInSpecificDateRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IExchangeRepository> _mockRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly GetExchangeAverageInSpecificDateRequestHandler handler;
        public GetExchangeAverageInSpecificDateRequestHandlerTests()
        {
            //arrange
            _mockRepository = MockExchangeRepository.GetExchangeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _unitOfWork =  MockUnitOfWork.GetUnitOfWork(_mockRepository.Object);

            handler = new GetExchangeAverageInSpecificDateRequestHandler(_mapper, _unitOfWork.Object);
        }

        [Fact]
        public async Task GetExchangeAverageInSpecificDateRequestHandler_should_retuen_average()
        {
            //arrange
            double expect = 252500;

            //act
            var result = await handler.Handle(new GetExchangeAverageInSpecificDateRequest(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(+1)), CancellationToken.None);

            //assert
            result.ShouldBe(expect);
        }
    }
}
