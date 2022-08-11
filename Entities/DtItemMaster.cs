using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class DtItemMaster
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameAr { get; set; }
        public string Type { get; set; }
        public int Parent { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public int IsActive { get; set; }
    }
}
