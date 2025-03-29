using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Domain.Models
{
    public class CategoryModel
    {
        public long Id { get; set; }
        [Display(Name ="este es un placeholder desde el modelo")]
        public string Name { get; set; } = null!;
        public int Color { get; set; }

        [Display(Name = "Este es el apodo")]
        public string Apodo { get; set; }
    }
}
