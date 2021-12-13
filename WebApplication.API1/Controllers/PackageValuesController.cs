using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication.Shared;

namespace WebApplication.API1.Controllers
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
        public async Task<ActionResult<Package>> GetValuePackage(string WarehouseAddress, string ContactAddress, [FromQuery] int[] PackageDimensions)
        {
            try
            {
                var result = await _packageRepository.GetTotal(ContactAddress, WarehouseAddress, PackageDimensions, 5);
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error in return data");
            }
        }
    }
}
