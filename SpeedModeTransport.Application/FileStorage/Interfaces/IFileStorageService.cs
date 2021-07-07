using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SpeedModeTransport.Application.Models;

namespace SpeedModeTransport.Application.FileStorage.Interfaces
{
    public interface IFileStorageService
    {
        Task<MeasurementResults> ReadAsync(string path);

        Task<MeasurementResults> WriteAsync(MeasurementResults measurementResults);

        Task<List<MeasurementResults>> ReadManyByDateAsync(DateTime date);
    }
}
