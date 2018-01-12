using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class OrderDetailEntity
    {
        [Required(ErrorMessage = "OrderId_EMPTY_MESSAGE")]
        public string OrderId { get; set; }

        [Required(ErrorMessage = "productid_EMPTY_MESSAGE")]
        public string productid { get; set; }

        public OrderDetailEntity(DataRow row)
        {
            OrderId = row["OrderId"].ToString();
            productid = row["productid"].ToString();
        }

        public bool IsValidField(string field, object fieldvalue, List<ValidationResult> result)
        {
            ValidationContext context = new ValidationContext(this) { MemberName = field };
            List<ValidationResult> rs = new List<ValidationResult>();
            bool valid = Validator.TryValidateProperty(fieldvalue, context, rs);
            result.AddRange(rs);
            return valid;
        }
    }
}
