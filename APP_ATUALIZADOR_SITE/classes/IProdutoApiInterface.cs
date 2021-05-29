using Refit;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APP_ATUALIZADOR_SITE.classes
{
    interface IProdutoApiInterface
    {

        [Get("/produto?format=json&chave_api={ChaveApi}&chave_aplicacao={Chave_aplicacao}&offset={Offset}&limit=20")]
        Task<ProdutoResponse> GetAddressAsync(string ChaveApi, string Chave_aplicacao, int Offset);

       
        [Put("/produto_estoque/{id}?format=json&chave_api={ChaveApi}&chave_aplicacao={Chave_aplicacao}")]
       Task<ObjectsProdutoResponse> PutEstoqueAddressAsync(string ChaveApi, string Chave_aplicacao, int id, [Body] string produto);


       



    }
}

