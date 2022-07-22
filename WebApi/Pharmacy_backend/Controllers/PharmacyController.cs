using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_backend.Dto;
using Pharmacy_backend.Services;

namespace Pharmacy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_pharmacyService.GetAll()
                    .ConvertAll(t => t.ConvertToPharmacyDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] PharmacyDto pharmacyDto)
        {
            try
            {
                return Ok(_pharmacyService.Create(pharmacyDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] PharmacyDto pharmacyDto)
        {
            try
            {
                return Ok(_pharmacyService.Update(pharmacyDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
