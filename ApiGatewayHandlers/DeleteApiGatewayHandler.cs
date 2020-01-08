using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;

namespace paas_basic_authorization
{
    public class DeleteApiGatewayHandler : ApiGatewayHandler
    {
        public DeleteApiGatewayHandler(HttpClient httpClient, APIGatewayProxyRequest request) : base(httpClient, request)
        {
           
        }

        public override Task<APIGatewayProxyResponse> Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}