using System.Collections.Generic;
using System.Threading.Tasks;

namespace ea_api_gateway_lambda.Contracts
{
    public interface IApiGatewayManager
    {
        Task<List<object>> GetAll();
        Task<object> Get(string id);
        Task<object> Put(object obj);
        Task<object> Post(object obj);
        Task<object> Delete(object obj);

    }
}