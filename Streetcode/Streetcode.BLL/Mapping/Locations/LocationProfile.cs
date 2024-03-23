using AutoMapper;
using Streetcode.BLL.Dto.Locations;
using Streetcode.DAL.Entities.Locations;

namespace Streetcode.BLL.Mapping.Locations
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}
