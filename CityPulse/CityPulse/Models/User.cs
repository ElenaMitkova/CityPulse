using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using static CityPulse.Common.EntityValidations.User;
using static CityPulse.Common.EntityValidations;

namespace CityPulse.Models
{
    public class User : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(UserFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Column(TypeName = DateTimeColumnType)]
        public DateTime JoinedOn { get; set; }
        
        [Column(TypeName = DateTimeColumnType)]
        public DateTime LastLogIn { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!new EmailAddressAttribute().IsValid(Email))
            {
                yield return new ValidationResult("Email format is not valid.",
                    new[] { nameof(Email) });
            }

            bool isValidPassword = Password.Length >= 8 && Password.Any(char.IsUpper) &&
                                   Password.Any(char.IsLower) && Password.Any(char.IsDigit);

            if (!isValidPassword && Password.Length < 8)
            {
                yield return new ValidationResult("Password must be at least 8 characters long.",
                    new[] { nameof(Password) });
            }

            if (!isValidPassword && !Password.Any(char.IsUpper))
            {
                yield return new ValidationResult("Password must contain at least one uppercase letter.",
                    new[] { nameof(Password) });
            }

            if (!isValidPassword && !Password.Any(char.IsLower))
            {
                yield return new ValidationResult("Password must contain at least one lowercase letter.",
                    new[] { nameof(Password) });
            }

            if (!isValidPassword && !Password.Any(char.IsDigit))
            {
                yield return new ValidationResult("Password must contain at least one number.",
                    new[] { nameof(Password) });
            }
        }
    }
}
