using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class SPMS_OrderingCart
    {
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public DateTime? Date { get; set; }
        public string Orientation { get; set; }
        public string Qty { get; set; }
        public string JobNo { get; set; }
        public string Department { get; set; }
        public string Staff { get; set; }
        public string Status { get; set; }
        public DateTime? CDate { get; set; }
        public string MUser { get; set; }
        public int CUser { get; set; }
        public DateTime? MDate { get; set; }
        public string Remarks { get; set; }
        public int ItemID { get; set; }
        public int IsActive { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
    }
}
