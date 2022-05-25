using Alefba.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork(IExchangeRepository exchangeRepository)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(r=>r.ExchangeRepository).Returns(exchangeRepository);

            return mockUnitOfWork;
        }

     
    }
}
