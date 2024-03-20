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

namespace Streetcode.XUnitTest.MediatRTests.Mocks
{
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
