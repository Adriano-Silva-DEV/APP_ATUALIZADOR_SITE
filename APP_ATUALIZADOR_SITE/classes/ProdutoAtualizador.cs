using APP_ATUALIZADOR_SITE.bd;
using Refit;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;

namespace APP_ATUALIZADOR_SITE.classes
{
    class ProdutoAtualizador
    {
        
        private static string ChaveApi = ConfigurationManager.AppSettings["ChaveApi"];
        private static Uri baseAddress = new Uri(ConfigurationManager.AppSettings["Uri"]);
        private static string Chave_aplicacao = ConfigurationManager.AppSettings["Chave_aplicacao"];

        private readonly IProdutoApiInterface _iProdutoApiInterface;
        private readonly string _apiUrl = ConfigurationManager.AppSettings["Uri"];

        public ProdutoAtualizador()
        {
           _iProdutoApiInterface = RestService.For<IProdutoApiInterface>(_apiUrl);
            
        }

        public static void Execute()
        {

          // var w = RecebeProdutos();
          //  new ProdutoAtualizador().EnviaPrecoProduto(12122, 12222, 39919599);
          // new ProdutoAtualizador().EnviaEstoqueProduto(223, 00001);

             var produto = new ObjectsProdutoResponse();
             produto.Nome = "s1tetesathata";
             produto.CodBarras = ;
             produto.Sku = "16998";
             produto.Id_externo = 66559998;

            new ProdutoAtualizador().EnviaProduto(produto);

        }

        // Busca as informações do produto na api e armazena no bdSQlite   
        public static async Task RecebeProdutos()
        {

            try
            {
                string Next;
                int Offset = 20;
                do
                {

                  var address = await new ProdutoAtualizador()._iProdutoApiInterface.GetAddressAsync(ChaveApi, Chave_aplicacao, Offset);
       
                    foreach (var item in address.Objects)
                    {
                             ConectorSQLITE.InsereProduto(item);
                    }

                    Next = address.Meta.Next;
                    Offset = Offset + 20;
                    Thread.Sleep(2000);

               } while (Next != null);
           

        }
            catch (Exception e)
            {
                ConectorSQLITE.InsereLog("RecebeProduto", e.Message); ;
              
            }

        }

        //Responsável por enviar os produtos
        public async Task EnviaProduto(ObjectsProdutoResponse produto)
        {
            try
            {
                using (var httpClient = new HttpClient { BaseAddress = baseAddress })
                {


                    using (var content = new StringContent("{  \"id_externo\": " + produto.Id_externo + ", \"sku\": " + produto.Sku + ", " +
                        "\"mpn\": null, \"ncm\": null, \"gtin\": " + produto.CodBarras + ", \"nome\": \" " + produto.Nome + " \", " +
                        "\"descricao_completa\": \"\", \"ativo\": false,\"destaque\": false,\"peso\": 0.45," +
                        "\"altura\": 2, \"largura\": 12,\"profundidade\": 6, \"tipo\": \"normal\", \"usado\": false," +
                        "\"removido\": false }", System.Text.Encoding.Default, "application/json"))

                    {

                        using (var response = await httpClient.PostAsync("produto?chave_api=" + ChaveApi + "&chave_aplicacao=" + Chave_aplicacao + "", content))
                        {
                            string responseData = await response.Content.ReadAsStringAsync();

                            MessageBox.Show(responseData);
                            RespostaJson json = JsonConvert.DeserializeObject<RespostaJson>(responseData);

                            if (json.error != null)
                            {
                                MessageBox.Show(json.error.produto);
                            }
                           
                            //ConectorSQLITE.InsereLog("EnviaProduto", responseData); ;
                        }
                    }
                }

            }
            catch (Exception e)
            {
               
                ConectorSQLITE.InsereLog("EnviaProduto", e.Message); ;
                throw;
            }
           
            }

        public async Task EnviaEstoqueProduto(int quantidade, int id)
        {

            string produto = "{ \"gerenciado\": true,  \"situacao_em_estoque\": 1, " +
                " \"situacao_sem_estoque\": 0,  \"quantidade\": " + quantidade + " }";
           // MessageBox.Show(produto);

            try
            {
                await _iProdutoApiInterface.PutEstoqueAddressAsync(ChaveApi, Chave_aplicacao, id, produto);
                
                ConectorSQLITE.InsereLogInternoProduto(id);
            }
            catch (Exception e)
            {
                ConectorSQLITE.InsereLog("EnviaEstoqueProduto", e.Message); ;
                throw;
            }

        }

        public async Task EnviaPrecoProduto(float precoLoja, float precoSite, int id )
        {
            try
            {
                //var baseAddress = new Uri(_apiUrl);

                using (var httpClient = new HttpClient { BaseAddress = baseAddress })
                {

                    using (var content = new StringContent("{  \"cheio\": " + precoLoja + ",  \"custo\": 0,  \"promocional\": " + precoSite + "}",
                      System.Text.Encoding.Default, "application/json"))
                    {
                        using (var response = await httpClient.PutAsync("produto_preco/" + id + "?chave_api=" + ChaveApi + "&chave_aplicacao=" + Chave_aplicacao + "", content))
                        {
                            string responseData = await response.Content.ReadAsStringAsync();
                                                                                  
                        }
                    }

                }
            }
            catch (Exception e)
            {
                ConectorSQLITE.InsereLog("EnviaPrecoProduto", e.Message); ;
                throw;
            }
               
        }

    }
}
