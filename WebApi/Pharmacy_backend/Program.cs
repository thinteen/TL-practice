using Pharmacy_backend.Repositories;
using Pharmacy_backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IMedicineRepository>(s =>
    new MedicineRepository(builder.Configuration.GetValue<string>("DefaultConnection")));

builder.Services.AddScoped<IMedicineService, MedicineService>();

builder.Services.AddScoped<IPharmacyRepository>(s =>
    new PharmacyRepository(builder.Configuration.GetValue<string>("DefaultConnection")));

builder.Services.AddScoped<IPharmacyService, PharmacyService>();

var app = builder.Build();
app.MapControllers();
app.Run();