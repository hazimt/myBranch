using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace InvoiceFunctionApp
{
    public static class CalTaxByState
    {
        [FunctionName("CalTaxByState")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            Dictionary<string, double> taxSchedule = new Dictionary<string, double>();
            taxSchedule.Add("WA", 10.50);
            taxSchedule.Add("CA", 9.00);
            taxSchedule.Add("MI", 20.00);
            taxSchedule.Add("AL", 15.00);

            // parse query parameters
            string subTotal = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "subTotal", true) == 0)
                .Value;
            string state = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "state", true) == 0)
                .Value;

            if (subTotal == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                subTotal = data?.subTotal;
            }


            if (state == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                state = data?.state;
            }

            double dblsubTotal = Convert.ToDouble(subTotal);


            double percent = taxSchedule[state];
            double dblSubTotal = Convert.ToDouble(subTotal);
            double tax = (dblSubTotal * percent)/100;

            return subTotal == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, tax.ToString());

        }
    }
}
