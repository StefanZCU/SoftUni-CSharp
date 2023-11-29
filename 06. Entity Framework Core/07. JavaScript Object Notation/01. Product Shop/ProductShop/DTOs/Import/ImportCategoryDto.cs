using Newtonsoft.Json;

namespace ProductShop.DTOs.Import
{
    public class ImportCategoryDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

    }
}
