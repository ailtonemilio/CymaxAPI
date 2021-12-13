using Xunit;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;

namespace WebApplication.Test
{

    public class API2ControllerTest
    {
        [Fact]
        public async Task GetValuePackageAPI2_Returns_Values()
        {
            //Arrange API2
            string dimSize = "";
            int[] Cartons = { 5, 3, 3 };
            string Consignee = "";
            string Consignor = "";

            for (int i = 0; i < Cartons.Count(); i++)
            {
                dimSize = dimSize + "&Cartons=" + Cartons[i].ToString();
            }
            string Url = "api/PackageValues?Consignee=" + Consignee + "&Consignor=" + Consignor + dimSize;

            var clientAPI = new TestClientProvider().clientAPI2;

            //Assert
            HttpResponseMessage responseAPI = await clientAPI.GetAsync(Url);
            Assert.Equal(HttpStatusCode.OK, responseAPI.StatusCode);
        }
    }
}
