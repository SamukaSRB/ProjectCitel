using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiSrbWeb.Model;

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
    [StringLength(13, ErrorMessage ="O Ean deve conter 13 digitos")]
    public string? ProductEan { get; set; }

    /// <summary>
    /// Nome do produto [ProductName]
    /// </summary>
    [DisplayName("Nome")]
    [Required(ErrorMessage = "Digite o nome do produto")]
    [MaxLength(50, ErrorMessage = "Quantidade de caracter excedida para o nome")]
    public string? ProductName { get; set; }

    /// <summary>
    /// Descrição do produto [ProductDescription]
    /// </summary>
    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Digite a descrição do produto")]
    [MaxLength(2000, ErrorMessage = "Quantidade de caracter excedida para a descrição")]
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
    [DisplayName("Qtd Produto")]
    [Required(ErrorMessage = "Digite a quantidade de entrada do produto")]
    [Range(0, 9000, ErrorMessage = "Quantidade maxima ultrapassada")]
    public int ProductStock { get; set; }

    /// <summary>
    /// Endereço de imagem produto
    /// </summary> 
    [DisplayName("Foto")]
    public string? ProductImageUrl { get; set; }

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
