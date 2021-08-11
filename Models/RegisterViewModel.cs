using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_mascotas.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Debes ingresar un nombre")]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        // [Required]
        // [DataType(DataType.Text)]
        // [Display(Name = "Nombres")]
        // public string FirstName { get; set; }

        // [Required]
        // [DataType(DataType.Text)]
        // [Display(Name = "Apellidos")]
        // public string LastName { get; set; }

        
        [Required(ErrorMessage = "Debes ingresar un email")]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debes ingresar una contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
         
        [DataType(DataType.Password)]
        [Display(Name ="Confirmar Contraseña")]
        [Compare("Password",ErrorMessage ="La contraseña y su confirmación no han sido encontradas.")]
        public string ConfirmPassword { get; set; }
    }
}
