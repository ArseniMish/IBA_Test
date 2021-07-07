using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SpeedModeTransport.Application.Models;
using SpeedModeTransport.WebApi.Dto.Measurements;

namespace SpeedModeTransport.WebApi.Profiles
{
    public class MeasurementResultsProfile : Profile
    {
        public MeasurementResultsProfile()
        {
            CreateMap<MeasurementResults, MeasurementCreateResponseDto>();
            CreateMap<MeasurementCreateResponseDto, MeasurementResults>();
        }
    }
}
