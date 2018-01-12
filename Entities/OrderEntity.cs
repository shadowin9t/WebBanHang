using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderEntity
    {
        [Required(ErrorMessage = "OrderId_EMPTY_MESSAGE")]
        public string OrderId { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "CustomerId_EMPTY_MESSAGE")]
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "OrderAdrees_EMPTY_MESSAGE")]
        public string OrderAdrees { get; set; }

        [Required(ErrorMessage = "StatusOrderId_EMPTY_MESSAGE")]
        public string StatusOrderId { get; set; }

        public OrderEntity(DataRow row)
        {
            OrderId = row["OrderId"].ToString();
            CreatedDate = (DateTime)row["CreatedDate"];
            OrderDate = (DateTime)row["OrderDate"];
            CustomerId = row["CustomerId"].ToString();
            OrderAdrees = row["OrderAdrees"].ToString();
            StatusOrderId = row["StatusOrderId"].ToString();
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
            bool valid = IsValidField("OrderId", OrderId, rs);
            valid &= IsValidField("CreatedDate", CreatedDate, rs);
            valid &= IsValidField("OrderDate", OrderDate, rs);
            valid &= IsValidField("CustomerId", CustomerId, rs);
            valid &= IsValidField("OrderAdrees", OrderAdrees, rs);
            valid &= IsValidField("StatusOrderId", StatusOrderId, rs);
            return valid;
        }
    }
}
