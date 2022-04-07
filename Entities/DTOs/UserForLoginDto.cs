using Core.Entities;

namespace Entities.DTOs
{
    public class UserForLoginDto : IDto //Sisteme giriş yapmak isteyen bir kişinin entitysi.
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
