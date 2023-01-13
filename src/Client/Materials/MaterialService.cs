using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.Materials;

namespace Client.Materials
{
    public class MaterialService : IMaterialService
    {
        private readonly HttpClient http;
        private const string endpoint = "api/material";

        public MaterialService(HttpClient http)
        {
            this.http = http;
        }
        public async Task<int> CreateAsync(MaterialDto.Create model)
        {
             var response = await http.PostAsJsonAsync<MaterialDto.Create>(endpoint, model);
             return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<IEnumerable<MaterialDto.Index>> GetIndexAsync(string searchTerm)
        {
            var materials = await http.GetFromJsonAsync<IEnumerable<MaterialDto.Index>>($"{endpoint}?searchTerm={searchTerm}");
            return materials;
        }
    }
}

