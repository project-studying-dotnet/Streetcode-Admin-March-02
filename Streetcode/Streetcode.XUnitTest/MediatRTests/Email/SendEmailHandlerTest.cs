using System;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Dto.Email;
using Streetcode.BLL.Interfaces.Email;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.MediatR.Email;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using Xunit;

public class SendEmailHandlerTest
{
    private readonly IMapper mapper;
    private readonly Mock<IEmailService> mockRepository;
    private readonly Mock<ILoggerService> mockLogger;

    public SendEmailHandlerTest()
    {
        this.mockRepository = RepositoryMocker.GetEmailMock(true);

        this.mockLogger = new Mock<ILoggerService>();
    }

    [Fact]
    public async Task Handle_SendEmail_Success()
    {
        // Arrange
        var handler = new SendEmailHandler(this.mockRepository.Object, this.mockLogger.Object);
        var emailDto = new EmailDto
        {
            From = "sender@example.com",
            Content = "Test content"
        };
        var sendEmailCommand = new SendEmailCommand(emailDto);

        // Setup mock behavior
        this.mockRepository.Setup(x => x.SendEmailAsync(It.IsAny<Streetcode.DAL.Entities.AdditionalContent.Email.Message>())).ReturnsAsync(true);

        // Act
        var result = await handler.Handle(sendEmailCommand, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_SendEmail_Failed ()
    {
        // Arrange
        var handler = new SendEmailHandler(this.mockRepository.Object, this.mockLogger.Object);
        var emailDto = new EmailDto
        {
            From = "sender@example.com",
            Content = "Test content"
        };
        var sendEmailCommand = new SendEmailCommand(emailDto);

        // Setup mock behavior
        this.mockRepository.Setup(x => x.SendEmailAsync(It.IsAny<Streetcode.DAL.Entities.AdditionalContent.Email.Message>())).ReturnsAsync(false);

        // Act
        var result = await handler.Handle(sendEmailCommand, CancellationToken.None);

        // Assert
        result.IsFailed.Should().BeTrue();
    }
}