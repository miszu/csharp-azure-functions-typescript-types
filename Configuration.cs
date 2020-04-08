using System.Reflection;
using AzureFunctions.Extensions.Swashbuckle;
using DummyFunctionApp;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(Configuration))]
namespace DummyFunctionApp
{
    public class Configuration : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSwashBuckle(Assembly.GetExecutingAssembly());
        }
    }
}