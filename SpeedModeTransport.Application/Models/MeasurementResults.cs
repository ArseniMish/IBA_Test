using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedModeTransport.Application.Models
{

    [Serializable]
    public class MeasurementResults
    {
        public DateTime Date { get; set; }

        public string VehicleNumber { get; set; }

        public float Speed { get; set; }
    }
}
