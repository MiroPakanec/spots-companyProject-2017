using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spots.Services.Routing
{
    public static class EscapeHelper
    {
        public static string UnescapeDots(string value)
        {
            return value.Replace("(dot)", ".");
        }
    }
}