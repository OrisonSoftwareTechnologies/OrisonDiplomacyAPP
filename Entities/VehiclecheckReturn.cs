using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Entities
{
    public class VehiclecheckReturn
    {
        public int Jobid { get; set; }
        public string PlateNo { get; set; }

        public double CheckingCharge { get; set; }

        public string eoil { get; set; }
        public string efilter { get; set; }
        public string goil { get; set; }
        public string gfilter { get; set; }
        public string fbrake { get; set; }
        public string fdrum { get; set; }
        public string rbrake { get; set; }
        public string rdrum { get; set; }
        public string ffilter { get; set; }
        public string ffum { get; set; }
        public string airfilter { get; set; }
        public bool regitn { get; set; }
        public bool Spare { get; set; }
        public bool warning { get; set; }
        public bool firstaid { get; set; }
        public bool toolkit { get; set; }
        public bool jackprsnt { get; set; }
        public bool keeprmd { get; set; }
        public byte[] Signature { get; set; }
        public string Remarks { get; set; }
        public List<VehdataFromMaster> checkListResult { get; set; }



    }
    public class VehdataFromMaster
    {
        public int slno { get; set; }
        public int id { get; set; }
        public string service { get; set; }
        public string serviArabic { get; set; }
        public bool values { get; set; }
        public VehdataFromMaster(int slno, int Id, string Service, string ServiArabic, bool Values)
        {
            id = Id;
            service = Service;
            serviArabic = ServiArabic;
            values = Values;

        }
    }
}
