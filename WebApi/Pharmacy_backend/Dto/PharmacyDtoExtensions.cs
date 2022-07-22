using Pharmacy_backend.Domain;

namespace Pharmacy_backend.Dto
{
    public static class PharmacyDtoExtensions
    {
        public static Pharmacy ConvertToPharmacy(this PharmacyDto pharmacyDto)
        {
            return new Pharmacy
            {
                Id = pharmacyDto.Id,
                IdBrand = pharmacyDto.IdBrand,
                Address = pharmacyDto.Address,
                PhoneNumber = pharmacyDto.PhoneNumber
            };
        }
        
        public static PharmacyDto ConvertToPharmacyDto(this Pharmacy pharmacyDto)
        {
            return new PharmacyDto
            {
                Id = pharmacyDto.Id,
                IdBrand = pharmacyDto.IdBrand,
                Address = pharmacyDto.Address,
                PhoneNumber = pharmacyDto.PhoneNumber
            };
        }
    }
}
