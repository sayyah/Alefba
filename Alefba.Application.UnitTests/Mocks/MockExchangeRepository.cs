using Alefba.Application.Interfaces;
using Alefba.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Application.UnitTests.Mocks
{
    public static class MockExchangeRepository
    {
        public static Mock<IExchangeRepository> GetExchangeRepository()
        {
            var exchanges = new List<Exchange>
            {
                new Exchange(255000,"USD"),
                new Exchange(250000,"USD")
            };


            var mockRepository = new Mock<IExchangeRepository>();

            mockRepository.Setup(r =>  r.GetAverageInSpecificDate(It.IsAny<Exchange>().DateTime, It.IsAny<Exchange>().DateTime))
                .ReturnsAsync(exchanges.Average(x => x.Rate));

            mockRepository.Setup(r => r.Add(It.IsAny<Exchange>(), CancellationToken.None)).Returns((Exchange exchange) =>
            {
                exchanges.Add(exchange);
                return exchange.Id;
            });

            return mockRepository;
        }
    }
}
