using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeedModeTransport.Application.Models;

namespace SpeedModeTransport.Application.Services.Interfaces
{
    public interface IMeasurementService
    {
        Task<MeasurementResults> AddMeasurementAsync(DateTime date, string vehicleNumber, float speed);

        Task<List<MeasurementResults>> GetOffendingAsync(DateTime date, float speed);

        Task<List<MeasurementResults>> GetSpeedByDateAsync(DateTime date);
    }
}
