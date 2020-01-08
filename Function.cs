using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace paas_basic_authorization
{
    public class Function
    {
        private ServiceCollection _serviceCollection;
        private ServiceProvider _serviceProvider;

        /// <summary>
        /// Default constructor. This constructor is used by Lambda to construct the instance. When invoked in a Lambda environment
        /// the AWS credentials will come from the IAM role associated with the function and the AWS region will be set to the
        /// region the Lambda function is executed in.
        /// </summary>
        public Function() => ConfigureServices();


        /// <summary>
        /// This method is called for every Lambda invocation.
        /// </summary>
        /// <param name="apiGatewayProxyRequest"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest apiGatewayProxyRequest, ILambdaContext context) 
            => await _serviceProvider.GetService<App>().Run(apiGatewayProxyRequest);

        private void ConfigureServices()
        {
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddTransient<App>();
            _serviceCollection.AddHttpClient("paas", client =>
            {
                client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("url"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            $"{Environment.GetEnvironmentVariable("username")}:{Environment.GetEnvironmentVariable("password")}")));
            });
            _serviceCollection.AddScoped<IApiGatewayHandlerFactory, ApiGatewayHandlerFactory>();

            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        ~Function()
        {
            var disposable = _serviceProvider as IDisposable;
            disposable?.Dispose();
        }
    }
}
