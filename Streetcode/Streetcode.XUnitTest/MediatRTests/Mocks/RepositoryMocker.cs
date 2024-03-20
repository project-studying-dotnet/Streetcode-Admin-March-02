using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Repositories.Interfaces;
using Streetcode.BLL.DTO.Media.Art;
using Streetcode.BLL.DTO.Sources;
using Streetcode.DAL.Entities.Media.Images;
using Streetcode.DAL.Entities.Sources;
using Streetcode.DAL.Repositories.Interfaces.Base;
using Streetcode.DAL.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}
