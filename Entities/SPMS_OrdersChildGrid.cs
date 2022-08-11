using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class SPMS_OrdersChildGrid
    {
        public int ID { get; set; }
        public int Oid { get; set; }
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Qty { get; set; }
        public string Orientation { get; set; }
        public string FileName { get; set; }
    }
}
