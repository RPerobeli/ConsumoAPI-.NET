using ConsumoAPI.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsumoAPI.Repositorio
{
    class UsuarioRepository
    {
        HttpClient cliente = new HttpClient();

        public UsuarioRepository()
        {
            cliente.BaseAddress = new Uri("https://localhost:44381/");
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            HttpResponseMessage response = await cliente.GetAsync("api/usuario/listarTreinadores");
            if( response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                //return GetFirstInstance<string>("email", dados);
                return JsonConvert.DeserializeObject<List<Usuario>>(dados);
            }
            return new List<Usuario>();
        }
        public async Task<List<string>> GetUsernameAsync()
        {
            List<string> lista = new List<string>();
            HttpResponseMessage response = await cliente.GetAsync("api/usuario/listarTreinadores");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                lista.Add(GetFirstInstance<string>("username", dados));
                return lista;

            }
            return lista;
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
                        return serializer.Deserialize<T>(jsonReader);
                    }
                }
                return default(T);
            }
        }
    }


}
