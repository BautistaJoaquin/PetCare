using System;  
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace proyecto_mascotas.ViewModels
{
    
    public class ForumViewModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Se requiere de un título.")]
        [Display(Name = "Titulo")]
        public string Tittle { get; set; }

        public string Imagen { get; set; }

        [Required(ErrorMessage ="Deberías comentar algo.")]
        [Display(Name = "Comentario")]
        public string Desc {get; set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime FechaDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Hora")]
        public DateTime HoraTime { get; set; }

        [Required(ErrorMessage = "Ingrese una imagen")]
        [Display(Name = "Imagen")]
        
        public IFormFile ForumImage { get; set; }

    }
}
