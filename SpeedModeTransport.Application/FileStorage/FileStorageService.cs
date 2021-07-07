using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SpeedModeTransport.Application.FileStorage.Interfaces;
using SpeedModeTransport.Application.Models;

namespace SpeedModeTransport.Application
{
    public class FileStorageService : IFileStorageService
    {
        public async Task<MeasurementResults> ReadAsync(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var measurementResultsResponse = await JsonSerializer.DeserializeAsync<MeasurementResults>(fs);

                return measurementResultsResponse;
            }
        }


        public async Task<MeasurementResults> WriteAsync(MeasurementResults measurementResults)
        {
            var path = DocumentPath.MeasurementFolder(measurementResults.Date);

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            using (FileStream fs = new FileStream($"{path}\\{measurementResults.VehicleNumber}.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<MeasurementResults>(fs, measurementResults);

                return measurementResults;
            }
        }

        public async Task<List<MeasurementResults>> ReadManyByDateAsync(DateTime date)
        {
            var measurementResults = new List<MeasurementResults>();

            string path = DocumentPath.MeasurementFolder(date);

            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                measurementResults.Add(await ReadAsync(file));
            }

            return measurementResults;
        }
    }
}

