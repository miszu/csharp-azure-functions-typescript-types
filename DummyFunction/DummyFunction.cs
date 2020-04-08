using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
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
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Admin, "get", Route = "dummyFunction")] HttpRequest req, ILogger log)
        {
            return new ObjectResult(new DummyResponseDto
            {
                Greeting = "Hey!",
                Emoji = "👷🏻‍",
                NestedThingies = Enumerable.Range(0, 5).Select(x => new DummyNestedDto
                {
                    ImportantNumber = x
                }).ToArray()
            });
        }
    }

    public class DummyResponseDto
    {
        public string Emoji { get; set; }
        
        [Required]
        public string Greeting { get; set; }
        
        public DummyNestedDto[] NestedThingies { get; set; }
    }
    
    public class DummyNestedDto
    {
        public double ImportantNumber { get; set; }
    }
}