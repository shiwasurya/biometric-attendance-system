using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AMSSetting
{
    public class Settings
    {
        public string Version { get; set; }
        public string ApplicationName { get; set; }
        public DateTime LicenceFrom { get; set; }
        public DateTime LicenceUpTo { get; set; }
        public DateTime LicenceIssuesOn { get; set; }        
        public String ManufacturedBy { get; set; }
        public Boolean isSuccess { get; set; }

        public String StatusMsg { get; set; }
    }
}
