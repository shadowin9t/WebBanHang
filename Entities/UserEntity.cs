using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Entities
{
    public class UserEntity
    {
        //User properties
        [Required (ErrorMessage ="USERNAME_EMPTY_MESSAGE")]
        [StringLength (20,MinimumLength =3,ErrorMessage ="USERNAME_INVALID_LENGTH_MESSAGE")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "USERNAME_INVALID_CHARACTER_MESSAGE")]
        public string Username { get; set; }

        [Required (ErrorMessage ="FIRSTNAME_EMPTY_MESSAGE")]
        [StringLength(255,MinimumLength=1,ErrorMessage ="FIRSTNAME_INVALID_LENGTH_MESSAGE")]
        public string Firstname { get; set; }

        [Required (ErrorMessage ="LASTNAME_EMPTY_MESSAGE")]
        [StringLength(255, MinimumLength =1, ErrorMessage ="LASTNAME_EMPTY_MESSAGE")]
        public string Lastname { get; set; }
        
        [Required(ErrorMessage ="EMAIL_EMPTY_MESSAGE")]
        [StringLength(255, MinimumLength =1,ErrorMessage ="EMAIL_INVALID_LENGTH_MESSAGE")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage ="EMAIL_INVALID_CHARACTER_MESSAGE")]
        public string Email { get; set; }


        [Required(ErrorMessage = "PASSWORD_EMPTY_MESSAGE")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "PASSWORD_INVALID_LENGTH_MESSAGE")]
        public string Password { get; set; }

        [Required(ErrorMessage = "CONFIRM_PASSWORD_EMPTY_MESSAGE")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "CONFIRM_PASSWORD_INVALID_LENGTH_MESSAGE")]
        [Compare("Password", ErrorMessage = "CONFIRM_PASSWORD_INCORRECT_MESSAGE")]
        public string ConfirmPassword { get; set; }
        public UserEntity()
        {

        }

        public UserEntity(DataRow row)
        {
            Username = row["username"].ToString();
            Firstname = row["firstname"].ToString();
            Lastname = row["lastname"].ToString();
            Email = row["email"].ToString();
        }

        public bool IsValidField(string field, object fieldvalue, List<ValidationResult> result)
        {
            ValidationContext context = new ValidationContext(this) {MemberName = field };
            List<ValidationResult> rs = new List<ValidationResult>();
            bool valid = Validator.TryValidateProperty(fieldvalue, context, rs);
            result.AddRange(rs);
            return valid;
        }

        public bool IsValidNewUser(List<ValidationResult> rs)
        {
            ValidationContext context = new ValidationContext(this);
            bool valid = Validator.TryValidateObject(this, context, rs, true);
            return valid;
        }

        public bool IsValidEditedUser(List<ValidationResult> rs)
        {
            ValidationContext context = new ValidationContext(this);
            bool valid = IsValidField("Username", Username, rs);
            valid &= IsValidField("Firstname", Firstname, rs);
            valid &= IsValidField("Lastname", Lastname, rs);
            valid &= IsValidField("Email", Email, rs);
            return valid;
        }

        public bool IsValidPassword(List<ValidationResult> rs)
        {
            ValidationContext context = new ValidationContext(this);
            bool valid = IsValidField("Password", Password, rs);
            valid &= IsValidField("ConfirmPassword", ConfirmPassword, rs);
            return valid;
        }

        public override string ToString()
        {
            return Lastname;
        }
    }
}
