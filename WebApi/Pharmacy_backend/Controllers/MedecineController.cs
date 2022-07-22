using Microsoft.AspNetCore.Mvc;
using Pharmacy_backend.Dto;
using Pharmacy_backend.Services;

namespace Pharmacy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_medicineService.GetAll()
                    .ConvertAll(t => t.ConvertToMedicineDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _medicineService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("quantity-medicine-in-pharmacy")]
        public IActionResult GetQuantityMedicineInPharmacyByName([FromQuery] string name)
        {
            try
            {
                return Ok(_medicineService.GetQuantityMedicineInPharmacyByName(name)
                    .ConvertAll(t => t.ConvertToQuantityMedicineInPharmacyDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
