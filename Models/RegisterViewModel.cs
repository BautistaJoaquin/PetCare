using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace proyecto_mascotas.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Se requiere un Nombre")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name ="Apellido y Nombre")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Debes ingresar un email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debes ingresar una contraseña")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Debes ingresar una contraseña")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirmar Contraseña")]
        [Compare("Password",ErrorMessage ="Debe ingresar contraseñas iguales")]
        public string ConfirmPassword { get; set; }
    }
}
