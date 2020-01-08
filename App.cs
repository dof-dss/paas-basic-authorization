using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;

namespace paas_basic_authorization
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
