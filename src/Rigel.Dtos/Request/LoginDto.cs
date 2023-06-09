namespace Rigel.Dtos.Request
{
    public class LoginDto 
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Username length can't be more than 20.")]
        [MinLength(5, ErrorMessage = "Username length can't be less than 5.")]
        public string username { get; set; } = default!;
        [Required]
        [MaxLength(50, ErrorMessage = "Password length can't be more than 50.")]
        [MinLength(5, ErrorMessage = "Password length can't be less than 5.")]
        public string password { get; set; } = default!;
    }
}