using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Dto.Payment;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Interfaces.Payment;
using Streetcode.BLL.Mapping.Payment;
using Streetcode.BLL.MediatR.Payment;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using Xunit;

public class CreateInvoiceHandlerTest
{
    private readonly IMapper mapper;
    private readonly Mock<IPaymentService> mockRepository;
    private readonly Mock<ILoggerService> mockLogger;

    public CreateInvoiceHandlerTest()
    {
        this.mockRepository = RepositoryMocker.GetPaymentMock();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<Streetcode.BLL.Mapping.Payment.PaymentProfile>();
        });

        this.mapper = mapperConfig.CreateMapper();

        this.mockLogger = new Mock<ILoggerService>();
    }

    [Fact]
    public async Task CreateI_InvoiceDTOIsNotNull_IsSuccessShouldBeTrue()
    {
        // Arrange
      
        var paymentDto = new PaymentDto
        {
            Amount = 100,
            RedirectUrl = "https://example.com"
        };

        var request = new CreateInvoiceCommand(paymentDto);
        var handler = new CreateInvoiceHandler(this.mockRepository.Object, this.mockLogger.Object);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }
}
