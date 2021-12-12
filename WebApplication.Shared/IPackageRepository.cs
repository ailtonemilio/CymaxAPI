using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Shared
{
    public interface IPackageRepository
    {
        Task<Package> GetTotal(string Warehouse, string Destination, int[] Dimensions, int Discount);
    }
}
