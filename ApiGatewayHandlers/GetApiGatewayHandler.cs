using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;

namespace paas_basic_authorization
{
    public class GetApiGatewayHandler : ApiGatewayHandler
    {
        public GetApiGatewayHandler(HttpClient httpClient, APIGatewayProxyRequest request) : base(httpClient, request)
        {
        }

        public override async Task<APIGatewayProxyResponse> Execute()
        {
            var result = await HttpClient.GetAsync(string.Empty);
            return GetAPIGatewayResponse(result.StatusCode, await result.Content.ReadAsStringAsync());
        }
    }
}