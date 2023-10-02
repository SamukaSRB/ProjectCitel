using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SrbWeb.Models
{
    public class Category
    {
        /// <summary>
        /// Identificador único de categoria
        /// </summary> 
        [Required]
        [DisplayName("Id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Nome da categoria [CategoryName]
        /// </summary>
        [Required]
        [StringLength(20, ErrorMessage = "O nome deve conter 20 digitos")]
        [DisplayName("Nome")]
        public string CategoryName { get; set; }

        /// <summary>
        /// Descriçao categoria [CategoryDescription]
        /// </summary>
        [Required]
        [DisplayName("Descrição")]
        [StringLength(100, ErrorMessage = "A descrição deve conter 100 digitos")]
        public string CategoryDescription { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
