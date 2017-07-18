using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amazon.Lambda.Core;
using Amazon.Lambda.AspNetCoreServer;

namespace AwsLambdaWebApiTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            ILambdaContext context = (ILambdaContext)this.HttpContext.Items[APIGatewayProxyFunction.LAMBDA_CONTEXT];
            return new string[] { $"Request id: {context.AwsRequestId}", $"Function name: {context.FunctionName}",
                $"Identity: {context.Identity}", $"Context: {context.ClientContext}" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
