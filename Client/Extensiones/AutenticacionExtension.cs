using Blazored.LocalStorage;
using ProyectoPADSimpson.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ProyectoPADSimpson.Client.Extensiones
{
    public class AutenticacionExtension: AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        //private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        //public AutenticacionExtension(ILocalStorageService localStorage)
        //{
        //    _localStorage = localStorage;
        //}

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
