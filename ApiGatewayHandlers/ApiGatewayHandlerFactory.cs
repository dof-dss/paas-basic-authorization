using System;
using System.Net.Http;
using Amazon.Lambda.APIGatewayEvents;

namespace paas_basic_authorization
{
    public interface IApiGatewayHandlerFactory
    {
        IApiGatewayHandler Create(APIGatewayProxyRequest request);
    }

    public class ApiGatewayHandlerFactory : IApiGatewayHandlerFactory
    {
        private readonly HttpClient _httpClient;

        public ApiGatewayHandlerFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("paas");
        }

        public IApiGatewayHandler Create(APIGatewayProxyRequest request)
        {
            switch (request.HttpMethod)
            {
                case "OPTIONS":
                    return new OptionsApiGatewayHandler(_httpClient, request);
                case "GET":
                    return new GetApiGatewayHandler(_httpClient, request);
                case "POST":
                    return new PostApiGatewayHandler(_httpClient, request);
                case "PUT":
                    return new PutApiGatewayHandler(_httpClient, request);
                case "DELETE":
                    return new DeleteApiGatewayHandler(_httpClient, request);
                default:
                    throw new NotImplementedException($"Http {request.HttpMethod} not implemented ");
            }
        }
    }
}
