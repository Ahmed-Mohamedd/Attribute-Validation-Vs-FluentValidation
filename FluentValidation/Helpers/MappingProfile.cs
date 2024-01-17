using AutoMapper;
using Core.Entities;
using FluentValidation.DTOs;

namespace FluentValidation.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<BreakfastDto, BreakFast>().ReverseMap();
        }
    }
}
