using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KestDDD.Application.ViewModels
{
    public class OrderItemViewModel
    {

        [Required(ErrorMessage = "The Item Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

      
      
    }
}
