using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class NewCartToOrder
    {
        public SPMS_Orders NewOrdersentry { get; set; }

        public List<SPMS_OrdersChild> NewOrdersChildentry { get; set; }
        public List<SPMS_OrderingCart> DeleteOldCartitem { get; set; }
    }
}
