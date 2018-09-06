using System;
using AutoMapper;
using Core.Models;
using Domain.Entity;
using Domain.Enum;
using Domain.Extension;

namespace Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskRequest, TaskEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<TaskEntity, TaskResponse>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToEnum<EStatus>().StatusDescription()))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.CreateDate));
        }
    }
}
