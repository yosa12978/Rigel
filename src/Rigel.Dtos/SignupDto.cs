namespace Rigel.Dtos
{
    public class SignupDto 
    {
        public string username { get; set; } = default!;
        public string password { get; set; } = default!;
        public string password_confirm { get; set; } = default!;
    }
}