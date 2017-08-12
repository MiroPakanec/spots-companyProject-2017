using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace spots.Services.Requests
{
    public class Get
    {
        public XDocument XDoc(string requestUri)
        {
            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            return XDocument.Load(response.GetResponseStream());
        }
    }
}