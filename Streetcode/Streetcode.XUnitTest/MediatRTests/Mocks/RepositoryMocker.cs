namespace Streetcode.XUnitTest.MediatRTests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Query;
    using Moq;
    using Streetcode.BLL.Dto.Email;
    using Streetcode.BLL.Interfaces.Email;
    using Streetcode.BLL.Interfaces.Instagram;
    using Streetcode.BLL.Interfaces.Payment;
    using Streetcode.DAL.Entities.AdditionalContent;
    using Streetcode.DAL.Entities.AdditionalContent.Coordinates.Types;
    using Streetcode.DAL.Entities.Instagram;
    using Streetcode.DAL.Entities.Locations;
    using Streetcode.DAL.Entities.Media;
    using Streetcode.DAL.Entities.Media.Images;
    using Streetcode.DAL.Entities.Partners;
    using Streetcode.DAL.Entities.Payment;
    using Streetcode.DAL.Entities.Sources;
    using Streetcode.DAL.Entities.Streetcode;
    using Streetcode.DAL.Entities.Team;
    using Streetcode.DAL.Entities.Timeline;
    using Streetcode.DAL.Entities.Toponyms;
    using Streetcode.DAL.Entities.News;
    using Streetcode.DAL.Enums;
    using Streetcode.DAL.Repositories.Interfaces.Base;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Streetcode.DAL.Persistence;
    using Streetcode.DAL.Entities.Streetcode.TextContent;

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

        public static Mock<IRepositoryWrapper> GetSourceRepositoryMock()
        {
            var sources = new List<SourceLinkCategory>()
            {
                new SourceLinkCategory { Id = 1, Title = "First title", ImageId = 1, Image = null },
                new SourceLinkCategory { Id = 2, Title = "Second title", ImageId = 2, Image = null },
                new SourceLinkCategory { Id = 3, Title = "Third title", ImageId = 3, Image = null },
                new SourceLinkCategory { Id = 4, Title = "Fourth title", ImageId = 4, Image = null },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.SourceCategoryRepository.GetAllAsync(It.IsAny<Expression<Func<SourceLinkCategory, bool>>>(), It.IsAny<Func<IQueryable<SourceLinkCategory>, IIncludableQueryable<SourceLinkCategory, object>>>()))
                .ReturnsAsync(sources);

            return mockRepo;
        }


        public static Mock<IInstagramService> GetInstagramPostsMock()
        {
            var posts = new List<InstagramPost>()
            {
                new InstagramPost{ Id = "1", Caption = "1Caption", IsPinned = true, MediaType = "Image", MediaUrl = "1url", Permalink = "1permalink", ThumbnailUrl = "1thumbnailurl" },
                new InstagramPost{ Id = "2", Caption = "2Caption", IsPinned = true, MediaType = "Image", MediaUrl = "2url", Permalink = "2permalink", ThumbnailUrl = "2thumbnailurl" },
                new InstagramPost{ Id = "3", Caption = "3Caption", IsPinned = true, MediaType = "Image", MediaUrl = "3url", Permalink = "3permalink", ThumbnailUrl = "3thumbnailurl" },
                new InstagramPost{ Id = "4", Caption = "4Caption", IsPinned = true, MediaType = "Image", MediaUrl = "4url", Permalink = "4permalink", ThumbnailUrl = "4thumbnailurl" },
            };

            var mockRepo = new Mock<IInstagramService>();

            mockRepo.Setup(x => x.GetPostsAsync())
                .ReturnsAsync(posts);

            return mockRepo;
        }
      
        public static Mock<IRepositoryWrapper> GetPartnersRepositoryMock()
        {
            var mockRepo = new Mock<IRepositoryWrapper>();
          
            var partners = new List<Partner>()
            {
                new Partner { Id = 1, Title = "First Title", LogoId = 1, IsKeyPartner = true, IsVisibleEverywhere = true, TargetUrl = "First Url", UrlTitle = "First Url Title", Description = "First Description", Logo = null },
                new Partner { Id = 2, Title = "Second Title", LogoId = 2, IsKeyPartner = true, IsVisibleEverywhere = true, TargetUrl = "Second Url", UrlTitle = "Second Url Title", Description = "Second Description", Logo = null },
                new Partner { Id = 3, Title = "Third Title", LogoId = 3, IsKeyPartner = true, IsVisibleEverywhere = true, TargetUrl = "Third Url", UrlTitle = "Third Url Title", Description = "Third Description", Logo = null },
                new Partner { Id = 4, Title = "Fourth Title", LogoId = 4, IsKeyPartner = true, IsVisibleEverywhere = true, TargetUrl = "Fourth Url", UrlTitle = "Fourth Url Title", Description = "Fourth Description", Logo = null },
            };
          
            mockRepo.Setup(x => x.PartnersRepository.GetAllAsync(It.IsAny<Expression<Func<Partner, bool>>>(), It.IsAny<Func<IQueryable<Partner>, IIncludableQueryable<Partner, object>>>()))
                .ReturnsAsync(partners);

            mockRepo.Setup(x => x.PartnersRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Partner, bool>>>(), It.IsAny<Func<IQueryable<Partner>, IIncludableQueryable<Partner, object>>>()))
                .ReturnsAsync((Expression<Func<Partner, bool>> predicate, Func<IQueryable<Partner>, IIncludableQueryable<Partner, object>> include) =>
                {
                    return partners.FirstOrDefault(predicate.Compile());
                });
          
            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetLocationsRepositoryMock()
        {
            var mockRepo = new Mock<IRepositoryWrapper>();

            var locations = new List<Location>()
            {
                new Location { Id = 1, Streetname = "First StreetName", TableNumber = 1 },
                new Location { Id = 2, Streetname = "First StreetName", TableNumber = 2 },
                new Location { Id = 3, Streetname = "First StreetName", TableNumber = 3 },
                new Location { Id = 4, Streetname = "First StreetName", TableNumber = 4 },
            };

            mockRepo.Setup(x => x.LocationRepository.GetAllAsync(It.IsAny<Expression<Func<Location, bool>>>(), It.IsAny<Func<IQueryable<Location>, IIncludableQueryable<Location, object>>>()))
                .ReturnsAsync(locations);

            mockRepo.Setup(x => x.LocationRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Location, bool>>>(), It.IsAny<Func<IQueryable<Location>, IIncludableQueryable<Location, object>>>()))
                .ReturnsAsync((Expression<Func<Location, bool>> predicate, Func<IQueryable<Location>, IIncludableQueryable<Location, object>> include) =>
                 {
                     return locations.FirstOrDefault(predicate.Compile());
                 });

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

        public static Mock<IRepositoryWrapper> GetTagRepositoryMock()
        {
            var tag = new Tag()
            {
                Id = 1,
                Title = "Test",
            };

            List<Tag> tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Title = "Test",
                },
                new Tag
                {
                    Id = 2,
                    Title = "Test",
                },
            };

            var tagIndeces = new List<StreetcodeTagIndex>
            {
                new StreetcodeTagIndex { TagId = 1, StreetcodeId = 1, Tag = new Tag { Id = 1, Title = "Test" }, Index = 1 },
                new StreetcodeTagIndex { TagId = 2, StreetcodeId = 1, Tag = new Tag { Id = 2, Title = "Test" }, Index = 2 },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.TagRepository.CreateAsync(It.IsAny<Tag>()))
                .ReturnsAsync(tag);

            mockRepo.Setup(x => x.TagRepository.GetFirstOrDefaultAsync(
                It.IsAny<Expression<Func<Tag, bool>>>(),
                It.IsAny<Func<IQueryable<Tag>, IIncludableQueryable<Tag, object>>>()))
                .ReturnsAsync((Expression<Func<Tag, bool>> predicate, Func<IQueryable<Tag>,
                IIncludableQueryable<Tag, object>> include) =>
                {
                    return tags.FirstOrDefault(predicate.Compile());
                });

            mockRepo.Setup(x => x.TagRepository.GetAllAsync(
                It.IsAny<Expression<Func<Tag, bool>>>(),
                It.IsAny<Func<IQueryable<Tag>, IIncludableQueryable<Tag, object>>>()))
                .ReturnsAsync(tags);

            mockRepo.Setup(x => x.StreetcodeTagIndexRepository.GetAllAsync(
               It.IsAny<Expression<Func<StreetcodeTagIndex, bool>>>(),
               It.IsAny<Func<IQueryable<StreetcodeTagIndex>,
               IIncludableQueryable<StreetcodeTagIndex, object>>>()))
               .Returns(Task.FromResult<IEnumerable<StreetcodeTagIndex>>(tagIndeces));

            mockRepo.Setup(repo => repo.TagRepository.Update(It.IsAny<Tag>()));

            mockRepo.Setup(x => x.SaveChanges()).Returns(1);

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetTagRepositoryMockWithSettingException()
        {
            var tag = new Tag()
            {
                Id = 1,
                Title = "Test",
            };

            List<Tag> tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Title = "Test",
                },
                new Tag
                {
                    Id = 2,
                    Title = "Test",
                },
            };

            var tagIndeces = new List<StreetcodeTagIndex>
            {
                new StreetcodeTagIndex { TagId = 1, StreetcodeId = 1, Tag = new Tag { Id = 1, Title = "Test" }, Index = 1 },
                new StreetcodeTagIndex { TagId = 2, StreetcodeId = 1, Tag = new Tag { Id = 2, Title = "Test" }, Index = 2 },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.TagRepository.CreateAsync(It.IsAny<Tag>()))
                .ReturnsAsync(tag);

            mockRepo.Setup(x => x.TagRepository.GetFirstOrDefaultAsync(
                It.IsAny<Expression<Func<Tag, bool>>>(),
                It.IsAny<Func<IQueryable<Tag>, IIncludableQueryable<Tag, object>>>()))
                .ReturnsAsync((Expression<Func<Tag, bool>> predicate, Func<IQueryable<Tag>,
                IIncludableQueryable<Tag, object>> include) =>
                {
                    return tags.FirstOrDefault(predicate.Compile());
                });

            mockRepo.Setup(x => x.TagRepository.GetAllAsync(
                It.IsAny<Expression<Func<Tag, bool>>>(),
                It.IsAny<Func<IQueryable<Tag>,
                IIncludableQueryable<Tag, object>>>()))
                .ReturnsAsync(tags);

            mockRepo.Setup(x => x.TagRepository.Update(It.IsAny<Tag>()));

            mockRepo.Setup(x => x.SaveChanges()).Throws(new InvalidOperationException("Failed to create tag"));

            return mockRepo;
        }

        public static Mock<IPaymentService> GetPaymentMock()
        {
            var merchantPaymentInfo = new MerchantPaymentInfo
            {
                Destination = "Destination 1"
            };

            var invoices = new List<Invoice>()
            {
                new Invoice(10000, 840, merchantPaymentInfo, "https://example.com/redirect1"),
                new Invoice(10000, 840, merchantPaymentInfo, "https://example.com/redirect2"),
                new Invoice(10000, 840, merchantPaymentInfo, "https://example.com/redirect3"),
            };

            var mockService = new Mock<IPaymentService>();

            mockService.Setup(x => x.CreateInvoiceAsync(It.IsAny<Invoice>()))
               .ReturnsAsync(new InvoiceInfo("invoiceId", "pageUrl"));

            return mockService;
        }

        public static Mock<IRepositoryWrapper> GetNewsRepositoryMock()
        {
            var newsItem = new News()
            {
                Id = 1,
                Title = "Title1",
                Text = "Text1",
                CreationDate = new DateTime(2024, 3, 21, 0, 0, 0, DateTimeKind.Utc),
                ImageId = 1,
                URL = "example.com",
            };

            var news = new List<News>()
            {
                new News()
                {
                    Id = 1,
                    Title = "Title1",
                    Text = "Text1",
                    CreationDate = new DateTime(2024, 3, 22, 0, 0, 0, DateTimeKind.Utc),
                    ImageId = 1,
                    URL = "example1.com",
                },
                new News()
                {
                    Id = 2,
                    Title = "Title2",
                    Text = "Text2",
                    CreationDate = new DateTime(2022, 3, 21, 0, 0, 0, DateTimeKind.Utc),
                    ImageId = 2,
                    URL = "example2.com",
                },
                new News()
                {
                    Id = 3,
                    Title = "Title3",
                    Text = "Text3",
                    CreationDate = new DateTime(2024, 3, 23, 0, 0, 0, DateTimeKind.Utc),
                    ImageId = 3,
                    URL = "example3.com",
                },
            };

            var images = new List<Image>()
            {
                new Image()
                {
                    Id = 1
                },
                new Image()
                {
                    Id = 2
                },
                new Image()
                {
                    Id = 3
                },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.NewsRepository.Create(It.IsAny<News>()))
                .Returns(newsItem);

            mockRepo.Setup(x => x.NewsRepository.GetFirstOrDefaultAsync(
                It.IsAny<Expression<Func<News, bool>>>(),
                It.IsAny<Func<IQueryable<News>, IIncludableQueryable<News, object>>>()))
                .ReturnsAsync((Expression<Func<News, bool>> predicate, Func<IQueryable<News>,
                IIncludableQueryable<News, object>> include) =>
                {
                    return news.FirstOrDefault(predicate.Compile());
                });

            mockRepo.Setup(x => x.NewsRepository.GetAllAsync(
                It.IsAny<Expression<Func<News, bool>>>(),
                It.IsAny<Func<IQueryable<News>, IIncludableQueryable<News, object>>>()))
                .ReturnsAsync(news);

            mockRepo.Setup(x => x.ImageRepository.GetFirstOrDefaultAsync(
                It.IsAny<Expression<Func<Image, bool>>>(),
                It.IsAny<Func<IQueryable<Image>, IIncludableQueryable<Image, object>>>()))
                .ReturnsAsync((Expression<Func<Image, bool>> predicate, Func<IQueryable<Image>,
                IIncludableQueryable<Image, object>> include) =>
                {
                    return images.FirstOrDefault(predicate.Compile());
                });

            mockRepo.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            return mockRepo;
        }

        public static Mock<IEmailService> GetEmailMock(bool word)
        {
            var mockService = new Mock<IEmailService>();

            return mockService;
        }

        public static Mock<IRepositoryWrapper> GetAllFacts()
        {
            var facts = new List<Fact>()
            {
                new Fact { Id = 1, Title = "1Title", FactContent = "1FactContent", ImageId = 1, Image = new Image(), StreetcodeId = 1, Streetcode = new StreetcodeContent() },
                new Fact { Id = 2, Title = "2Title", FactContent = "2FactContent", ImageId = 2, Image = new Image(), StreetcodeId = 2, Streetcode = new StreetcodeContent() },
                new Fact { Id = 3, Title = "3Title", FactContent = "3FactContent", ImageId = 3, Image = new Image(), StreetcodeId = 3, Streetcode = new StreetcodeContent() },
                new Fact { Id = 4, Title = "4Title", FactContent = "4FactContent", ImageId = 4, Image = new Image(), StreetcodeId = 4, Streetcode = new StreetcodeContent() },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.FactRepository.GetAllAsync(
                It.IsAny<Expression<Func<Fact, bool>>>(),
                It.IsAny<Func<IQueryable<Fact>, IIncludableQueryable<Fact, object>>>()))
                .ReturnsAsync(facts);

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetAllRelatedFigures()
        {
            var relatedFiegures = new List<RelatedFigure>()
            {
                new RelatedFigure { ObserverId = 1, Observer = new StreetcodeContent(), TargetId = 1, Target = new StreetcodeContent() },
                new RelatedFigure { ObserverId = 2, Observer = new StreetcodeContent(), TargetId = 2, Target = new StreetcodeContent() },
                new RelatedFigure { ObserverId = 3, Observer = new StreetcodeContent(), TargetId = 3, Target = new StreetcodeContent() },
                new RelatedFigure { ObserverId = 4, Observer = new StreetcodeContent(), TargetId = 4, Target = new StreetcodeContent() },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.RelatedFigureRepository.GetAllAsync(
                It.IsAny<Expression<Func<RelatedFigure, bool>>>(),
                It.IsAny<Func<IQueryable<RelatedFigure>, IIncludableQueryable<RelatedFigure, object>>>()))
                .ReturnsAsync(relatedFiegures);

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetAllRelatedTerms()
        {
            var relatedTerms = new List<RelatedTerm>()
            {
                new RelatedTerm { Id = 1, Word = "1Word", TermId = 1, Term = new Term() },
                new RelatedTerm { Id = 2, Word = "2Word", TermId = 2, Term = new Term() },
                new RelatedTerm { Id = 3, Word = "3Word", TermId = 3, Term = new Term() },
                new RelatedTerm { Id = 4, Word = "4Word", TermId = 4, Term = new Term() },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.RelatedTermRepository.GetAllAsync(
                It.IsAny<Expression<Func<RelatedTerm, bool>>>(),
                It.IsAny<Func<IQueryable<RelatedTerm>, IIncludableQueryable<RelatedTerm, object>>>()))
                .ReturnsAsync(relatedTerms);

            return mockRepo;
        }

        public static Mock<IRepositoryWrapper> GetAllStreetcodes()
        {
            var streetcodes = new List<StreetcodeContent>()
            {
                new StreetcodeContent { Alias = "1Alias", Audio = new Audio(), AudioId = 1, Coordinates = new List<StreetcodeCoordinate>(), CreatedAt = new DateTime(), DateString = "1Date", EventEndOrPersonDeathDate = new DateTime(), EventStartOrPersonBirthDate = new DateTime(), Facts = new List<Fact>(), Id = 1, Images = new List<Image>(), Index = 1, Observers = new List<RelatedFigure>(), Partners = new List<Partner>(), SourceLinkCategories = new List<SourceLinkCategory>(), StatisticRecords = new List<DAL.Entities.Analytics.StatisticRecord>(), Status = StreetcodeStatus.Published, StreetcodeArts = new List<StreetcodeArt>(), StreetcodeCategoryContents = new List<StreetcodeCategoryContent>(), StreetcodeTagIndices = new List<StreetcodeTagIndex>(), Subtitles = new List<Subtitle>(), Tags = new List<Tag>(), Targets = new List<RelatedFigure>(), Teaser = "1Teaser", Text = new Text(), TimelineItems = new List<TimelineItem>(), Title = "1Title", Toponyms = new List<Toponym>(), TransactionLink = new DAL.Entities.Transactions.TransactionLink(), TransliterationUrl = "1url", UpdatedAt = new DateTime(), Videos = new List<Video>(), ViewCount = 1 },
                new StreetcodeContent { Alias = "2Alias", Audio = new Audio(), AudioId = 1, Coordinates = new List<StreetcodeCoordinate>(), CreatedAt = new DateTime(), DateString = "2Date", EventEndOrPersonDeathDate = new DateTime(), EventStartOrPersonBirthDate = new DateTime(), Facts = new List<Fact>(), Id = 1, Images = new List<Image>(), Index = 1, Observers = new List<RelatedFigure>(), Partners = new List<Partner>(), SourceLinkCategories = new List<SourceLinkCategory>(), StatisticRecords = new List<DAL.Entities.Analytics.StatisticRecord>(), Status = StreetcodeStatus.Published, StreetcodeArts = new List<StreetcodeArt>(), StreetcodeCategoryContents = new List<StreetcodeCategoryContent>(), StreetcodeTagIndices = new List<StreetcodeTagIndex>(), Subtitles = new List<Subtitle>(), Tags = new List<Tag>(), Targets = new List<RelatedFigure>(), Teaser = "2Teaser", Text = new Text(), TimelineItems = new List<TimelineItem>(), Title = "2Title", Toponyms = new List<Toponym>(), TransactionLink = new DAL.Entities.Transactions.TransactionLink(), TransliterationUrl = "2url", UpdatedAt = new DateTime(), Videos = new List<Video>(), ViewCount = 2 },
                new StreetcodeContent { Alias = "3Alias", Audio = new Audio(), AudioId = 1, Coordinates = new List<StreetcodeCoordinate>(), CreatedAt = new DateTime(), DateString = "3Date", EventEndOrPersonDeathDate = new DateTime(), EventStartOrPersonBirthDate = new DateTime(), Facts = new List<Fact>(), Id = 1, Images = new List<Image>(), Index = 1, Observers = new List<RelatedFigure>(), Partners = new List<Partner>(), SourceLinkCategories = new List<SourceLinkCategory>(), StatisticRecords = new List<DAL.Entities.Analytics.StatisticRecord>(), Status = StreetcodeStatus.Published, StreetcodeArts = new List<StreetcodeArt>(), StreetcodeCategoryContents = new List<StreetcodeCategoryContent>(), StreetcodeTagIndices = new List<StreetcodeTagIndex>(), Subtitles = new List<Subtitle>(), Tags = new List<Tag>(), Targets = new List<RelatedFigure>(), Teaser = "3Teaser", Text = new Text(), TimelineItems = new List<TimelineItem>(), Title = "3Title", Toponyms = new List<Toponym>(), TransactionLink = new DAL.Entities.Transactions.TransactionLink(), TransliterationUrl = "3url", UpdatedAt = new DateTime(), Videos = new List<Video>(), ViewCount = 3 },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.StreetcodeRepository.GetAllAsync(
                It.IsAny<Expression<Func<StreetcodeContent, bool>>>(),
                It.IsAny<Func<IQueryable<StreetcodeContent>, IIncludableQueryable<StreetcodeContent, object>>>()))
                .ReturnsAsync(streetcodes);

            return mockRepo;
        }
    }
}
