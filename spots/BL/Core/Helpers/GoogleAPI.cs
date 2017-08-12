using System;
using System.Xml.Linq;
using spots.Modules.Map.Models;
using spots.Services.Requests;

namespace spots.BL.Core.Helpers
{
    public static class GoogleAPI
    {
        public static XDocument GeolocationRequest(string address)
        {
            var uri = $"http://maps.googleapis.com/maps/api/geocode/xml?address={Uri.EscapeDataString(address)}&sensor=false";
            return Request.Get.XDoc(uri);
        }

        public static MapLocation ManageGeolocationResponse(XDocument response)
        {
            var geocodeResponse = response?.Element("GeocodeResponse");
            var result = geocodeResponse?.Element("result");
            var geometry = result?.Element("geometry");
            var location = geometry?.Element("location");

            if (location == null)
            {
                return null;
            }

            var latitude = location.Element("lat");
            var longitude = location.Element("lng");

            if (latitude == null || longitude == null)
            {
                return null;
            }

            return new MapLocation()
            {
                Latitude = latitude.Value,
                Longitude = longitude.Value
            };
        }
    }
}