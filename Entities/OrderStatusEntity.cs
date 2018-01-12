using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class OrderStatusEntity
    {
        [Required(ErrorMessage = "OrderStatusId_EMPTY_MESSAGE")]
        public string OrderStatusId { get; set; }

        [Required(ErrorMessage = "OrderStatusName_EMPTY_MESSAGE")]
        public string OrderStatusName { get; set; }

        public OrderStatusEntity(DataRow row)
        {
            OrderStatusId = row["OrderStatusId"].ToString();
            OrderStatusName = row["OrderStatusName"].ToString();
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
