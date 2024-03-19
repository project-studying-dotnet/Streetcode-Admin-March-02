using Microsoft.EntityFrameworkCore.Query;
using Moq;
using Repositories.Interfaces;
using Streetcode.BLL.DTO.Media.Art;
using Streetcode.BLL.Interfaces.Instagram;
using Streetcode.DAL.Entities.Instagram;
using Streetcode.DAL.Entities.Media.Images;
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
    }
}
