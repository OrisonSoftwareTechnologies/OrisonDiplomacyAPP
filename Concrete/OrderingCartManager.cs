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
    public class OrderingCartManager : IOrderingCartManager
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;

        private object _httpClient;

        public OrderingCartManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL1:BaseUrl");
        }

        public async Task<HttpResponseMessage> SaveCart(List<SPMS_OrderingCart> AddCart)
        {
            HttpResponseMessage msg = new HttpResponseMessage();
            try
            {
                msg = await httpClient.PostAsJsonAsync(BaseUrl + "OrderingCartManager/SaveCartItem", AddCart);


                return msg;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<SPMS_OrderingCart>> GetCarts()
        {
            return await httpClient.GetJsonAsync<SPMS_OrderingCart[]>(BaseUrl + "OrderingCartManager/GetCarts");
        }

        public async Task<string> GetMaxCartNo()
        {
            return await httpClient.GetStringAsync(BaseUrl + "OrderingCartManager/GetMaxOrderNo");
        }
    }
}
