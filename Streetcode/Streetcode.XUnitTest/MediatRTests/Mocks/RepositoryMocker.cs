// <copyright file="RepositoryMocker.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore.Query;
    using Moq;
    using Streetcode.DAL.Entities.Media;
    using Streetcode.DAL.Entities.Media.Images;
    using Streetcode.DAL.Repositories.Interfaces.Base;

    /// <summary>
    /// Repository mocker.
    /// </summary>
    internal class RepositoryMocker
    {
        /// <summary>
        /// Mocks art repository.
        /// </summary>
        /// <returns>Returns mocked repository. </returns>
        public static Mock<IRepositoryWrapper> GetArtRepositoryMock()
        {
            var arts = new List<Art>()
            {
                new Art { Id = 1, Description = "First description", Title = "First title", ImageId = 1, Image = null },
                new Art { Id = 2, Description = "Second description", Title = "Second title", ImageId = 2, Image = null },
                new Art { Id = 3, Description = "Third description", Title = "First third", ImageId = 3, Image = null },
                new Art { Id = 4, Description = "Fourth description", Title = "Fourth title", ImageId = 4, Image = null },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.ArtRepository.GetAllAsync(It.IsAny<Expression<Func<Art, bool>>>(), It.IsAny<Func<IQueryable<Art>, IIncludableQueryable<Art, object>>>()))
                .ReturnsAsync(arts);

            mockRepo.Setup(x => x.ArtRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Art, bool>>>(), It.IsAny<Func<IQueryable<Art>, IIncludableQueryable<Art, object>>>()))
                .ReturnsAsync((Expression<Func<Art, bool>> predicate, Func<IQueryable<Art>, IIncludableQueryable<Art, object>> include) =>
                {
                    return arts.FirstOrDefault(predicate.Compile());
                });

            return mockRepo;
        }

        /// <summary>
        /// Mocks audio repository.
        /// </summary>
        /// <returns>Returns mocked repository. </returns>
        public static Mock<IRepositoryWrapper> GetAudiosRepositoryMock()
        {
            var audios = new List<Audio>()
            {
               new Audio { Id = 1, Title = "First audio", BlobName = "First blob name", MimeType = "First mime type", Base64 = "First base 64", Streetcode = null },
               new Audio { Id = 2, Title = "Second audio", BlobName = "Second blob name", MimeType = "Second mime type", Base64 = "Second base 64", Streetcode = null },
               new Audio { Id = 3, Title = "Third audio", BlobName = "Third blob name", MimeType = "Third mime type", Base64 = "Third base 64", Streetcode = null },
               new Audio { Id = 4, Title = "Fourth audio", BlobName = "Fourth blob name", MimeType = "Fourth mime type", Base64 = "Fourth base 64", Streetcode = null },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.AudioRepository.GetAllAsync(It.IsAny<Expression<Func<Audio, bool>>>(), It.IsAny<Func<IQueryable<Audio>, IIncludableQueryable<Audio, object>>>()))
                .ReturnsAsync(audios);

            mockRepo.Setup(x => x.AudioRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Audio, bool>>>(), It.IsAny<Func<IQueryable<Audio>, IIncludableQueryable<Audio, object>>>()))
                .ReturnsAsync((Expression<Func<Audio, bool>> predicate, Func<IQueryable<Audio>, IIncludableQueryable<Audio, object>> include) =>
                {
                    return audios.FirstOrDefault(predicate.Compile());
                });

            return mockRepo;
        }

        /// <summary>
        /// Mocks video repository.
        /// </summary>
        /// <returns>Returns mocked repository. </returns>
        public static Mock<IRepositoryWrapper> GetVideosRepositoryMock()
        {
            var videos = new List<Video>()
            {
              new Video{ Id = 1, Title = "First video title", Description = "First video description", Url = "www.first.com", StreetcodeId = 1, Streetcode = null },
              new Video{ Id = 2, Title = "Second video title", Description = "Second video description", Url = "www.second.com", StreetcodeId = 2, Streetcode = null },
              new Video{ Id = 3, Title = "Third video title", Description = "Third video description", Url = "www.third.com", StreetcodeId = 3, Streetcode = null },
              new Video{ Id = 4, Title = "Fourth video title", Description = "Fourth video description", Url = "www.fourth.com", StreetcodeId = 4, Streetcode = null },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.VideoRepository.GetAllAsync(It.IsAny<Expression<Func<Video, bool>>>(), It.IsAny<Func<IQueryable<Video>, IIncludableQueryable<Video, object>>>()))
                .ReturnsAsync(videos);

            mockRepo.Setup(x => x.VideoRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Video, bool>>>(), It.IsAny<Func<IQueryable<Video>, IIncludableQueryable<Video, object>>>()))
                .ReturnsAsync((Expression<Func<Video, bool>> predicate, Func<IQueryable<Video>, IIncludableQueryable<Video, object>> include) =>
                {
                    return videos.FirstOrDefault(predicate.Compile());
                });

            return mockRepo;
        }

        /// <summary>
        /// Mocks image repository.
        /// </summary>
        /// <returns>Returns mocked repository. </returns>
        public static Mock<IRepositoryWrapper> GetImagesRepositoryMock()
        {
            var images = new List<Image>()
            {
            new Image
            {
                Id = 1,
                Base64 = "First base 64",
                BlobName = "First image blob name",
                MimeType = "First image mime type",
                ImageDetails = new ImageDetails() { Id = 1, ImageId = 1, Title = "First image info title", Alt = "First image info alt"},
            },
            new Image
            {
                Id = 2,
                Base64 = "Second base 64",
                BlobName = "Second image blob name",
                MimeType = "Second image mime type",
                ImageDetails = new ImageDetails() { Id = 2, ImageId = 2, Title = "Second image info title", Alt = "Second image info alt"},
            },
            new Image
            {
                Id = 3,
                Base64 = "Third base 64",
                BlobName = "Third image blob name",
                MimeType = "Third image mime type",
                ImageDetails = new ImageDetails() { Id = 3, ImageId = 3, Title = "Third image info title", Alt = "Third image info alt"},
            },
            new Image
            {
                Id = 4,
                Base64 = "Fourth base 64",
                BlobName = "Fourth image blob name",
                MimeType = "Fourth image mime type",
                ImageDetails = new ImageDetails() { Id = 4, ImageId = 4, Title = "Fourth image info title", Alt = "Fourth image info alt"},
            },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.ImageRepository.GetAllAsync(It.IsAny<Expression<Func<Image, bool>>>(), It.IsAny<Func<IQueryable<Image>, IIncludableQueryable<Image, object>>>()))
                .ReturnsAsync(images);

            mockRepo.Setup(x => x.ImageRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Image, bool>>>(), It.IsAny<Func<IQueryable<Image>, IIncludableQueryable<Image, object>>>()))
                .ReturnsAsync((Expression<Func<Image, bool>> predicate, Func<IQueryable<Image>, IIncludableQueryable<Image, object>> include) =>
                {
                    return images.FirstOrDefault(predicate.Compile());
                });

            return mockRepo;
        }
    }
}
