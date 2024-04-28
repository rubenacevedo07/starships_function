using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FunctionStarships.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Cors;
/*
*
*/
namespace FunctionStarships
{
    public static class Function1
    {
        [FunctionName("starships")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            //string st = File.ReadAllText(@"starships.json");

            StreamReader sr = new StreamReader("starships.json");
            string json = sr.ReadToEnd();

            List<SimpleStarship> starships1 = JsonConvert.DeserializeObject<List<SimpleStarship>>(json);

            var response = new HttpResponseMessage();
            //response.Headers.Add();
           

            var jsonToReturn = JsonConvert.SerializeObject(starships1);
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json");
            response.Headers.Add("Access-Control-Allow-Headers", "*");
            response.Headers.Add("Access-Control-Allow-Origin", "https://racevedo.net");
            response.Headers.Add("Access-Control-Allow-Methods", "*");
            response.Headers.Add("Access-Control-Allow-Credentials", "true");
            
                
            return response;
        }


    }

    public static class Function2
    {
        [FunctionName("starhips")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            string st = System.IO.File.ReadAllText(@"starships.json");

            List<SimpleStarship> starships1 = JsonConvert.DeserializeObject<List<SimpleStarship>>(st);

            string responseMessage = starships1.ToString();

            return new OkObjectResult(responseMessage);
        }
    }
}
