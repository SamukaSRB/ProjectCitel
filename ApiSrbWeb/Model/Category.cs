using System.ComponentModel.DataAnnotations;

namespace ApiSrbWeb.Model
{
    public class Category
    {
        /// <summary>
        /// Identificador único de produto
        /// </summary> 
        [Key]
        public int CategoryId { get; set; }

        /// <summary>
        /// Nome da categoria [CategoryName]
        /// </summary>
        [Required(ErrorMessage = "Digite o nome da categoria")]
        public string? CategoryName { get; set; }

        /// <summary>
        /// Descrição da categoria [CategoryDescription]
        /// </summary>
        [Required(ErrorMessage = "Digite a descrição")]
        public string? CategoryDescription { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
