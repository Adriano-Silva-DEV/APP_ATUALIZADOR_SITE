using Newtonsoft.Json;
using System.Collections.Generic;

namespace APP_ATUALIZADOR_SITE.classes
{
    class ProdutoResponse
    {


        [JsonProperty("meta")]
        public MetaProdutoResponse Meta { get; set; }
        [JsonProperty("objects")]
        public List<ObjectsProdutoResponse>? Objects { get; set; }



    }
}
