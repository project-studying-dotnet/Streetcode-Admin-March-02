// <copyright file="RepositoryMocker.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Streetcode.XUnitTest.MediatRTests.Mocks
{
    using Microsoft.EntityFrameworkCore.Query;
    using Moq;
    using Repositories.Interfaces;
    using Streetcode.BLL.DTO.Media.Art;
    using Streetcode.DAL.Entities.Media.Images;
    using Streetcode.BLL.Interfaces.Email;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.DAL.Repositories.Realizations.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using Streetcode.BLL.Interfaces.Logging;
    using Microsoft.Extensions.Hosting;
    using Streetcode.BLL.Interfaces.Instagram;
    using Streetcode.BLL.Services.Payment;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Localization;
    using Moq.Protected;
    using Streetcode.BLL.DTO.Timeline;
    using Streetcode.DAL.Entities.Timeline;
    using Streetcode.DAL.Enums;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore.Query;
    using Moq;
    using Streetcode.DAL.Entities.Media;
    using Streetcode.DAL.Entities.Media.Images;
    using Streetcode.DAL.Entities.Streetcode;
    using Streetcode.DAL.Entities.Toponyms;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Streetcode.DAL.Entities.Team;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            },
            new Image
            {
                Id = 2,
                Base64 = "Second base 64",
                BlobName = "Second image blob name",
                MimeType = "Second image mime type",
            },
            new Image
            {
                Id = 3,
                Base64 = "Third base 64",
                BlobName = "Third image blob name",
                MimeType = "Third image mime type",
            },
            new Image
            {
                Id = 4,
                Base64 = "Fourth base 64",
                BlobName = "Fourth image blob name",
                MimeType = "Fourth image mime type",
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

        /// <summary>
        /// Mocks streetcode repository.
        /// </summary>
        /// <returns>Returns mocked repository. </returns>
        public static Mock<IRepositoryWrapper> GetStreetcodeRepositoryMock()
        {
            var streetCodes = new List<StreetcodeContent>
            {
                new StreetcodeContent() { Id = 1, Title = "First streetcode content title" },
                new StreetcodeContent() { Id = 2, Title = "Second streetcode content title" },
                new StreetcodeContent() { Id = 3, Title = "Third streetcode content title" },
                new StreetcodeContent() { Id = 4, Title = "Fourth streetcode content title" },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.StreetcodeRepository.GetAllAsync(It.IsAny<Expression<Func<StreetcodeContent, bool>>>(), It.IsAny<Func<IQueryable<StreetcodeContent>, IIncludableQueryable<StreetcodeContent, object>>>()))
                .ReturnsAsync(streetCodes);

            mockRepo.Setup(x => x.StreetcodeRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<StreetcodeContent, bool>>>(), It.IsAny<Func<IQueryable<StreetcodeContent>, IIncludableQueryable<StreetcodeContent, object>>>()))
                .ReturnsAsync((Expression<Func<StreetcodeContent, bool>> predicate, Func<IQueryable<StreetcodeContent>, IIncludableQueryable<StreetcodeContent, object>> include) =>
                {
                    return streetCodes.FirstOrDefault(predicate.Compile());
                });

            return mockRepo;
        }

        /// <summary>
        /// Mocks streetcode art repository.
        /// </summary>
        /// <returns>Returns mocked repository. </returns>
        public static Mock<IRepositoryWrapper> GetStreetcodeArtRepositoryMock()
        {
            var streetcodeArts = new List<StreetcodeArt>
            {
                new StreetcodeArt() { Index = 1, StreetcodeId = 1, ArtId = 1 },
                new StreetcodeArt() { Index = 2, StreetcodeId = 2, ArtId = 2 },
                new StreetcodeArt() { Index = 3, StreetcodeId = 3, ArtId = 3 },
                new StreetcodeArt() { Index = 4, StreetcodeId = 4, ArtId = 4 },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.StreetcodeArtRepository.GetAllAsync(It.IsAny<Expression<Func<StreetcodeArt, bool>>>(), It.IsAny<Func<IQueryable<StreetcodeArt>, IIncludableQueryable<StreetcodeArt, object>>>()))
                .ReturnsAsync(streetcodeArts);

            mockRepo.Setup(x => x.StreetcodeArtRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<StreetcodeArt, bool>>>(), It.IsAny<Func<IQueryable<StreetcodeArt>, IIncludableQueryable<StreetcodeArt, object>>>()))
                .ReturnsAsync((Expression<Func<StreetcodeArt, bool>> predicate, Func<IQueryable<StreetcodeArt>, IIncludableQueryable<StreetcodeArt, object>> include) =>
                {
                    return streetcodeArts.FirstOrDefault(predicate.Compile());
                });

            return mockRepo;
        }

        /// <summary>
        /// Mocks toponyms repository.
        /// </summary>
        /// <returns>Returns mocked repository. </returns>
        public static Mock<IRepositoryWrapper> GetToponymsRepositoryMock()
        {
            var toponyms = new List<Toponym>
            {
               new Toponym() { Id = 1, Oblast = "First", StreetName = "First streetname" },
               new Toponym() { Id = 2, Oblast = "Second", StreetName = "Second streetname" },
               new Toponym() { Id = 3, Oblast = "Third", StreetName = "Third streetname" },
               new Toponym() { Id = 4, Oblast = "Fourth", StreetName = "Fourth streetname" },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.ToponymRepository.GetAllAsync(It.IsAny<Expression<Func<Toponym, bool>>>(), It.IsAny<Func<IQueryable<Toponym>, IIncludableQueryable<Toponym, object>>>()))
                .ReturnsAsync(toponyms);

            mockRepo.Setup(x => x.ToponymRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Toponym, bool>>>(), It.IsAny<Func<IQueryable<Toponym>, IIncludableQueryable<Toponym, object>>>()))
                .ReturnsAsync((Expression<Func<Toponym, bool>> predicate, Func<IQueryable<Toponym>, IIncludableQueryable<Toponym, object>> include) =>
                {
                    return toponyms.FirstOrDefault(predicate.Compile());
                });

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetTeamRepositoryMock()
        {
            var members = new List<TeamMember>()
            {
                new TeamMember { Id = 1, FirstName = "1", IsMain = true },
                new TeamMember { Id = 2, FirstName = "2", IsMain = true },
                new TeamMember { Id = 3, FirstName = "3", IsMain = false },
                new TeamMember { Id = 4, FirstName = "4", IsMain = false },
                new TeamMember { Id = 5, FirstName = "5", IsMain = false },
                new TeamMember { Id = 6, FirstName = "6", IsMain = false },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.TeamRepository
                .GetAllAsync(
                    It.IsAny<Expression<Func<TeamMember, bool>>>(),
                    It.IsAny<Func<IQueryable<TeamMember>, IIncludableQueryable<TeamMember, object>>>()))
                .ReturnsAsync(members);

            mockRepo.Setup(x => x.TeamRepository
                .GetAllAsync(
                    It.IsAny<Expression<Func<TeamMember, bool>>>(),
                    It.IsAny<Func<IQueryable<TeamMember>, IIncludableQueryable<TeamMember, object>>>()))
                .ReturnsAsync((
                    Expression<Func<TeamMember, bool>> filter,
                    Func<IQueryable<TeamMember>, IIncludableQueryable<TeamMember, object>> include) =>
                {
                    IQueryable<TeamMember> query = members.AsQueryable();

                    if (include != null)
                    {
                        query = include(query);
                    }

                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }

                    return Task.FromResult(query.ToList()).Result;
                });

            mockRepo.Setup(x => x.TeamRepository
                .GetSingleOrDefaultAsync(
                    It.IsAny<Expression<Func<TeamMember, bool>>>(),
                    It.IsAny<Func<IQueryable<TeamMember>, IIncludableQueryable<TeamMember, object>>>()))
                .ReturnsAsync((
                    Expression<Func<TeamMember, bool>> predicate,
                    Func<IQueryable<TeamMember>, IIncludableQueryable<TeamMember, object>> include) =>
                    {
                        var matchingMembers = members.Where(predicate.Compile()).ToList();

                        if (matchingMembers.Count > 1)
                        {
                            throw new InvalidOperationException("Sequence contains more than one element");
                        }

                        return matchingMembers.SingleOrDefault();
                    });

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetTeamPositionRepositoryMock()
        {
            var positions = new List<Positions>
            {
                new Positions(),
                new Positions(),
                new Positions(),
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.PositionRepository
                .GetAllAsync(
                    It.IsAny<Expression<Func<Positions, bool>>>(),
                    It.IsAny<Func<IQueryable<Positions>, IIncludableQueryable<Positions, object>>>()))
                .ReturnsAsync(positions);

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetTeamLinksRepositoryMock()
        {
            var links = new List<TeamMemberLink>
            {
                new TeamMemberLink(),
                new TeamMemberLink(),
                new TeamMemberLink(),
                new TeamMemberLink(),
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.TeamLinkRepository
                .GetAllAsync(
                    It.IsAny<Expression<Func<TeamMemberLink, bool>>>(),
                    It.IsAny<Func<IQueryable<TeamMemberLink>, IIncludableQueryable<TeamMemberLink, object>>>()))
                .ReturnsAsync(links);

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetTimelineRepositoryMock()
        {
            var timeline_items = new List<TimelineItem>()
            {
                 new TimelineItem { Id = 1, Title = "TimelineItem 1", Description = "First description", Date = DateTime.Now, DateViewPattern = DateViewPattern.DateMonthYear },
                 new TimelineItem { Id = 2, Title = "TimelineItem 2", Description = "Second description", Date = DateTime.Now, DateViewPattern = DateViewPattern.DateMonthYear },
                 new TimelineItem { Id = 3, Title = "TimelineItem 3", Description = "Third description", Date = DateTime.Now, DateViewPattern = DateViewPattern.DateMonthYear }
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(repo => repo.TimelineRepository.GetAllAsync(It.IsAny<Expression<Func<TimelineItem, bool>>>(), It.IsAny<Func<IQueryable<TimelineItem>,
                IIncludableQueryable<TimelineItem, object>>>())).ReturnsAsync(timeline_items);

            mockRepo.Setup(repo => repo.TimelineRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<TimelineItem, bool>>>(), It.IsAny<Func<IQueryable<TimelineItem>, IIncludableQueryable<TimelineItem, object>>>()))
                .ReturnsAsync((Expression<Func<TimelineItem, bool>> predicate, Func<IQueryable<TimelineItem>, IIncludableQueryable<TimelineItem, object>> include) =>
                {
                    return timeline_items.FirstOrDefault(predicate.Compile());
                });

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetHistoricalContextRepositoryMock()
        {
            var historical_contexts = new List<HistoricalContext>()
    {
        new HistoricalContext { Id = 1, Title = "TimelineItem 1" },
        new HistoricalContext { Id = 2, Title = "TimelineItem 2" },
        new HistoricalContext { Id = 3, Title = "TimelineItem 3" }
    };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(repo => repo.HistoricalContextRepository.GetAllAsync(It.IsAny<Expression<Func<HistoricalContext, bool>>>(), It.IsAny<Func<IQueryable<HistoricalContext>,
                IIncludableQueryable<HistoricalContext, object>>>())).ReturnsAsync(historical_contexts);

            mockRepo.Setup(repo => repo.HistoricalContextRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<HistoricalContext, bool>>>(), It.IsAny<Func<IQueryable<HistoricalContext>, IIncludableQueryable<HistoricalContext, object>>>()))
                    .ReturnsAsync((Expression<Func<HistoricalContext, bool>> predicate, Func<IQueryable<HistoricalContext>, IIncludableQueryable<HistoricalContext, object>> include) =>
                    {
                        return historical_contexts.FirstOrDefault(predicate.Compile());
                    });

            return mockRepo;
        }

    }
}
