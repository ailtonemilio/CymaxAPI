using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication.Shared;

namespace WebApplication.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageValuesController : ControllerBase
    {
        private readonly IPackageRepository _packageRepository;

        public PackageValuesController(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Package>> GetValuePackage(string Consignor, string Consignee, [FromQuery] int[] Cartons)
        {
            try
            {
                var result = await _packageRepository.GetTotal(Consignee, Consignor, Cartons, 10);
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in return data");
            }
        }
    }
}
