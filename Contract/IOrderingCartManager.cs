using AdminDiplomacyAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Contract
{
    public interface IOrderingCartManager
    {
        Task<HttpResponseMessage> SaveCart(List<SPMS_OrderingCart> AddCart);
        Task<IEnumerable<SPMS_OrderingCart>> GetCarts();
        Task<string> GetMaxCartNo();
    }
}
