using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Shared.Materials;

namespace Client.Materials
{
	public partial class Index
	{
        private IEnumerable<MaterialDto.Index> materials;
        private string? searchTerm;

        [Parameter, SupplyParameterFromQuery] public string? Searchterm { get; set; }

        [Inject] public IMaterialService MaterialService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            searchTerm = Searchterm;
            await GetMaterialsAsync();
        }

        private void HandleSearchClick()
        {
            Dictionary<string, object?> parameters = new();

            parameters.Add(nameof(searchTerm), searchTerm);

            var uri = NavigationManager.GetUriWithQueryParameters(parameters);
            
            NavigationManager.NavigateTo(uri);
        }

        private async Task GetMaterialsAsync()
        {
            materials = await MaterialService.GetIndexAsync(searchTerm);
        }
    }
}

