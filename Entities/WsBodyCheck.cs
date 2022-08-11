using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class WsBodyCheck
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public bool? SpareTyre { get; set; }
        public bool? WarningTriangle { get; set; }
        public bool? FirstAidKit { get; set; }
        public bool? ToolKit { get; set; }
        public bool? JackPresent { get; set; }
        public bool? KeepRemovedParts { get; set; }
        public bool? RegistrationCard { get; set; }
        public string PlateNo { get; set; }
        public string Eoil { get; set; }
        public string Efilter { get; set; }
        public string Goil { get; set; }
        public string Gfilter { get; set; }
        public string Fbrake { get; set; }
        public string Fdrum { get; set; }
        public string Rbrake { get; set; }
        public string Rdrum { get; set; }
        public string Ffilter { get; set; }
        public string Ffump { get; set; }
        public string Airfilter { get; set; }
        public double CheckingCharge { get; set; }
        public byte[] Signature { get; set; }
        public string Remarks { get; set; }
    }
}
