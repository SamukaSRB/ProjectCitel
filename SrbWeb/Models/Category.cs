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
        [DisplayName("Nome")]
        public string CategoryName { get; set; }

        /// <summary>
        /// Descriçao categoria [CategoryDescription]
        /// </summary>
        [Required]
        [DisplayName("Descrição")]
        public string CategoryDescription { get; set; }
    }
}
