using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using spots.Models.Response.Interfaces;

namespace spots.Models.Response
{
    public abstract class Response: IResponse
    {
        public string ResponseText { get; set; }
        public bool Success { get; set; }
        public void HasFailed(string message)
        {
            Success = false;
            ResponseText = message;
        }

        public abstract string GetResponseDescription();
       

        public string StyleClass => Success ? "has-success" : "has-error";

        public void HasSucceeded(string message)
        {
            Success = true;
            ResponseText = message;
        } 
          
    }
}