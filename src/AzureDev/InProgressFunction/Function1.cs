using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace InProgressFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = String.Empty;
            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }

            dynamic score = JsonConvert.DeserializeObject(requestBody);
            string value = "Positive";

            if (score < .3)
            {
                value = "Negative";
            }
            else if (score < .6)
            {
                value = "Neutral";
            }

            return requestBody != null
                ? (ActionResult)new OkObjectResult(value)
               : new BadRequestObjectResult("Pass a sentiment score in the request body.");
        }
    }
}
