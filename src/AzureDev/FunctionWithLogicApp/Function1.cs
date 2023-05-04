using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionWithLogicApp
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            

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
