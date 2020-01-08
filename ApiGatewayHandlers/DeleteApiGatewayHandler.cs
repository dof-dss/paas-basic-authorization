using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using ea_api_gateway_lambda.Contracts;

namespace ea_api_gateway_lambda
{
    public class DeleteApiGatewayHandler : ApiGatewayHandler
    {
        public DeleteApiGatewayHandler(IApiGatewayManager apiGatewayManager, APIGatewayProxyRequest request) : base(apiGatewayManager, request)
        {
            GatewayFunctionMapper.Add("/remove", Delete);
        }
        private async Task<APIGatewayProxyResponse> Delete() =>
            GetAPIGatewayResponse(HttpStatusCode.NoContent,
                await ApiGatewayManager.Delete(Request.QueryStringParameters["something"]));
    }
}