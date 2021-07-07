using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeedModeTransport.Application.Helpers;
using SpeedModeTransport.Application.Models;

namespace SpeedModeTransport.Application.FileStorage.Interfaces
{
    public static class DocumentPath
    {
        public static string MeasurementFolder(DateTime date) =>
            Path.Combine("MeasurementResults",$"{date.ToString(("MM/dd/yyyy"))}");
    }
}
