namespace Streetcode.XUnitTest.MediatRTests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Query;
    using Moq;
    using Repositories.Interfaces;
    using Streetcode.BLL.DTO.Media.Art;
    using Streetcode.DAL.Entities.AdditionalContent;
    using Streetcode.DAL.Entities.AdditionalContent.Coordinates;
    using Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types;
    using Streetcode.DAL.Entities.Analytics;
    using Streetcode.DAL.Entities.Media;
    using Streetcode.DAL.Entities.Media.Images;
    using Streetcode.DAL.Entities.Streetcode;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.DAL.Repositories.Realizations.Base;
    using static System.Net.Mime.MediaTypeNames;

    internal class RepositoryMocker
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

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

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetCoordinateRepositoryMock()
        {
            var coordinate = new StreetcodeCoordinate()
            {
                Id = 1,
                StreetcodeId = 1,
            };

            List<StreetcodeCoordinate> coordinates = new List<StreetcodeCoordinate>
            {
                new StreetcodeCoordinate
                {
                    Id = 1,
                    StreetcodeId = 1,
                },
                new StreetcodeCoordinate
                {
                    Id = 2,
                    StreetcodeId = 1,
                },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.StreetcodeCoordinateRepository.Create(It.IsAny<StreetcodeCoordinate>()))
                .Returns(coordinate);

            mockRepo.Setup(x => x.StreetcodeCoordinateRepository.GetFirstOrDefaultAsync(
                It.IsAny<Expression<Func<StreetcodeCoordinate, bool>>>(),
                It.IsAny<Func<IQueryable<StreetcodeCoordinate>, IIncludableQueryable<StreetcodeCoordinate, object>>>()))
                .ReturnsAsync((Expression<Func<StreetcodeCoordinate, bool>> predicate, Func<IQueryable<StreetcodeCoordinate>,
                IIncludableQueryable<StreetcodeCoordinate, object>> include) =>
                {
                    return coordinates.FirstOrDefault(predicate.Compile());
                });

            mockRepo.Setup(x => x.StreetcodeCoordinateRepository.GetAllAsync(
                It.IsAny<Expression<Func<StreetcodeCoordinate, bool>>>(),
                It.IsAny<Func<IQueryable<StreetcodeCoordinate>, IIncludableQueryable<StreetcodeCoordinate, object>>>()))
                .ReturnsAsync(coordinates);

            mockRepo.Setup(repo => repo.StreetcodeCoordinateRepository.Update(It.IsAny<StreetcodeCoordinate>()));

            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetSubtitleRepositoryMock()
        {
            var mockRepo = new Mock<IRepositoryWrapper>();

            var subtitles = new List<Subtitle>()
            {
                new Subtitle
                {
                    StreetcodeId = 1,
                    Id = 1,
                    SubtitleText = "Test",
                },
                new Subtitle
                {
                    StreetcodeId = 1,
                    Id = 2,
                    SubtitleText = "Test",
                },
                new Subtitle
                {
                    StreetcodeId = 1,
                    Id = 3,
                    SubtitleText = "Test",
                },
            };

            mockRepo.Setup(x => x.SubtitleRepository.GetAllAsync(
                It.IsAny<Expression<Func<Subtitle, bool>>>(),
                It.IsAny<Func<IQueryable<Subtitle>, IIncludableQueryable<Subtitle, object>>>()))
                .ReturnsAsync(subtitles);

            mockRepo.Setup(x => x.SubtitleRepository.GetFirstOrDefaultAsync(
                It.IsAny<Expression<Func<Subtitle, bool>>>(),
                It.IsAny<Func<IQueryable<Subtitle>, IIncludableQueryable<Subtitle, object>>>()))
                .ReturnsAsync((Expression<Func<Subtitle, bool>> predicate,
                Func<IQueryable<Subtitle>,
                IIncludableQueryable<Subtitle, object>> include) =>
                {
                    return subtitles.FirstOrDefault(predicate.Compile());
                });

            return mockRepo;
        }
    }
}
