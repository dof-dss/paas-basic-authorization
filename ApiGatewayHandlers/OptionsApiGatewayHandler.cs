using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;

namespace paas_basic_authorization
{
    public class OptionsApiGatewayHandler : ApiGatewayHandler
    {
        public OptionsApiGatewayHandler(HttpClient httpClient, APIGatewayProxyRequest request) : base(httpClient, request)
        {
        }

        public override async Task<APIGatewayProxyResponse> Execute()
        {
            return GetAPIGatewayResponse(HttpStatusCode.OK, string.Empty);
        }
    }
}