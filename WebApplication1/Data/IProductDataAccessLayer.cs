using WebApplication1.Models;


namespace WebApplication1.Data;


public interface IProductDataAccessLayer
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}