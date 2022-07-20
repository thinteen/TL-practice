using BlogsApp.Models;
using BlogsApp.Repositories;

const string connectionString = @"Data Source=DESKTOP-OQM83FS\SQLEXPRESS;Initial Catalog=Pharmacy;Pooling=true;Integrated Security=SSPI;TrustServerCertificate=True";

IBrandRepository brandRepository = new RawSqlBrandRepository( connectionString );
IPharmacyRepository pharmacyRepository = new RawSqlPharmacyRepository( connectionString );
IMedicineRepository medicineRepository = new RawSqlMedicineRepository( connectionString );
IRegularCustomerRepository regularCustomerRepository = new RawSqlRegularCustomerRepository( connectionString );

PrintCommands();
while (true)
{
    Console.WriteLine();
    Console.WriteLine("Введите команду:");
    Console.WriteLine();
    string command = Console.ReadLine();

    switch (command)
    {
        case "get-all-brands":
            {
                IReadOnlyList<Brand> brands = brandRepository.GetAll();
                if (brands.Count == 0)
                {
                    Console.WriteLine("Аптеки не найдены!");
                    continue;
                }

                foreach (Brand brand in brands)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Id: {brand.Id}, " +
                                      $"Name: {brand.Name}");
                }

                break;
            }

        case "get-all-pharmacies":
            {
                IReadOnlyList<Pharmacy> pharmacies = pharmacyRepository.GetAll();
                if (pharmacies.Count == 0)
                {
                    Console.WriteLine("Аптеки не найдены!");
                    continue;
                }

                foreach (Pharmacy pharmacy in pharmacies)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Id: {pharmacy.Id}, " +
                                      $"IdBrand: {pharmacy.IdBrand}, " +
                                      $"Address: {pharmacy.Address}, " +
                                      $"PhoneNumber: {pharmacy.PhoneNumber}");
                }

                break;
            }

        case "get-all-medicines":
            {
                IReadOnlyList<Medicine> medicines = medicineRepository.GetAll();
                if (medicines.Count == 0)
                {
                    Console.WriteLine("Аптеки не найдены!");
                    continue;
                }

                foreach (Medicine medicine in medicines)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Id: {medicine.Id}, " +
                                      $"Name: {medicine.Name}, " +
                                      $"Price: {medicine.Price}");
                }

                break;
            }

        case "get-all-regularCustomers":
            {
                IReadOnlyList<RegularCustomer> regularCustomers = regularCustomerRepository.GetAll();
                if (regularCustomers.Count == 0)
                {
                    Console.WriteLine("Аптеки не найдены!");
                    continue;
                }

                foreach (RegularCustomer regularCustomer in regularCustomers)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Id: {regularCustomer.Id}, " +
                                      $"IdBrand: {regularCustomer.IdBrand}, " +
                                      $"FullName: {regularCustomer.FullName}, " +
                                      $"PhoneNumber: {regularCustomer.PhoneNumber}, " +
                                      $"CustomerCardNumber: {regularCustomer.CustomerCardNumber}, " +
                                      $"AccumulatedPoints: {regularCustomer.AccumulatedPoints}");
                }

                break;
            }

        case "get-medicine-by-name":
            {
                Console.WriteLine();
                Console.WriteLine("Введите название:");
                Console.WriteLine();

                string name = Console.ReadLine();
                Medicine medicine = medicineRepository.GetByName(name);
                if (medicine == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Препарат не найден");
                    continue;
                }

                Console.WriteLine();
                Console.WriteLine($"Id: {medicine.Id}, " +
                                  $"Name: {medicine.Name}, " +
                                  $"Price: {medicine.Price}");

                break;
            }

        case "get-medicine-quantity-by-name":
            {
                Console.WriteLine();
                Console.WriteLine("Введите название:");
                Console.WriteLine();

                string name = Console.ReadLine();
                IReadOnlyList<QuantityMedicineInPharmacy> quantityMedicinesInPharmacies = medicineRepository.GetQuantityMedicineInPharmacyByName(name);
                if (quantityMedicinesInPharmacies.Count == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Препарат не найден");
                    continue;
                }

                foreach (QuantityMedicineInPharmacy quantityMedicinesInPharmacy in quantityMedicinesInPharmacies)
                {
                    Console.WriteLine();
                    Console.WriteLine($"BrandName: {quantityMedicinesInPharmacy.BrandName}, " +
                                      $"Address: {quantityMedicinesInPharmacy.Address}, " +
                                      $"MedicineName: {quantityMedicinesInPharmacy.MedicineName}, " +
                                      $"Quantity: {quantityMedicinesInPharmacy.Quantity}, " +
                                      $"Price: {quantityMedicinesInPharmacy.Price}");
                }

                break;
            }

        case "get-number-of-varieties-of-medicines":
            {
                IReadOnlyList<NumberOfVarietiesOfMedicines> pharmacyMedicines = medicineRepository.GetNumberOfVarietiesOfMedicines();
                if (pharmacyMedicines.Count == 0)
                {
                    Console.WriteLine("Аптеки не найдены!");
                    continue;
                }

                foreach (NumberOfVarietiesOfMedicines pharmacyMedicine in pharmacyMedicines)
                {
                    Console.WriteLine();
                    Console.WriteLine($"IdPharmacy: {pharmacyMedicine.IdPharmacy}, " +
                                      $"NumberOfVarietiesOfMedicines: {pharmacyMedicine.IdMedicine}");
                }

                break;
            }

        case "update-pharmacy":
            {
                bool isUpdate = false;

                while(isUpdate != true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите Id:");
                    Console.WriteLine();

                    if (!Int32.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Неправильный ввод, Id должен быть указан цифрами");
                        Console.WriteLine("Попробуйте еще раз");
                        continue;
                    }

                    Pharmacy pharmacy = pharmacyRepository.GetById(id);

                    if (pharmacy == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Аптека не найдена");
                        continue;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Введите новый адрес:");
                    Console.WriteLine();
                    string newAddress = Console.ReadLine();
                    pharmacy.UpdateAddress(newAddress);

                    Console.WriteLine();
                    Console.WriteLine("Введите новый номер телефона:");
                    Console.WriteLine();
                    string newPhoneNumber = Console.ReadLine(); //защищать ввод номер телефона не стал так как существуют буквенные номера
                    pharmacy.UpdatePhoneNumber(newPhoneNumber);

                    pharmacyRepository.Update(pharmacy);
                    Console.WriteLine();
                    Console.WriteLine("Аптека обновлена");

                    isUpdate = true;
                }

                break;
            }

        case "delete-regularCustomer-by-id":
            {
                bool isDelete = false;

                while (isDelete != true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите id:");
                    Console.WriteLine();

                    if (!Int32.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Неправильный ввод, Id должен быть указан цифрами");
                        Console.WriteLine("Попробуйте еще раз");
                        continue;
                    }

                    RegularCustomer regularCustomer = regularCustomerRepository.GetById(id);
                    if (regularCustomer == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Клиент не найден");
                        continue;
                    }

                    regularCustomerRepository.Delete(regularCustomer);
                    Console.WriteLine();
                    Console.WriteLine("Клиент удален");

                    isDelete = true;
                }

                break;
            }

        case "help":
            {
                PrintCommands();

                break;
            }

        case "exit":
            {
                break;
            }

        default:
            {
                Console.WriteLine();
                Console.WriteLine("Введенной вами команды не существует");
                break;
            }
    }
}

void PrintCommands()
{
    Console.WriteLine( "Доступные команды:" );
    Console.WriteLine( "get-all-brands - Получить список всех брендов аптек" );
    Console.WriteLine( "get-all-pharmacies - Получить список всех аптек" );
    Console.WriteLine( "get-all-medicines - Получить список всех препаратов" );
    Console.WriteLine( "get-all-regularCustomers - Получить список всех постоянных клиентов" );
    Console.WriteLine( "get-medicine-by-name - Получить препарат по названию" );
    Console.WriteLine( "get-medicine-quantity-by-name - Получить наличие препарата по названию" );
    Console.WriteLine( "get-number-of-varieties-of-medicines - Получить наличие препарата по названию");
    Console.WriteLine( "delete-regularCustomer-by-id - Удалить клиента по Id" );
    Console.WriteLine( "update-pharmacy - Обновить аптеку" );
    Console.WriteLine( "help - Список команд" );
    Console.WriteLine( "exit - Выход" );
}