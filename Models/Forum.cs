using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyecto_mascotas.Models
{
    public class Forum
    {
        [Key]
        public int ForumId { get; set; }

        [Required(ErrorMessage = "Se requiere de un título.")]
        [Display(Name = "Titulo")]
        public string Tittle { get; set; }

        public string Post_by { get; set; }

        [Required(ErrorMessage = "Ingrese una imagen")]
        [Display(Name = "Imagen")]
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

        public ICollection<ForumUser> ForumUser { get; set; }
    }
}