using Pharmacy_backend.Domain;

namespace Pharmacy_backend.Dto
{
    public static class QuantityMedicineInPharmacyDtoExtensions
    {
        public static QuantityMedicineInPharmacy ConvertToQuantityMedicineInPharmacy(this QuantityMedicineInPharmacyDto quantityMedicineInPharmacyDto)
        {
            return new QuantityMedicineInPharmacy
            {
                BrandName = quantityMedicineInPharmacyDto.BrandName,
                Address = quantityMedicineInPharmacyDto.Address,
                MedicineName = quantityMedicineInPharmacyDto.MedicineName,
                Quantity = quantityMedicineInPharmacyDto.Quantity,
                Price = quantityMedicineInPharmacyDto.Price
            };
        }

        public static QuantityMedicineInPharmacyDto ConvertToQuantityMedicineInPharmacyDto(this QuantityMedicineInPharmacy quantityMedicineInPharmacyDto)
        {
            return new QuantityMedicineInPharmacyDto
            {
                BrandName = quantityMedicineInPharmacyDto.BrandName,
                Address = quantityMedicineInPharmacyDto.Address,
                MedicineName = quantityMedicineInPharmacyDto.MedicineName,
                Quantity = quantityMedicineInPharmacyDto.Quantity,
                Price = quantityMedicineInPharmacyDto.Price
            };
        }
    }
}
