using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using ea_api_gateway_lambda.Contracts;

namespace ea_api_gateway_lambda
{
    public class PostApiGatewayHandler : ApiGatewayHandler
    {
        public PostApiGatewayHandler(IApiGatewayManager apiGatewayManager, APIGatewayProxyRequest request) : base(apiGatewayManager, request)
        {
            GatewayFunctionMapper.Add("/create", Post);
        }
        private async Task<APIGatewayProxyResponse> Post() =>
            GetAPIGatewayResponse(HttpStatusCode.Created,
                await ApiGatewayManager.Post(Request.QueryStringParameters["something"]));
    }
}