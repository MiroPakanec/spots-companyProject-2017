using System.Collections.Generic;

namespace spots.Modules.Map.Models
{
    public class MapDetailsViewModel
    {
        public IEnumerable<MapLocation> Geolocations { get; set; }
        public MapLocation CenterPosition { get; set; }
    }
}