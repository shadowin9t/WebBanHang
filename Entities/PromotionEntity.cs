using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Entities
{
    public class PromotionEntity
    {
        
        [Required(ErrorMessage = "")]
        public string ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortDiscription { get; set; }
        public string Discription { get; set; }
        [Required]
        public string Image { get; set; }
        public StatusEntity Status { get; set; }
        public UserEntity CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StatusName
        {
            get
            {
                return Status.Name;
            }
        }
        public int StatusID
        {
            get
            {
                return Status.Id;
            }
        }

        public bool ValidNewPromotion(List<string> messages)
        {
            ValidationContext context = new ValidationContext(this);
            List<ValidationResult> rs = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(this, context, rs, true);
            foreach (ValidationResult r in rs)
            {
                messages.Add(r.ErrorMessage);
            }
            return valid;
        }

        public bool ValidUpdatePromotion(List<string> message)
        {
            return true;
        }
    }
}
