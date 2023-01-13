using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    public class FingerprintDetails
    {
        public FingerprintDetails()
        {
            Date = DateTime.Now.ToString("dd/MM/yyyy");
           
        }
        public string SystemName { get; set; }
        public string FingerprintName { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string SerialNumber { get; set; }
        public string Note { get; set; }
    }
}
