using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Repositories.Interfaces;
using Streetcode.BLL.DTO.Media.Art;
using Streetcode.DAL.Entities.Media.Images;
using Streetcode.DAL.Entities.Partners;
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

        public static Mock<IRepositoryWrapper> GetPartnersRepositoryMock()
        {
            var partners = new List<Partner>()
            {
                new Partner { Id = 1, Title = "First Title", LogoId = 1, IsKeyPartner = true, IsVisibleEverywhere = true, TargetUrl = "First Url", UrlTitle = "First Url Title", Description = "First Description", Logo = null },
                new Partner { Id = 2, Title = "Second Title", LogoId = 2, IsKeyPartner = true, IsVisibleEverywhere = true, TargetUrl = "Second Url", UrlTitle = "Second Url Title", Description = "Second Description", Logo = null },
                new Partner { Id = 3, Title = "Third Title", LogoId = 3, IsKeyPartner = true, IsVisibleEverywhere = true, TargetUrl = "Third Url", UrlTitle = "Third Url Title", Description = "Third Description", Logo = null },
                new Partner { Id = 4, Title = "Fourth Title", LogoId = 4, IsKeyPartner = true, IsVisibleEverywhere = true, TargetUrl = "Fourth Url", UrlTitle = "Fourth Url Title", Description = "Fourth Description", Logo = null },
            };

            var mockRepo = new Mock<IRepositoryWrapper>();

            mockRepo.Setup(x => x.PartnersRepository.GetAllAsync(It.IsAny<Expression<Func<Partner, bool>>>(), It.IsAny<Func<IQueryable<Partner>, IIncludableQueryable<Partner, object>>>()))
                .ReturnsAsync(partners);

            mockRepo.Setup(x => x.PartnersRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Partner, bool>>>(), It.IsAny<Func<IQueryable<Partner>, IIncludableQueryable<Partner, object>>>()))
                .ReturnsAsync((Expression<Func<Partner, bool>> predicate, Func<IQueryable<Partner>, IIncludableQueryable<Partner, object>> include) =>
                {
                    return partners.FirstOrDefault(predicate.Compile());
                });

            return mockRepo;
        }
    }
}
