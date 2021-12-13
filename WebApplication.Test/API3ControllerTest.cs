using Xunit;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;

namespace WebApplication.Test
{

    public class API3ControllerTest
    {
        [Fact]
        public async Task GetValuePackageAPI3_Returns_Values()
        {
            //Arrange API3
            string dimSize = "";
            int[] Package = { 5, 3, 3 };
            string Destination = "";
            string Source = "";

            for (int i = 0; i < Package.Count(); i++)
            {
                dimSize = dimSize + "&Dimensions=" + Package[i].ToString();
            }
            string Url = "api/PackageValues?Destination=" + Destination + "&Source=" + Source + dimSize;

            var clientAPI = new TestClientProvider().clientAPI3;

            //Assert
            HttpResponseMessage responseAPI = await clientAPI.GetAsync(Url);
            Assert.Equal(HttpStatusCode.OK, responseAPI.StatusCode);
        }
    }
}
