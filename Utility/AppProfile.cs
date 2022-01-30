using Application.Share;
using HotelMgt.Models;

namespace HotelMgt.Utility
{
    public class AppProfile : AutoMapper.Profile
    {
        public AppProfile()
        {
            CreateMap<Visitors, RegistrationViewModel>()
                .ReverseMap();

          
        }
    }
}
