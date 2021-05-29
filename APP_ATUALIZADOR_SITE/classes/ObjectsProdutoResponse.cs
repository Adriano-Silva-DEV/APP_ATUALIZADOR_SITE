using Newtonsoft.Json;

namespace APP_ATUALIZADOR_SITE.classes
{
    class ObjectsProdutoResponse
    {
        
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("id_externo")]
        public int? Id_externo { get; set; }
        [JsonProperty("nome")]
        public string? Nome { get; set; }
        [JsonProperty("sku")]
        public string? Sku { get; set; }
        [JsonProperty("url")]
        public string? Url { get; set; }
        [JsonProperty("preco")]
        public float? Preco { get; set; }
        [JsonProperty("quantidade")]
        public int? Quantidade { get; set; }
        [JsonProperty("gerenicado")]
        public bool? Gerenciado { get; set; }
        [JsonProperty("situacao_em_estoque ")]
        public int? Situacao_em_estoque { get; set; }
        [JsonProperty("situacao_sem_estoque ")]
        public int? Situacao_sem_estoque { get; set; }
        [JsonProperty("error")]
        public string? Error { get; set; }
        [JsonProperty("message")]
        public string? Message { get; set; }
        [JsonProperty("produto")]
        public string? Produto { get; set; }
        [JsonProperty("resource_uri")]
        public string? Resource_uri { get; set; }
        [JsonProperty("promocional")]
        public float? Promocional { get; set; }
        [JsonProperty("custo")]
        public float? Custo { get; set; }
        [JsonProperty("cheio")]
        public float? Cheio { get; set; }
        [JsonProperty("codBarras")]
        public float? CodBarras{ get; set; }
    }
}


