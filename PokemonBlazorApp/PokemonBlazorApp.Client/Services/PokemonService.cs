using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Newtonsoft.Json;
using PokemonBlazorApp.Client.Services.Contracts;
using PokemonBlazorApp.Client.ViewModels;
using System.Net.Http;

namespace PokemonBlazorApp.Client.Services
{
    public class PokemonService : IPokemonService
    {
        private const string _pokeApiGraphQLUrl = "https://beta.pokeapi.co/graphql/v1beta";

        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PokemonViewModel>> GetPokemons(int limit, int offset = 0)
        {
            var graphQLClient = new GraphQLHttpClient(_pokeApiGraphQLUrl, new NewtonsoftJsonSerializer());
            var request = new GraphQLRequest
            {
                Query = $@"
                    {{
                        pokemon_v2_pokemonspeciesname(
                            limit: {limit}, 
                            offset: {offset}, 
                            order_by: {{pokemon_species_id: asc}}, 
                            where: {{language_id: {{_eq: 9}}}}) {{
                                pokemon_species_id,
                                name
                            }}
                    }}"
            };
            var graphQLResponse = await graphQLClient.SendQueryAsync<dynamic>(request);
            var result = graphQLResponse.Data.pokemon_v2_pokemonspeciesname;

            return JsonConvert.DeserializeObject<IEnumerable<PokemonViewModel>>(result.ToString());
        }

        public Task<PokemonViewModel> GetPokemon(string url)
        {
            throw new NotImplementedException();
        }
    }
}
