using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace proyecto_mascotas.Models
{
    
    public class ForumViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idposteo { get; set; }

        public string post_by { get; set; }

        [Required(ErrorMessage ="Se requiere de un título.")]
        [Display(Name = "Titulo")]
        public string Tittle {get; set;}

        [Required(ErrorMessage ="Deberías comentar algo.")]
        [Display(Name = "Comentario")]
        public string Desc {get; set;}

        [Display(Name = "Sube tus Fotos")]
        public string FileName { get; set; }
        public string Ruta { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime FechaDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Hora")]
        public DateTime HoraTime { get; set; }
    }
}
