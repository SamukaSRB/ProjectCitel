using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace SrbWeb.Models
{
    public class Product
    {
        /// <summary>
        /// Identificador único de produto
        /// </summary> 
        [Key]
        [DisplayName("Id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Ean do produdo (Codigo de Barras) [Ean]
        /// </summary>
        [DisplayName("Ean")]
        [Required(ErrorMessage = "Digite o Ean do produto")]
        [StringLength(13, ErrorMessage = "O Ean deve conter 13 digitos")]
        public string? ProductEan { get; set; }

        /// <summary>
        /// Ean do produdo (Codigo de produto) [Cod]
        /// </summary>
        [DisplayName("Código")]
        [Required(ErrorMessage = "Digite o código do produto")]
        [StringLength(20, ErrorMessage = "O código deve conter 20 digitos")]
        public string? ProductCod { get; set; }

        /// <summary>
        /// Nome do produto [ProductName]
        /// </summary>
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Digite o nome do produto")]
        [StringLength(100, ErrorMessage = "O nome deve conter 100 caracteres")]
        public string? ProductName { get; set; }

        /// <summary>
        /// Descrição do produto [ProductDescription]
        /// </summary>
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Digite a descrição do produto")]
        [StringLength(100, ErrorMessage = "Quantidade de caracter excedida para a descrição")]
        public string? ProductDescription { get; set; }

        /// <summary>
        /// Preco do produto [ProductPrice]
        /// </summary>
        [DisplayName("Preço")]
        [Required(ErrorMessage = "Digite o preço do produto")]
        [Range(10, 99999.99, ErrorMessage = "O Preço de Venda deve estar entre " + "00,00 e 99999,99.")]
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Quantidade de Estoque [ProductStock]
        /// </summary>
        [DisplayName("Qtd")]
        [Required(ErrorMessage = "Digite a quantidade de entrada do produto")]
        [Range(0, 9000, ErrorMessage = "Quantidade maxima ultrapassada")]
        public int ProductStock { get; set; }

        /// <summary>
        /// Data da aquisição do produto
        /// </summary> 
        [DisplayName("Data")]
        public DateTime DatePurchase { get; set; }

        /// <summary>
        /// Chave estrangeira de categoria
        /// </summary> 
        [ForeignKey("Categorias")]
        public int? CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }
    }
}
