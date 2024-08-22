using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;

namespace SpecFlowTest.StepDefinitions
{
    [Binding]
    public class ProductStepDefinitions
    {
        public readonly ClienteSqlDataAccessLayer _productSqlDataAccessLayer = new ClienteSqlDataAccessLayer();

        [Given(@"Llenar los campos del producto")]
        public void GivenLlenarLosCamposDelProducto(Table table)
        {
            var dataTable = table.Rows.Count();
            dataTable.Should().BeGreaterThanOrEqualTo(1);
        }

        [When(@"El producto se ingresa en la BDD")]
        public void WhenElProductoSeIngresaEnLaBDD(Table table)
        {
            var product = table.CreateInstance<Product>();
            _productSqlDataAccessLayer.AddProduct(product);
        }


        [Then(@"El producto se guarda correctamente en la BDD")]
        public void ThenElProductoSeGuardaCorrectamenteEnLaBDD(Table table)
        {
            var expectedProduct = table.CreateInstance<Product>();

            var actualProduct = _productSqlDataAccessLayer.GetAllProducts()
                                .FirstOrDefault(p => p.ProductName == expectedProduct.ProductName);

            actualProduct.Should().NotBeNull("El producto debería estar en la base de datos");

            // Verificar que los campos del producto obtenido coincidan con los del producto esperado
            actualProduct.Category.Should().Be(expectedProduct.Category);
            actualProduct.Price.Should().Be(expectedProduct.Price);
            actualProduct.StockQuantity.Should().Be(expectedProduct.StockQuantity);
        }
    }
}
