using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace InvoiceFunctionApp
{
    public static class AddPrices
    {
        [FunctionName("AddPrices")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameters

            string price1 = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "price1", true) == 0)
                .Value;

            string price2 = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "price2", true) == 0)
                .Value;

            if (price1 == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                price1 = data?.price1;
            }


            if (price2 == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                price2 = data?.price2;
            }

            double dblPrice1 = Convert.ToDouble(price1);
            double dblPrice2 = Convert.ToDouble(price2);

            double total = dblPrice1 + dblPrice2;
            return price1 == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, total.ToString());
        }
    }
}
