using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using ea_api_gateway_lambda.Contracts;

namespace ea_api_gateway_lambda
{
    public class OptionsApiGatewayHandler : ApiGatewayHandler
    {
        public OptionsApiGatewayHandler(IApiGatewayManager apiGatewayManager, APIGatewayProxyRequest request) : base(apiGatewayManager, request)
        {
        }

        public override async Task<APIGatewayProxyResponse> Execute()
        {
            return GetAPIGatewayResponse(HttpStatusCode.OK, string.Empty);
        }
    }
}