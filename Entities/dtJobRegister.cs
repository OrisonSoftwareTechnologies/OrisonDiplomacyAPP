using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class dtJobRegister
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public DateTime? VDate { get; set; }

        public string VNo { get; set; }

        public int VnoInt { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string PartyName { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public TimeSpan? StatusTime { get; set; }
        public bool IsRed { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Field1 { get; set; } //cartype
        public string Field2 { get; set; } //color
        public string Field3 { get; set; } //vin
        public string Field4 { get; set; } //plateno
        public string Field5 { get; set; } //comments
        public string Field6 { get; set; }//sales rep
        public string Field7 { get; set; }//km
        public string Field8 { get; set; }//supervisor
        public string Field9 { get; set; }// checked by
        public string Field10 { get; set; }//status

        public string Field11 { get; set; } //jobmodel
        public string Field12 { get; set; } //email
        public string Field14 { get; set; }   // car model

        public string Field15 { get; set; }   // MobileApp

        public DateTime? Date3 { get; set; } //TimeIN

        public DateTime? Date4 { get; set; } //TimeOut

        public DateTime? Date5 { get; set; }  //RequiredDate

        public DateTime? Date6 { get; set; } //RequiredTime

        public DateTime? Date7 { get; set; } //VTime

        public int? num4 { get; set; } //fuel

        public bool verifyVIN { get; set; }

    }
}
