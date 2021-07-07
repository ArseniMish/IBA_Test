using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SpeedModeTransport.Application.FileStorage.Interfaces;
using SpeedModeTransport.Application.Models;
using SpeedModeTransport.Application.Services.Interfaces;

namespace SpeedModeTransport.Application.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IFileStorageService _fileStorageService;

        public MeasurementService(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }
        public async Task<MeasurementResults> AddMeasurementAsync(DateTime date, string vehicleNumber, float speed)
        {
            var measurementResults = new MeasurementResults
            {
                Date = date,
                VehicleNumber = vehicleNumber,
                Speed = speed
            };

            var measurementResultsResponse = await _fileStorageService.WriteAsync(measurementResults);

            return measurementResultsResponse;
        }

        public async Task<List<MeasurementResults>> GetOffendingAsync(DateTime date, float speed)
        {
            var measurementResultsByDate = await _fileStorageService.ReadManyByDateAsync(date);

            return measurementResultsByDate.Where(_ => _.Date == date && _.Speed > speed).ToList();
        }

        public async Task<List<MeasurementResults>> GetSpeedByDateAsync(DateTime date)
        {
            var measurementResultsByDate = await _fileStorageService.ReadManyByDateAsync(date);

            return measurementResultsByDate.Where(result => result.Speed == measurementResultsByDate.Min(_ => _.Speed) || result.Speed == measurementResultsByDate.Max(_ => _.Speed))
                .ToList();
        }
    }
}
