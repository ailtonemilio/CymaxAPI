using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Shared
{
    public class Package
    {
        public Package()
        {

        }

        public Package(string API, string SourceAddress, string DestinationAddress, decimal PriceSize, decimal Total)
        {
            this.API = API;
            this.SourceAddress = SourceAddress;
            this.DestinationAddress = DestinationAddress;
            this.PriceSize = PriceSize;
            this.Total = Total;
        }

        public string API { get; set; }
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public decimal PriceSize { get; set; }
        public decimal Total { get; set; }
        
    }
}
