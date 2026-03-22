using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMapQROOBackend.Interfaces
{
    public interface ILocationService
    {
        double CalculateDistance(double lat1, double lon1, double lat2, double lon2);
        double DegreesToRadians(double degrees);
    }
}