using Newtonsoft.Json;

namespace APP_ATUALIZADOR_SITE.classes
{
    class MetaProdutoResponse
    {

        [JsonProperty("limit")]
        public int? Limit { get; set; }
        [JsonProperty("next")]
        public string? Next { get; set; }
        [JsonProperty("offset")]
        public int? Offset { get; set; }
        [JsonProperty("total_count")]
        public int? Total_count { get; set; }

    }
}
