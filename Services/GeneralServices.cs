using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Services
{
    public class GeneralServices
    {
        private string BaseUrl;
        HttpClient httpClient = new HttpClient();
        private readonly IConfiguration _config;
        //IDBOperation idbopn;
        public GeneralServices(HttpClient httpClient, IConfiguration config)
        {
            httpClient = httpClient;
            //idbopn = idb;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL1:BaseUrl");
        }
        public async Task<string> MiscImagePath()
        {
            return await httpClient.GetStringAsync(BaseUrl + "Itemmaster/MiscImagePath");
        }

        //public async Task<string> getBranchSettings(string source)
        //{
        //    //var value = await http.GetStringAsync(BaseUrl + "Settings?category=" + category);
        //   var url = await http.GetStringAsync(BaseUrl + "UserLogin/Geturl?source=" + source);
        //    return url;
        //}
        //public async Task<string> getscalar(string cmd)
        //{
        //    var val = await http.GetJsonAsync<object>(BaseUrl + "values?cmd=" + cmd);
        //    return val.ToString();
        //}
    }
}
