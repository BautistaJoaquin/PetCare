using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_mascotas.Models
{
    public class LoginViewModel
    {
        
        [Required(ErrorMessage ="El campo Email es requerido")]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]

        public string Email { get; set; }

        [Required(ErrorMessage ="El campo contraseña es requerida.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recuerdame?")]
        public bool RememberMe { get; set; }
    }
}
