using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace DummyFunctionApp.DummyFunction
{
    public class DummyFunction
    {
        [FunctionName("DummyFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Admin, "get", Route = "dummyFunction")] HttpRequest req, ILogger log)
        {
            return new OkObjectResult("hey!");
        }
    }
}