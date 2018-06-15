using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Web.Util
{

    /// <summary>
    /// Class for standardized HTTP response
    /// </summary>
    public class ResultWithBody : ActionResult
    {
        // Content of response
        public HttpStatusCode Code { get; set; }
        public string Body { get; set; }
        // Constructors
        public ResultWithBody() { }
        public ResultWithBody(HttpStatusCode code, string body)
        {
            Code = code;
            Body = body;
        }
        // Processes the response
        public override void ExecuteResult(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)Code;
            var buffer = Encoding.UTF8.GetBytes(Body);
            context.HttpContext.Response.ContentLength = buffer.Length;
            context.HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}

