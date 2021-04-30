using ConsumoAPI.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAPI.Repositorio
{
    class PokemonRepository
    {
        HttpClient cliente = new HttpClient();

        public PokemonRepository()
        {
            cliente.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Pokemon2>> GetPokemonAsync(string nomePokemon)
        {
            HttpResponseMessage response = await cliente.GetAsync($"{nomePokemon.ToLower()}/");
            List<Pokemon2> listaPokemonResultado = new List<Pokemon2>();

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                Pokemon2 pokemonResultado = new Pokemon2();
                var serializer = new JsonSerializer();
                pokemonResultado = JsonConvert.DeserializeObject<Pokemon2>(dados);
                listaPokemonResultado.Add(pokemonResultado);
                return listaPokemonResultado;
            }
            return listaPokemonResultado;
        }

        public T GetFirstInstance<T>(string propertyName, string json)
        {
            using (var stringReader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType == JsonToken.PropertyName
                        && (string)jsonReader.Value == propertyName)
                    {
                        jsonReader.Read();

                        var serializer = new JsonSerializer();
                        var variavel =  serializer.Deserialize<T>(jsonReader);
                        //var variavel = JsonConvert.DeserializeObject<T>(jsonReader.ReadAsString());
                        return variavel;
                    }
                }
                return default(T);
            }
        }
    }
}
