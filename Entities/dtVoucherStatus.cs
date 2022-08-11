using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class dtVoucherStatus
    {
        public int ID { get; set; }
        public int? MUser { get; set; }
        public DateTime? MDate { get; set; }
        public int UserID { get; set; }
        public long VID { get; set; }
        public string Status { get; set; }
        public string Staff { get; set; }
        public string Department { get; set; }
        public string Remarks { get; set; }
        public string OldStatus { get; set; }
        public string SubStatus { get; set; }
        public DateTime? StatusDate { get; set; }
    }
}
