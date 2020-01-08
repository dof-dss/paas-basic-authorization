using System;
using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using ea_api_gateway_lambda.Contracts;
using Newtonsoft.Json;

namespace ea_api_gateway_lambda
{
    public class PutApiGatewayHandler : ApiGatewayHandler
    {
        public PutApiGatewayHandler(IApiGatewayManager apiGatewayManager, APIGatewayProxyRequest request) : base(apiGatewayManager, request)
        {
            GatewayFunctionMapper.Add("/update", Put);
        }
        private async Task<APIGatewayProxyResponse> Put() =>
            GetAPIGatewayResponse(HttpStatusCode.NoContent,
                await ApiGatewayManager.Put(Request.QueryStringParameters["something"]));

    }
}