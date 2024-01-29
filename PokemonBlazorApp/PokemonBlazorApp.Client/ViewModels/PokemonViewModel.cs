using Newtonsoft.Json;

namespace PokemonBlazorApp.Client.ViewModels
{
    public class PokemonViewModel
    {
        [JsonProperty("pokemon_species_id")]
        public required int Id { get; set; }
        [JsonProperty("name")]
        public required string Name { get; set; }
    }
}
