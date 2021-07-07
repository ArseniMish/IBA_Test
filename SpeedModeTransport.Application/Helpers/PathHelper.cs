using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedModeTransport.Application.Helpers
{
    public static class PathHelper
    {
        public static string RemoveInvalidChars(string filename)
        {
            return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
        }

        public static string ToUpperFileName(string value, string emptyFileName = "")
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return emptyFileName;
            }

            return PathHelper.RemoveInvalidChars(value.Trim()).ToUpper().Replace(" ", "");
        }
    }
}
