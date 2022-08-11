using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class dtVoucherWeb
    {
        public VehiclecheckReturn vehiclecheck { get; set; }
        public dtJobRegister job { get; set; }

        public List<WSChecklistMaster> newList { get; set; }

    }
}
