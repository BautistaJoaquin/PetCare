using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_mascotas.Models
{
    public class User
    {
        public int UserId  { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }        
        public ICollection <ForumUser> ForumUser { get; set; }
    }
}