using AutoMapper;
using Domain;
using Domain.ModelDTOs;
using System.Globalization;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Home, HomeDto>();
            CreateMap<Device, DeviceDto>();
            CreateMap<RunPeriod, RunPeriodDto>();
            CreateMap<Field, FieldDto>();
            CreateMap<FieldRow, FieldRowDto>();
        }
    }
}