using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace QueryingServer.Controllers
{
    public class ServerController : ApiController
    {
        public HttpResponseMessage Get()
        {
            //var response = new HttpResponseMessage();
            //response.Content = new StringContent("<html><body>Hello World </body></html>");
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            //return response;

            var fileContents = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Content/index.html"));
            var response = new HttpResponseMessage();
            response.Content = new StringContent(fileContents);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }

        public HttpResponseMessage Get(string id)
        {
            // parse the id to parameters, startDate, endDate, postalCode
            string[] parameters = id.Split('_');
            string startDate = parameters[0];
            string endDate = parameters[1];
            string postalCode = parameters[2];

            TransactionQuery transactionQuery = new TransactionQuery();
            string s = transactionQuery.QueryingAvg(startDate, endDate, postalCode).ToString();
            if (s == null)
            {
                s = "No transaction during the time";
            }
            
            var response = new HttpResponseMessage();
            response.Content = new StringContent(s);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }

    }    
}
