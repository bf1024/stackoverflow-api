using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using StackOverflowAPI.Dtos;
using StackOverflowAPI.Models;

namespace StackOverflowUI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TagDTO, Tag>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Percent, opt => opt.MapFrom(src => src.percent))
            .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.count));

            CreateMap<Tag, TagDTO>()
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.percent, opt => opt.MapFrom(src => src.Percent))
            .ForMember(dest => dest.count, opt => opt.MapFrom(src => src.Count));

           // CreateMap<List<TagDTO>, List<Tag>>();
           // CreateMap<List<Tag>, List<TagDTO>>();
        }
    }
}
