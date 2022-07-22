using Pharmacy_backend.Domain;

namespace Pharmacy_backend.Dto
{
    public static class MedicineDtoExtensions
    {
        public static Medicine ConvertToMedicine(this MedicineDto medicineDto)
        {
            return new Medicine
            {
                Id = medicineDto.Id,
                Name = medicineDto.Name,
                Price = medicineDto.Price
            };
        }

        public static MedicineDto ConvertToMedicineDto(this Medicine medicineDto)
        {
            return new MedicineDto
            {
                Id = medicineDto.Id,
                Name = medicineDto.Name,
                Price = medicineDto.Price
            };
        }
    }
}
