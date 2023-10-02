using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiSrbWeb.Model
{
    public class Category
    {
        /// <summary>
        /// Identificador único de produto
        /// </summary> 
        [Key]
        [DisplayName("Id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Nome da categoria [CategoryName]
        /// </summary>
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Digite o nome da categoria")]
        [StringLength(100, ErrorMessage = "O nome deve conter 100 caracteres")]
        public string? CategoryName { get; set; }

        /// <summary>
        /// Descrição da categoria [CategoryDescription]
        /// </summary>
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Digite a descrição")]
        [StringLength(100, ErrorMessage = "O nome deve conter 100 caracteres")]
        public string? CategoryDescription { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
