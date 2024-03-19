<<<<<<< HEAD
﻿// <copyright file="GetAllArtsHandlerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Media.Art.GetAll
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using Streetcode.BLL.DTO.Media.Art;
    using Streetcode.BLL.Interfaces.Logging;
    using Streetcode.BLL.Mapping.Media.Images;
    using Streetcode.BLL.MediatR.Media.Art.GetAll;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.XUnitTest.MediatRTests.Mocks;
    using Xunit;

    /// <summary>
    /// TESTED SUCCESSFULLY
    /// BLL -> MediatR -> Media -> Art -> GetAll.
    /// </summary>
    public class GetAllArtsHandlerTest
    {
        private readonly IMapper mapper;
        private readonly Mock<IRepositoryWrapper> mockRepository;
        private readonly Mock<ILoggerService> mockLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllArtsHandlerTest"/> class.
        /// </summary>
        public GetAllArtsHandlerTest()
        {
            this.mockRepository = RepositoryMocker.GetArtRepositoryMock();
=======
﻿using AutoMapper;
using FluentAssertions;
using Moq;
using Repositories.Interfaces;
using Streetcode.BLL.DTO.Media.Art;
using Streetcode.BLL.Interfaces.Logging;
using Streetcode.BLL.Mapping.Media.Images;
using Streetcode.BLL.MediatR.Media.Art.GetAll;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.XUnitTest.MediatRTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Streetcode.XUnitTest.MediatRTests.Media.Art.GetAll
{
    //TESTED SUCCESSFULLY
    //BLL -> MediatR -> Media -> Art -> GetAll
    public class GetAllArtsHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryWrapper> _mockRepository;
        private readonly Mock<ILoggerService> _mockLogger;

        public GetAllArtsHandlerTest()
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
        /// Get all not null or empty test.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllNotNullOrEmptyTest()
        {
            // Arrange
            var handler = new GetAllArtsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllArtsQuery(), CancellationToken.None);

            // Assert
            result.Value.Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Get all count should be four.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllCountShouldBeFour()
        {
            // Arrange
            var handler = new GetAllArtsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllArtsQuery(), CancellationToken.None);

            // Assert
            result.Value.Count().Should().Be(4);
        }

        /// <summary>
        /// Get all list should be type ArtDTO.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task GetAllShouldBeTypeListArtDTO()
        {
            // Arrange
            var handler = new GetAllArtsHandler(this.mockRepository.Object, this.mapper, this.mockLogger.Object);

            // Act
            var result = await handler.Handle(new GetAllArtsQuery(), CancellationToken.None);

            // Assert
=======
            _mapper = mapperConfig.CreateMapper();

            _mockLogger = new Mock<ILoggerService>();
        }

        [Fact]
        public async Task Get_All_Not_Null_Or_Empty_Test()
        {
            //Arrange
            var handler = new GetAllArtsHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetAllArtsQuery(), CancellationToken.None);

            //Assert        
            result.Value.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Get_All_Count_Should_Be_Four()
        {
            //Arrange
            var handler = new GetAllArtsHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetAllArtsQuery(), CancellationToken.None);

            //Assert        
            result.Value.Count().Should().Be(4);
        }

        [Fact]
        public async Task Get_All_Should_Be_Type_List_ArtDTO()
        {
            //Arrange
            var handler = new GetAllArtsHandler(_mockRepository.Object, _mapper, _mockLogger.Object);

            //Act
            var result = await handler.Handle(new GetAllArtsQuery(), CancellationToken.None);

            //Assert        
>>>>>>> f2bda5e06c2000983237b488a290114777f19fcc
            result.Value.Should().BeOfType<List<ArtDTO>>();
        }
    }
}
