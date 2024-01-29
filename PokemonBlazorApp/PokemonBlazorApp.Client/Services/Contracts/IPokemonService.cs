using PokemonBlazorApp.Client.ViewModels;

namespace PokemonBlazorApp.Client.Services.Contracts
{
    public interface IPokemonService
    {
        public Task<IEnumerable<PokemonViewModel>> GetPokemons(int limit, int offset = 0);

        public Task<PokemonViewModel> GetPokemon(string url);
    }
}
