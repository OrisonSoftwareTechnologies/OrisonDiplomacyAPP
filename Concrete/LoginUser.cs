using AdminDiplomacyAPP.Contract;
using AdminDiplomacyAPP.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Concrete
{
    public class LoginUser : ILogin
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;
        public LoginUser(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL1:BaseUrl");
        }

        public async Task<loginModel> GetUser(string Username,string Password)
        {
            try
            {
                var all = await httpClient.GetJsonAsync<loginModel>(BaseUrl + "Login/GetUser?UserName=" + Username + "&Password=" + Password);
                return all;
            }
            catch(Exception ex)
            { 
                throw ex;
            }
        }
    }
}
