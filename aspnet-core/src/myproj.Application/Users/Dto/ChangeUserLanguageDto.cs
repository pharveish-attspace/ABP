using System.ComponentModel.DataAnnotations;

namespace myproj.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}