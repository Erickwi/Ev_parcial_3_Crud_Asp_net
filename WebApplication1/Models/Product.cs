using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        public int ProductId {get;set;}
        public string ProductName {get;set;}
        public string Category {get;set;}
        [Range(0, 2000, ErrorMessage = "El precio debe estar entre 0 y 2000.")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad en stock no puede ser negativa.")]

        public int StockQuantity {get;set;}

    }
}