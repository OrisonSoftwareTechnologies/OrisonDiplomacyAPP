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
    public class SMSManager : ISMSManager
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;

        public SMSManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<string> DeliveryReport(string smsid)
        {
            var res = await httpClient.GetStringAsync(BaseUrl + "sms/report?smsid="+smsid);
            return res;
        }

        public async Task<HttpResponseMessage> SendText(dtSMS sms)
        {
            HttpResponseMessage msg = new HttpResponseMessage();
            msg = await httpClient.PostAsJsonAsync(BaseUrl + "sms/smsmanager" , sms);
            return msg;
        }
        
        public async Task<string> ShortenLink(int jobid)
        {
            var res = await httpClient.GetStringAsync(BaseUrl + "sms/URLShorten?jobid=" + jobid);
            return res;
        }
    }
}
