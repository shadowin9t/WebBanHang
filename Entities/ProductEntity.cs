using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Entities
{
    public class ProductEntity
    {
        public class Category
        {
            [Required (ErrorMessage = "CATEGORY_ID_EMPTY_MESSAGE")]
            public string ID { get; set; }
            [Required (ErrorMessage = "CATEGORY_NAME_ID_MESSAGE")]
            public string Name { get; set; }
            public string Discription { get; set; }
            public string CategoryImage { get; set; }
            public DateTime CreatedDate { get; set; }
            public UserEntity CreatedBy { get; set; }
            public string Username
            {
                get
                {
                    return CreatedBy.Username;
                }
            }
            public int StatusId { get; set; }
            public string StatusName { get; set; }
            public bool IsValidNewCategory(List<ValidationResult> rs)
            {
                ValidationContext context = new ValidationContext(this);
                bool valid = Validator.TryValidateObject(this, context, rs, true);
                return valid;
            }
        }

        [Required]
        public string ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Feature { get; set; }
        public string Discription { get; set; }
        public float Price { get; set; }
        [Required]
        public float FinalPrice { get; set; }
        
        public string DisplayImage { get; set; }

        public int Quantity { get; set; } = 0;

        [Required]
        public StatusEntity Status { get; set; }

        [Required]
        public int StatusId {
            get
            {
                return Status.Id;
            }
        }

        public DateTime CreatedDate { get; set; }

        public string StatusName { get { return Status.Name; } }

        [Required]
        public UserEntity CreatedBy { get; set; }

        public string Username { get { return CreatedBy.Username; } }

        [Required]
        public Category ProductCategory { get; set; }
        public string CategoryName
        {
            get {
                return ProductCategory.Name;
            }
        }

        public bool IsValidNewProdcut(List<ValidationResult> rs)
        {
            ValidationContext context = new ValidationContext(this);
            bool valid = Validator.TryValidateObject(this, context, rs, true);
            return valid;
        }
    }
}
