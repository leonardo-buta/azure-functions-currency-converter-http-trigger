using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CurrencyConverter
{
    [StorageAccount("AzureWebJobsStorage")]
    public static class CurrencyConverterHTTP
    {
        private const string QUEUE_NAME = "queue-currency";
        
        [FunctionName(nameof(CurrencyConverterHTTP))]
        [return: Queue(QUEUE_NAME)]
        public static async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/CurrencyConverter")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Request iniciado.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            log.LogInformation($"Request recebido: {requestBody}");

            return requestBody;
        }
    }
}
