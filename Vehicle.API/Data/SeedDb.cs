using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.API.Data.Entities;
using Vehicle.API.Helpers;
using Vehicles.Common.Enums;

namespace Vehicle.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckVehiclesTypeAsync();
            await CheckBrandsAsync();
            await CheckDocumentTypeAsync();
            await CheckProceduresAsync();
            await CheckRolesAsync();
            await CheckUserAsync("402-20701441-1", "Edison", "Lopez", "Edison@yopmail.com", "809-272-7840", "Calle 3, casa 11", UserType.Admin);
            await CheckUserAsync("402-2070255-5", "Jose", "Peralta", "Jose@yopmail.com", "809-272-7840", "Calle 3, casa 11", UserType.User);
            await CheckUserAsync("402-1040785-8-1", "Ramon", "Luna", "RamonL@yopmail.com", "809-272-7840", "Calle 3, casa 11", UserType.User);

        }

        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user =await _userHelper.GetUserAsync(email);
            if(user == null)
            {
                user = new User
                {
                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Address = address,
                    UserType = userType,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cedula"),
                    UserName = email,

                };

                await _userHelper.AddUserAsync(user, "12345678");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Procedure { Description = "Cambio de Aceite", Price = 2000 });
                _context.Procedures.Add(new Procedure { Description = "Cambio de Banda", Price = 1500 });
                _context.Procedures.Add(new Procedure { Description = "Mantenimiento", Price = 1400 });
                _context.Procedures.Add(new Procedure { Description = "Chequeo General", Price = 1000 });
                _context.Procedures.Add(new Procedure { Description = "Escaner", Price = 1800 });
                _context.Procedures.Add(new Procedure { Description = "Alineacion", Price = 600 });
                _context.Procedures.Add(new Procedure { Description = "Balanceo", Price = 700 });
                _context.Procedures.Add(new Procedure { Description = "Cambio de bujia", Price = 1000 });
                _context.Procedures.Add(new Procedure { Description = "Accesorios", Price = 700 });
                _context.Procedures.Add(new Procedure { Description = "Reparacion de motor", Price = 5000 });
                _context.Procedures.Add(new Procedure { Description = "Cambio llanta delantera", Price = 1750 });
                _context.Procedures.Add(new Procedure { Description = "Cambio llanta trasera", Price = 4500  });
                _context.Procedures.Add(new Procedure { Description = "Reparación de motor", Price = 4500 });
                _context.Procedures.Add(new Procedure { Description = "Kit arrastre", Price = 4500 });
                _context.Procedures.Add(new Procedure { Description = "Banda transmisión", Price = 4500 });
                _context.Procedures.Add(new Procedure { Description = "Cambio batería", Price = 4500 });
                _context.Procedures.Add(new Procedure { Description = "Lavado sistema de inyección", Price = 4500 });
                _context.Procedures.Add(new Procedure { Description = "Lavada de tanque", Price = 4500 });
                _context.Procedures.Add(new Procedure { Description = "Cambio rodamiento delantero", Price = 4500 });
                _context.Procedures.Add(new Procedure { Description = "Cambio rodamiento trasero", Price = 4500 });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypeAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentTypes { Description = "Cedula" });
                _context.DocumentTypes.Add(new DocumentTypes { Description = "Pasaporte" });
                _context.DocumentTypes.Add(new DocumentTypes { Description = "Licencia" });
                _context.DocumentTypes.Add(new DocumentTypes { Description = "Seguro" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBrandsAsync()
        {
            if (!_context.Brands.Any())
            {
                _context.Brands.Add(new Brand { Description = "Ducati" });
                _context.Brands.Add(new Brand { Description = "KTM" });
                _context.Brands.Add(new Brand { Description = "BMW" });
                _context.Brands.Add(new Brand { Description = "Honda" });
                _context.Brands.Add(new Brand { Description = "Suzuki" });
                _context.Brands.Add(new Brand { Description = "Kawasaki" });
                _context.Brands.Add(new Brand { Description = "Yamaha" });
                _context.Brands.Add(new Brand { Description = "Mazda" });
                _context.Brands.Add(new Brand { Description = "Toyota" });
                _context.Brands.Add(new Brand { Description = "Renault" });
                _context.Brands.Add(new Brand { Description = "Chevrolet" });
                _context.Brands.Add(new Brand { Description = "Kia" });
                _context.Brands.Add(new Brand { Description = "Hyundai" });
                _context.Brands.Add(new Brand { Description = "Subaru" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckVehiclesTypeAsync()
        {
            if (!_context.VehicleTypes.Any())
            {
                _context.VehicleTypes.Add(new VehicleType { Description = "Carro" });
                _context.VehicleTypes.Add(new VehicleType { Description = "Motocicleta" });
                _context.VehicleTypes.Add(new VehicleType { Description = "Deportivo" });
                _context.VehicleTypes.Add(new VehicleType { Description = "Coupe" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
