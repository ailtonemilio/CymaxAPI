using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication.Shared;


namespace WebApplication.MainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompareAPIController : ControllerBase
    {
        private readonly IPackageRepository _packageRepository;

        public CompareAPIController(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Package>> GetValuePackage(string Contact, string Warehouse, [FromQuery] int[] Dimensions)
        {
            try
            {
                
                Package pk = new Package();
                var listPackage = new List<Package>();
                decimal dpk1, dpk2, dpk3 = 0;
                string dimSize = "";

                for (int i = 0; i < Dimensions.Count(); i++)
                {
                    dimSize = dimSize + "&Dimensions=" + Dimensions[i].ToString();
                }

                string Url = "api/PackageValues?Contact=" + Contact + "&Warehouse=" + Warehouse + dimSize;

                var API1 = new HttpClient();
                API1.BaseAddress = new System.Uri("https://localhost:44350/");
                API1.DefaultRequestHeaders.Accept.Clear();
                API1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response1 = await API1.GetAsync(Url);
               
                if (response1.IsSuccessStatusCode)
                {
                    pk = JsonConvert.DeserializeObject<Package>(await response1.Content.ReadAsStringAsync());

                    listPackage.Add(new Package
                    (
                        "API1",
                        pk.DestinationAddress,
                        pk.SourceAddress,
                        pk.PriceSize,
                        pk.Total
                    ));
                }


                var API2 = new HttpClient();
                API2.BaseAddress = new System.Uri("https://localhost:44328/");
                API2.DefaultRequestHeaders.Accept.Clear();
                API2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response2 = await API2.GetAsync(Url);

                if (response2.IsSuccessStatusCode)
                {
                    pk = JsonConvert.DeserializeObject<Package>(await response2.Content.ReadAsStringAsync());

                    listPackage.Add(new Package
                    (
                        "API2",
                        pk.DestinationAddress,
                        pk.SourceAddress,
                        pk.PriceSize,
                        pk.Total
                    ));
                }

                var API3 = new HttpClient();
                API3.BaseAddress = new System.Uri("https://localhost:44355/");
                API3.DefaultRequestHeaders.Accept.Clear();
                API3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response3 = await API3.GetAsync(Url);

                if (response3.IsSuccessStatusCode)
                {
                    pk = JsonConvert.DeserializeObject<Package>(await response3.Content.ReadAsStringAsync());

                    listPackage.Add(new Package
                    (
                        "API3",
                        pk.DestinationAddress,
                        pk.SourceAddress,
                        pk.PriceSize,
                        pk.Total
                    ));
                }

                var minValue = listPackage.Min(p => p.Total);
                pk = listPackage.Where(c => c.Total == minValue).FirstOrDefault();

                return pk;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in return data");
            }
        }
    }
}
