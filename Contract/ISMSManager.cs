using AdminDiplomacyAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Contract
{
    public interface ISMSManager
    {
        Task<string> ShortenLink(int jobid);
        Task<string> DeliveryReport(string smsid);
        Task<HttpResponseMessage> SendText(dtSMS sms);
    }
}
