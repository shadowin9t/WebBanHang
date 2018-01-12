using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Entities
{
    public class CustomerEntity
    {
        public CustomerEntity()
        {

        }
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Phone_EMPTY_MESSAGE")]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "Phone_INVALID_LENGTH_MESSAGE")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Adress_EMPTY_MESSAGE")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "FirtName_EMPTY_MESSAGE")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName_EMPTY_MESSAGE")]
        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Email_EMPTY_MESSAGE")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email_INVALID_CHARACTER_MESSAGE")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pass_EMPTY_MESSAGE")]
        public string Pass { get; set; }
        
        public CustomerEntity (DataRow row)
        {
            CustomerId = (int) row["CustomerId"];
            Phone = row["Phone"].ToString();
            Adress = row["Adress"].ToString();
            FirstName = row["FirtName"].ToString();
            LastName = row["LastName"].ToString();
            CreatedDate = (DateTime)row["CreatedDate"];
            Email = row["Email"].ToString();
            Pass = row["Pass"].ToString();
        }
        public bool IsValidField(string field, object fieldvalue, List<ValidationResult> result)
        {
            ValidationContext context = new ValidationContext(this) { MemberName = field };
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
            bool valid = IsValidField("CustomerId", CustomerId, rs);
            valid &= IsValidField("Phone", Phone, rs);
            valid &= IsValidField("Adress", Adress, rs);
            valid &= IsValidField("FirtName", FirstName, rs);
            valid &= IsValidField("LastName", LastName, rs);
            valid &= IsValidField("CreatedDate", CreatedDate, rs);
            valid &= IsValidField("Email", Email, rs);
            valid &= IsValidField("Pass", Pass, rs);
            return valid;
        }
    }
}
