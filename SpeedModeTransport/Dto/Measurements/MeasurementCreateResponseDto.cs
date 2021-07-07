using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedModeTransport.WebApi.Dto.Measurements
{
    public class MeasurementCreateResponseDto
    {
        public DateTime Date { get; set; }

        public string VehicleNumber { get; set; }

        public float Speed { get; set; }
    }
}
