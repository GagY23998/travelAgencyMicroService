using AutoMapper;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BookingService.Application.Commands;
using TravelAgency.BookingService.Application.Queries;
using TravelAgency.BookingService.Domain.DTOs;
using TravelAgency.BookingService.Domain.Repositories;
using Xunit;

namespace UnitTesting.BookingService.Queries
{
    public class PaymentQueryTests
    {

        Mock<IPaymentRepository> mockRepository;
        Mock<IMediator> mockMediator;
        Mock<IMapper> mockMapper;
        public PaymentQueryTests()
        {
            mockRepository = new Mock<IPaymentRepository>();
            mockMediator = new Mock<IMediator>();
            mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetPaymentById_IfSuccess_ReturnPayment()
        {
            //Arrange
            mockRepository.Setup(_ => _.getPaymentById(It.IsAny<Guid>())).Returns(new PaymentDTO());
            var fakeQuery = new GetPaymentByIdQuery(It.IsAny<Guid>());
            mockMediator.Setup(_ => _.Send(fakeQuery, new CancellationToken())).Returns(Task.FromResult(new PaymentDTO()));

            //Act

            GetPaymentByIdQueryHandler fakeHandler = new GetPaymentByIdQueryHandler(mockMediator.Object, mockRepository.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());

            //Assert

            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetPayments_IfSuccess_ReturnPayment()
        {
            //Arrange
            IEnumerable<PaymentDTO> fakeList = new List<PaymentDTO>().AsEnumerable();
            mockRepository.Setup(_ => _.getPayment(It.IsAny<PaymentSearchRequest>())).Returns(fakeList);
            var fakeQuery = new GetPaymentsQuery(It.IsAny<PaymentSearchRequest>());
            mockMediator.Setup(_ => _.Send(fakeQuery, new CancellationToken())).Returns(Task.FromResult(fakeList));

            //Act

            GetPaymentsQueryHandler fakeHandler = new GetPaymentsQueryHandler(mockMediator.Object, mockRepository.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());

            //Assert

            Assert.NotNull(result);
        }
        [Fact]
        public async Task UpdatePayments_IfSuccess_ReturnPayment()
        {
            //Arrange
            mockRepository.Setup(_ => _.UpdatePayment(It.IsAny<Guid>(),It.IsAny<PaymentCreateRequest>())).Returns(new PaymentDTO());
            var fakeQuery = new UpdatePaymentCommand(It.IsAny<Guid>(),It.IsAny<PaymentCreateRequest>());
            mockMediator.Setup(_ => _.Send(fakeQuery, new CancellationToken())).Returns(Task.FromResult(new PaymentDTO()));

            //Act

            UpdatePaymentCommandHandler fakeHandler = new UpdatePaymentCommandHandler(mockMediator.Object, mockRepository.Object);
            var result = await fakeHandler.Handle(fakeQuery, new CancellationToken());

            //Assert

            Assert.NotNull(result);
        }
    }
}
