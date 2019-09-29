using AutoMapper;
using boilerplate_netcore_api_mysql.Apps.Dtos.In;
using boilerplate_netcore_api_mysql.Apps.Dtos.Out;
using boilerplate_netcore_api_mysql.Apps.Models;

namespace boilerplate_netcore_api_mysql.Apps.Extensions
{
    /// <summary>
    /// Auto mapping models and dtos
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// mapping models to dtos
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Person, PersonOutDtos>().ReverseMap();
            CreateMap<PersonInDtos, Person>().ReverseMap();
        }
    }
}