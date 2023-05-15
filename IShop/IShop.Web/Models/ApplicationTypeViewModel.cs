using System.ComponentModel.DataAnnotations;

namespace IShop.Web.Models
{
    public class ApplicationTypeViewModel
    {       
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено!")]
        [Display(Name = "Название")]
        public string Name { get; set; } = string.Empty; 
    }
}
