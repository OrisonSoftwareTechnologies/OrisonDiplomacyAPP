using AdminDiplomacyAPP.Contract;
using AdminDiplomacyAPP.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Concrete
{
    public class JobRegister : IJobRegister
    {
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;

        public JobRegister(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<List<dtJobRegister>> GetAllJob()
        {
            try
            {
                var jobs = await httpClient.GetJsonAsync<List<dtJobRegister>>(BaseUrl + "Voucher/getVoucherWeb");
                return jobs;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<dtJobRegister> GetJobByID(long id)
        {
            var job = await httpClient.GetJsonAsync<dtJobRegister>(BaseUrl + "Voucher/VoucherByID?id="+id);
            return job;
        }

        public async Task<VehiclecheckReturn> GetVehicleCheck(int jobid)
        {
            var job = await httpClient.GetJsonAsync<VehiclecheckReturn>(BaseUrl + "VehicleCheck?jobid="+ jobid);
            return job;
        }

        public async Task<List<WsvehicleCheckMaster>> GetCheckListVehicle()
        {
            var complaints = await httpClient.GetJsonAsync<List<WsvehicleCheckMaster>>(BaseUrl + "register/vehiclechecklist");
            return complaints;
        }

        public async Task<List<string>> getVehicleImages(string imgname)
        {
            var imgs = await httpClient.GetJsonAsync<List<string>>(BaseUrl + "Register/downloadimagenames?StartingName="+imgname);
            return imgs;
        }

        public async Task<HttpResponseMessage> UpdateJobDetails(dtVoucherWeb web)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync(BaseUrl + "voucher/UpdateWeb", web);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<List<string>> getCombos(string type)
        {
            var combo = await httpClient.GetJsonAsync<List<string>>(BaseUrl + "Voucher/getCombos?type="+type);
            return combo;
        }

        public async Task<List<dtAccounts>> GetCustomers()
        {
           var customer=await httpClient.GetJsonAsync<List<dtAccounts>>(BaseUrl + "voucher/getcustomer");
           return customer;
        }

        public async Task<string> CheckJobID(int vno)
        {
            var check = await httpClient.GetStringAsync(BaseUrl + "VehicleCheck/CheckJobID?vno="+vno);
            return check;
        }

        public async Task<List<dtVoucherStatus>> GetVoucherStatus()
        {
            var customer = await httpClient.GetJsonAsync<List<dtVoucherStatus>>(BaseUrl + "voucher/getVoucherStatus");
            return customer;
        }

        public async Task<HttpResponseMessage> SaveVoucherStatus(dtVoucherStatus status)
        {
            HttpResponseMessage res = new HttpResponseMessage();
            try
            {
                res = await httpClient.PostAsJsonAsync(BaseUrl + "voucher/InsertVStatus", status);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return res;
        }

        public async Task<List<dtAccounts>> GetStaffs()
        {
            var customer = await httpClient.GetJsonAsync<List<dtAccounts>>(BaseUrl + "voucher/getstaffs");
            return customer;
        }
    }
}
