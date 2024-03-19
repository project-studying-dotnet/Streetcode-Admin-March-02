<<<<<<< HEAD
﻿// <copyright file="GetArtByIdHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Art.GetById
{
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media.Images;
    using Streetcode.BLL.MediatR.Media.Art.GetById;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// TESTED SUCCESSFULLY
    /// BLL -> MediatR -> Media -> Art -> GetById.
    /// </summary>
    public class GetArtByIdHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetArtByIdHandlerTest"/> class.
        /// </summary>
        public GetArtByIdHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetArtRepositoryMock();
=======
﻿using AutoMapper;
using FluentAssertions;
using Moq;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Media.Images;
using Streetcode.BLL.MediatR.Media.Art.GetAll;
using Streetcode.BLL.MediatR.Media.Art.GetById;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.Media.Art.GetById
{
    //TESTED SUCCESSFULLY
    //BLL -> MediatR -> Media -> Art -> GetById
    public class GetArtByIdHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryWrapper> _mockRepository;
        private readonly Mock<ILoggerService> _mockLogger;

        public GetArtByIdHandlerTest()
        {
            _mockRepository = RepositoryMocker.GetArtRepositoryMock();
>>>>>>> f2bda5e06c2000983237b488a290114777f19fcc

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ArtProfile>();
            });

<<<<<<< HEAD
            this.mapper = mapperConfig.CreateMapper();

            this.mockLogger = new Mock<ILoggerService>();
        }

        /// <summary>
        /// Get by id not null test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdNotNullTest()
        {
            // Arrange
            var handler = new GetArtByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetArtByIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Get by id first item should be first item.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdFirstShouldBeFirstTest()
        {
            // Arrange
            var handler = new GetArtByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetArtByIdQuery(1), CancellationToken.None);

            // Assert
            result.Value.Description.Should().Be("First description");
        }

        /// <summary>
        /// Get by id second item description should not be fourth item description test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetByIdSecondShouldNotBeFourthTest()
        {
            // Arrange
            var handler = new GetArtByIdHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetArtByIdQuery(2), CancellationToken.None);

            // Assert
=======
            _mapper = mapperConfig.CreateMapper();

            _mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Get_By_Id_Not_Null_Test()
        {
            //Arrange
            var handler = new GetArtByIdHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetArtByIdQuery(1), CancellationToken.None);

            //Assert        
            result.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_By_Id_First_Should_Be_First_Test()
        {
            //Arrange
            var handler = new GetArtByIdHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetArtByIdQuery(1), CancellationToken.None);

            //Assert        
            result.Value.Description.Should().Be("First description");
        }

        [Fact]
        public async Task Get_By_Id_Second_Should_Not_Be_Fourth_Test()
        {
            //Arrange
            var handler = new GetArtByIdHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetArtByIdQuery(2), CancellationToken.None);

            //Assert        
>>>>>>> f2bda5e06c2000983237b488a290114777f19fcc
            result.Value.Description.Should().NotBe("Fourth description");
        }
    }
}
