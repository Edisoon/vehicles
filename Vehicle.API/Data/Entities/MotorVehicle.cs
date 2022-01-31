using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Vehicle.API.Data.Entities
{
    public class MotorVehicle
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de vehículo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Brand Brand { get; set; }

        [Display(Name = "Año")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1900, 3000, ErrorMessage = "Valor de módelo no válido.")]
        public int Year { get; set; }

        [Display(Name = "Placa")]
        [RegularExpression(@"[A-Z]{1}[0-9]{6}", ErrorMessage = "Formato de placa incorrecto.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Plaque { get; set; }

        [Display(Name = "Modelo")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Model { get; set; }

        [Display(Name = "Color")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Color { get; set; }

        [Display(Name = "Propietario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public User User { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public ICollection<VehiclePhoto> VehiclePhotos { get; set; }

        [Display(Name = "# Fotos")]
        public int VehiclePhotosCount => VehiclePhotos == null ? 0 : VehiclePhotos.Count;

        //TODO: Fix the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => VehiclePhotos == null || VehiclePhotos.Count == 0
            ? $"https://localhost:44376/images/noimage.png"
            : VehiclePhotos.FirstOrDefault().ImageFullPath;

        public ICollection<History> Histories { get; set; }

        [Display(Name = "# Historias")]
        public int HistoriesCount => Histories == null ? 0 : Histories.Count;
    }
}
