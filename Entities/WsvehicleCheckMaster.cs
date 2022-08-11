using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class WsvehicleCheckMaster
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public string Arabic { get; set; }
    }

    public class WSChecklistMaster
    {
        public int ID { get; set; }
        public bool Value { get; set; }
        public string PlateNo { get; set; }
        public int description { get; set; }
        public int JobID { get; set; }
        public string Rowstate { get; set; }
    }
}
