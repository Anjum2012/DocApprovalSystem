using AutoMapper;
using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Domain.Entities;

namespace DocumentAccessApproval.Application.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateAccessRequestDto, AccessRequest>().ReverseMap();
            CreateMap<AccessRequestDto, AccessRequest>().ReverseMap();
            CreateMap<DecisionDto, AccessRequest>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
