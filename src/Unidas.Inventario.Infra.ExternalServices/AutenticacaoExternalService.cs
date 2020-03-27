using RestSharp;
using System;
using System.Threading.Tasks;
using Unidas.Inventario.Domain.Entities;
using Unidas.Inventario.Domain.Interfaces.ExternalServices;

namespace Unidas.Inventario.Infra.ExternalServices
{
    public class AutenticacaoExternalService : IAcessoService
    {
               
        public object Login(Usuario usuario)
        {

            var client = new RestClient();
            var request = new RestRequest("http://172.18.105.247:51000/api/v1/acessos/usuarios-internos/login", Method.POST);
            request.AddJsonBody(usuario);
            var response  =  client.ExecuteAsync(request);

            var result = response.GetAwaiter().GetResult();

            if (result.StatusCode is System.Net.HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException(result.Content);

            return response.GetAwaiter().GetResult().Content;
        }
    }
}
