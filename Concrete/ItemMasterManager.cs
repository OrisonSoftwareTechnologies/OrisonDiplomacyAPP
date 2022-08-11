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
    public class ItemMasterManager : IItemMasterManager
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;
        DtItemMaster Itemss = new DtItemMaster();
        private object _httpClient;

        public ItemMasterManager(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL1:BaseUrl");
        }

        public async Task<IEnumerable<DtItemMaster>> GetItems()
        {
            return await httpClient.GetJsonAsync<DtItemMaster[]>(BaseUrl + "Itemmaster/ParentItems");
        }
        public async Task<IEnumerable<DtItemMaster>> GetItemsByID(int ID)
        {
            return await httpClient.GetJsonAsync<DtItemMaster[]>(BaseUrl + "Itemmaster/GetItemsById/" + ID);
        }


        public async Task<int> GetMaxItemCode(int ID)
        {
            return await httpClient.GetJsonAsync<int>(BaseUrl + "Itemmaster/GetMaxItemCode?ID=" + ID);
        }

        public async Task<HttpResponseMessage> Save(DtItemMaster Item)
        {
            HttpResponseMessage msg = new HttpResponseMessage();
            try
            {
                msg = await httpClient.PostAsJsonAsync(BaseUrl + "Itemmaster/SaveItem", Item);

                //msg = await httpClient.PostJsonAsync(BaseUrl + "Itemmaster/Saave",Item);
                return msg;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<HttpResponseMessage> Update(DtItemMaster Item)
        {
            HttpResponseMessage msg = new HttpResponseMessage();
            try
            {
                msg = await httpClient.PostAsJsonAsync(BaseUrl + "Itemmaster/UpdateItem/", Item);

                return msg;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<DtItemMaster> GetById(int ID)
        {
            DtItemMaster std = new DtItemMaster();
            try
            {
                std = await httpClient.GetJsonAsync<DtItemMaster>(BaseUrl + "DtItemMaster/GetById/" + ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return std;
        }


        public async Task<string> MiscImagePath()
        {
            return await httpClient.GetStringAsync(BaseUrl + "Itemmaster/MiscImagePath");
        }

        public async Task<string> MiscImageUrl()
        {
            return await httpClient.GetStringAsync(BaseUrl + "Itemmaster/MiscImageUrl");
        }

        public async Task<IEnumerable<dtMastermisc>> getCombos()
        {
            return await httpClient.GetJsonAsync<dtMastermisc[]>(BaseUrl + "Itemmaster/getCombos");
        }
        public async Task<IEnumerable<dtAccounts>> getComboStaff()
        {
            return await httpClient.GetJsonAsync<dtAccounts[]>(BaseUrl + "Itemmaster/getComboStaff");
        }
        public async Task<IEnumerable<dtMastermisc>> getComboDepartment()
        {
            return await httpClient.GetJsonAsync<dtMastermisc[]>(BaseUrl + "Itemmaster/getComboDepartment");
        }
        public async Task<IEnumerable<dtVoucher>> getComboJob()
        {
            return await httpClient.GetJsonAsync<dtVoucher[]>(BaseUrl + "Itemmaster/getComboJob");
        }
        public async Task<HttpResponseMessage> SaveOrder(List<SPMS_Ordering> AddOrder)
        {
            HttpResponseMessage msg = new HttpResponseMessage();
            try
            {
                msg = await httpClient.PostAsJsonAsync(BaseUrl + "Itemmaster/SaveOrderItem", AddOrder);


                return msg;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<IEnumerable<SPMS_Orders>> GetOrders()
        {
            return await httpClient.GetJsonAsync<SPMS_Orders[]>(BaseUrl + "Itemmaster/GetOrders");
        }
        public async Task<IEnumerable<SPMS_OrdersChildGrid>> GetOrdersChild()
        {
            return await httpClient.GetJsonAsync<SPMS_OrdersChildGrid[]>(BaseUrl + "Itemmaster/GetOrdersChild");
        }
        public async Task<string> GetMaxOrderNo()
        {
            return await httpClient.GetStringAsync(BaseUrl + "Itemmaster/GetMaxOrderNo");
        }

        public async Task<HttpResponseMessage> UpdateOrder(SPMS_Ordering orditem)
        {
            HttpResponseMessage msg = new HttpResponseMessage();
            try
            {
                msg = await httpClient.PostAsJsonAsync(BaseUrl + "Itemmaster/UpdateOrder/", orditem);

                return msg;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<HttpResponseMessage> deleteitems(int Item)
        {
            HttpResponseMessage msg = new HttpResponseMessage();
            try
            {
                msg = await httpClient.PostAsJsonAsync(BaseUrl + "Itemmaster/deleteItem/", Item);

                //msg = await httpClient.PostJsonAsync(BaseUrl + "Itemmaster/Saave",Item);
                return msg;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<HttpResponseMessage> SaveCartToOrder(NewCartToOrder value)
        {
            HttpResponseMessage msg = new HttpResponseMessage();
            try
            {
                msg = await httpClient.PostAsJsonAsync(BaseUrl + "Orders/SaveCartToOrder", value);


                return msg;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
