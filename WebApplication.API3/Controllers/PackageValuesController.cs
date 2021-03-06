using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication.Shared;

namespace WebApplication.API3.Controllers
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
        public async Task<ActionResult<Package>> GetValuePackage(string Destination, string Source, [FromQuery] int[] Package)
        {
            try
            {
                var result = await _packageRepository.GetTotal(Source, Destination, Package, 13);
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in return data");
            }
        }
    }
}
