using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class loginModel
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int? AccountID { get; set; }

        public string Category { get; set; }

    }
}
