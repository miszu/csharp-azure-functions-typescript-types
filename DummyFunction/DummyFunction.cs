using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Mvc;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace DummyFunctionApp.DummyFunction
{
    public class DummyFunction
    {
        [FunctionName("DummyFunction")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DummyResponseDto))]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Admin, "get", Route = "dummyFunction")] HttpRequest req, ILogger log)
        {
            return new OkObjectResult("hey!");
        }
    }

    public class DummyResponseDto
    {
        public string Text { get; set; }
        
        [Required]
        public string RequiredText { get; set; }
        
        public DummyNestedDto[] NestedThingies { get; set; }
    }
    
    public class DummyNestedDto
    {
        public double ImportantNumber { get; set; }
    }
}