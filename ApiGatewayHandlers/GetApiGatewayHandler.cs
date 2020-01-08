using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using ea_api_gateway_lambda.Contracts;

namespace ea_api_gateway_lambda
{
    public class GetApiGatewayHandler : ApiGatewayHandler
    {
        public GetApiGatewayHandler(IApiGatewayManager apiGatewayManager, APIGatewayProxyRequest request) : base(apiGatewayManager, request)
        {
            GatewayFunctionMapper.Add("/all", GetAll);
            GatewayFunctionMapper.Add("/get", Get);
        }

        private async Task<APIGatewayProxyResponse> GetAll() => 
            GetAPIGatewayResponse(HttpStatusCode.OK, await ApiGatewayManager.GetAll());

        private async Task<APIGatewayProxyResponse> Get() =>
            GetAPIGatewayResponse(HttpStatusCode.OK,
                await ApiGatewayManager.Get(Request.QueryStringParameters["id"]));

    }
}