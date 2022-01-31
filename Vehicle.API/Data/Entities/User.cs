using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vehicles.Common.Enums;

namespace Vehicle.API.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string LastName { get; set; }


        [Display(Name = "Tipo de Documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DocumentTypes DocumentType { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(25, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Document { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        public string Address { get; set; }
        
        [Display(Name ="Foto")]
        public Guid ImageId { get; set; }

        //TODO: Fix the images path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44376/images/noimage.png"
            : $"https://vehicleszuluprep.blob.core.windows.net/users/{ImageId}";
        
        [Display(Name ="Tipo de usuario")]
        public UserType UserType { get; set; }

        [Display(Name ="Usuario")]
        public String FullName => $"{FirstName} {LastName}";

        public ICollection<MotorVehicle> Vehicles { get; set; }

        //public ICollection<History> Histories { get; set; }


    }
}
