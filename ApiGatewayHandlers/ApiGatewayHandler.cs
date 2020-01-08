using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace paas_basic_authorization
{
    public interface IApiGatewayHandler
    {
        Task<APIGatewayProxyResponse> Execute();
    }

    public abstract class ApiGatewayHandler : IApiGatewayHandler
    {
        protected HttpClient HttpClient;
        protected JsonSerializerSettings JsonSettings { get; set; }
        protected Dictionary<string, string> Headers { get; set; }
        protected APIGatewayProxyRequest Request { get; set; }

        public abstract Task<APIGatewayProxyResponse> Execute();

        protected ApiGatewayHandler(HttpClient httpClient, APIGatewayProxyRequest request)
        {
            HttpClient = httpClient;
            Headers = new Dictionary<string, string>
            {
                {"Access-Control-Allow-Origin", "*"},
                {"Access-Control-Allow-Headers", "*"},
                {"Access-Control-Allow-Methods", "GET,POST,PUT,DELETE,OPTIONS"}
            };
            JsonSettings = new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()};
            Request = request;
        }

        protected APIGatewayProxyResponse GetAPIGatewayResponse(HttpStatusCode statusCode, string responseContent)
        {
            return new APIGatewayProxyResponse
            {
                Headers = this.Headers,
                StatusCode = (int)statusCode,
                Body = responseContent
            };
        }
    }
}