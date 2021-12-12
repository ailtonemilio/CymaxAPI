using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Shared
{
    public class PackageRepository : IPackageRepository
    {
        public async Task<Package> GetTotal(string Source, string Destination, int[] Dimensions, int Discount)
        {
            Package pk = new Package();

            int TotDimensions = 1;
            decimal percent = (decimal)((double)Discount / 100.0);
            decimal ValuePackage = 0;

            pk.SourceAddress = Source;
            pk.DestinationAddress = Destination;
            pk.PriceSize = 15;

            foreach (var item in Dimensions)
            {
                TotDimensions = TotDimensions * item;
            }

            ValuePackage = pk.PriceSize * TotDimensions;
            pk.Total = ValuePackage - (ValuePackage * percent);

            return pk;
        }
    }
}
