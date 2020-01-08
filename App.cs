using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;

namespace ea_api_gateway_lambda
{
    public class App
    {
        private readonly IApiGatewayHandlerFactory _apiGatewayHandlerFactory;

        public App(IApiGatewayHandlerFactory apiGatewayHandlerFactory) 
            => _apiGatewayHandlerFactory = apiGatewayHandlerFactory;

        public async Task<APIGatewayProxyResponse> Run(APIGatewayProxyRequest request) =>
            await _apiGatewayHandlerFactory.Create(request).Execute();

    }
}
