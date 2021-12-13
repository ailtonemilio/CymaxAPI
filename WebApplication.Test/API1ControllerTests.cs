using Xunit;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;

namespace WebApplication.Test
{
    public class API1ControllerTests
    {
        [Fact]
        public async Task GetValuePackageAPI1_Returns_Values()
        {
            //Arrange API1
            string dimSize = "";
            int[] Dimensions = { 5, 3, 3 };
            string ContactAddress = "";
            string ContactWarehouse = "";
            for (int i = 0; i < Dimensions.Count(); i++)
            {
                dimSize = dimSize + "&PackageDimensions=" + Dimensions[i].ToString();
            }
            string Url = "api/PackageValues?ContactAddress=" + ContactAddress + "&WarehouseAddress=" + ContactWarehouse + dimSize;

            var clientAPI1 = new TestClientProvider().clientAPI1;

            //Assert
            HttpResponseMessage responseAPI1 = await clientAPI1.GetAsync(Url);
            Assert.Equal(HttpStatusCode.OK, responseAPI1.StatusCode);

            
        }
    }
}
