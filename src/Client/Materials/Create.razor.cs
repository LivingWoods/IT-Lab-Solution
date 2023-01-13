using System;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Shared.Materials;

namespace Client.Materials
{
	public partial class Create
	{
        private MaterialDto.Create material = new();

        [Inject] public IMaterialService MaterialService { get; set; }
        [Inject] public IToastService ToastService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        private async Task SubmitForm()
        {
            await MaterialService.CreateAsync(material);

            NavigationManager.NavigateTo("/");
            ToastService.ShowSuccess("Materiaal is toegevoegd!");
        }
    }
}

