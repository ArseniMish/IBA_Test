using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpeedModeTransport.Application.FileStorage.Interfaces;
using SpeedModeTransport.Application.Models;
using SpeedModeTransport.Application.Services.Interfaces;
using SpeedModeTransport.WebApi.Dto.Measurements;
using SpeedModeTransport.WebApi.Filters;

namespace SpeedModeTransportApi.Controllers
{
    [ApiController]
    [Route("SpeedModeApi")]
    public class SpeedModeController : ApiControllerBase
    {
        private readonly IMeasurementService _measurementService;
        private readonly IMapper _mapper;

        public SpeedModeController(IMeasurementService measurementService, IMapper mapper)
        {
            _measurementService = measurementService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddMeasurement")]
        public async Task<IActionResult> AddMeasurement(DateTime date, string vehicleNumber, float speed)
        {

            var measurementCreateResponse = await _measurementService.AddMeasurementAsync(date, vehicleNumber, speed);

            var measurementCreateResponseDto = _mapper.Map<MeasurementCreateResponseDto>(measurementCreateResponse);

            return Ok(measurementCreateResponseDto);
        }

        [TypeFilterAttribute(typeof(WorkTimeAttribute))]
        [HttpGet]
        [Route("GetOffendingVehicle")]
        public async Task<IActionResult> GetOffendingVehicle(DateTime date, float speed)
        {

            var offendingVehicles = await _measurementService.GetOffendingAsync(date, speed);

            return Ok(offendingVehicles);
        }

        [TypeFilterAttribute(typeof(WorkTimeAttribute))]
        [HttpGet]
        [Route("GetSpeed")]
        public async Task<IActionResult> GetSpeed(DateTime date)
        {

            var result = await _measurementService.GetSpeedByDateAsync(date); 

            return Ok(result);
        }
    }
}
