using AdminDiplomacyAPP.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Contract
{
    public interface IJobRegister
    {
        public Task<List<dtJobRegister>> GetAllJob();
        public Task<List<dtVoucherStatus>> GetVoucherStatus();

        public Task<dtJobRegister> GetJobByID(long id);

        public Task<VehiclecheckReturn> GetVehicleCheck(int jobid);

        public Task<List<WsvehicleCheckMaster>> GetCheckListVehicle();

        public Task<List<dtAccounts>> GetCustomers();
        public Task<List<dtAccounts>> GetStaffs();
        public Task<string> CheckJobID(int vno);

        public Task<List<string>> getVehicleImages(string imgname);

        public Task<HttpResponseMessage> UpdateJobDetails(dtVoucherWeb web);
        public Task<HttpResponseMessage> SaveVoucherStatus(dtVoucherStatus status);
        public Task<List<string>> getCombos(string type);
        //public Task<> GetVehicleCheck(int jobid, string plateno);
    }
}
