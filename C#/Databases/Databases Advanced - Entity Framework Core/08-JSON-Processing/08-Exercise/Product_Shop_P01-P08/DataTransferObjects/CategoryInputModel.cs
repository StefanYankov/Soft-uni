using System.ComponentModel.DataAnnotations;

namespace ProductShop.DataTransferObjects
{
    public class CategoryInputModel
    {
        [Required]
        public string Name { get; set; }
        
    }
}
