using AdminDiplomacyAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Contract
{
    public interface IItemMasterManager
    {
        Task<IEnumerable<DtItemMaster>> GetItems();
        Task<IEnumerable<DtItemMaster>> GetItemsByID(int ID);
        Task<int> GetMaxItemCode(int ID);
        Task<HttpResponseMessage> Save(DtItemMaster Item);
        Task<HttpResponseMessage> Update(DtItemMaster Item);
        Task<DtItemMaster> GetById(int ID);
        Task<string> MiscImagePath();
        Task<string> MiscImageUrl();
        Task<IEnumerable<dtMastermisc>> getCombos();
        Task<IEnumerable<dtAccounts>> getComboStaff();
        Task<IEnumerable<dtMastermisc>> getComboDepartment();
        Task<IEnumerable<dtVoucher>> getComboJob();
        // Task<HttpResponseMessage> SaveOrder(SPMS_Ordering AddOrder);
        Task<HttpResponseMessage> SaveOrder(List<SPMS_Ordering> AddOrder);
        Task<IEnumerable<SPMS_Orders>> GetOrders();
        Task<IEnumerable<SPMS_OrdersChildGrid>> GetOrdersChild();
        Task<string> GetMaxOrderNo();
        Task<HttpResponseMessage> UpdateOrder(SPMS_Ordering orditem);
        // Task<HttpResponseMessage> deleteitems(deleteID);
        Task<HttpResponseMessage> deleteitems(int Item);
        Task<HttpResponseMessage> SaveCartToOrder(NewCartToOrder dt);
    }
}
