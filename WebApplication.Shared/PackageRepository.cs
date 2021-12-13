using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Shared
{
    public class PackageRepository : IPackageRepository
    {
        public Package GetBestDeal(List<Package> PackageList)
        {
            Package pk = new Package();
            var minValue = PackageList.Min(p => p.Total);
            pk = PackageList.Where(c => c.Total == minValue).FirstOrDefault();
            return pk;
        }

        public async Task<Package> GetTotal(string Source, string Destination, int[] Dimensions, int Discount)
        {
            Package pk = new Package();

            int TotDimensions = 1;
            decimal percent = (decimal)((double)Discount / 100.0);
            decimal ValuePackage = 0;

            pk.SourceAddress = Source;
            pk.DestinationAddress = Destination;
            //Price per area of the package
            pk.PriceSize = 2;

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
