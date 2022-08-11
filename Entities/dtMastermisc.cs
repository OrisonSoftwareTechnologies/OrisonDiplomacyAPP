using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class dtMastermisc
    {
        public int ID { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public bool VDefault { get; set; }
        public int Priority { get; set; }
    }
}
