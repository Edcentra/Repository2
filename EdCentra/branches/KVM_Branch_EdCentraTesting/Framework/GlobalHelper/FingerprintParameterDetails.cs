using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edwards.Scada.Test.Framework.GlobalHelper
{
    public class FingerprintParameterDetails
    {
        public FingerprintParameterDetails()
        {
            Fingerprint2ParameterValue = string.Empty;
            Delta = string.Empty;
        }

        public string ParameterName { get; set; }
        public string FingerprintParameterValue { get; set; }
        public string Fingerprint2ParameterValue { get; set; }
        public string Delta { get; set; }
        public string Unit { get; set; }
    }
}
