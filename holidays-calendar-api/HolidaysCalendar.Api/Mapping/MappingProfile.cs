using AutoMapper;
using HolidaysCalendar.Api.Resources;
using HolidaysCalendar.Core.Models;

namespace HolidaysCalendar.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Request, RequestResource>();
            CreateMap<Type, TypeResource>();
            CreateMap<Status, StatusResource>();
            
            // Resource to Domain
            CreateMap<RequestResource, Request>();
            CreateMap<TypeResource, Type>();
            CreateMap<StatusResource, Status>();
        }
    }
}