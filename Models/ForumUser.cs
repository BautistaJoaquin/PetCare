using proyecto_mascotas.ViewModels;

namespace proyecto_mascotas.Models
{
    public class ForumUser
    {
        public int ForumId  {get; set;}
        public Forum Forum {get; set;}

        public int UserId {get;set;}
        public User User {get; set;}
    }
}