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
    public static class CalcuateInvoiceTotal
    {
        [FunctionName("CalcuateInvoiceTotal")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameters

            string subTotal = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "subTotal", true) == 0)
                .Value;
            string tax = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "tax", true) == 0)
                .Value;

            if (subTotal == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                subTotal = data?.subTotal;
            }


            if (tax == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                tax = data?.subTotal;
            }

            double dblsubTotal = Convert.ToDouble(subTotal);
            double dbltax = Convert.ToDouble(tax);

            double total = dblsubTotal + dbltax;
            return subTotal == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, total.ToString());
        }
    }
}
