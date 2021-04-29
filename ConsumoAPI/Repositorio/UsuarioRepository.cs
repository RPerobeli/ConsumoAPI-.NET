using ConsumoAPI.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                return JsonConvert.DeserializeObject<List<Usuario>>(dados);
            }
            return new List<Usuario>();
        }
    }
}
