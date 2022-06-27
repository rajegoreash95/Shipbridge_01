using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApiService.Models;
using WebApiService.Controllers;
using System.Web.Http.Results;
using System.Web.Http;
using System.Net.Http;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllProduct()
        {
            var controller = new ShowroomController();

            var result = controller.GetAllProducts() as System.Collections.Generic.List<Product>;
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetProductByID()
        {
            var controller = new ShowroomController();
            // Act on Test  
            IHttpActionResult actionResult = controller.GetProduct(1002);
            var contentResult = actionResult as OkNegotiatedContentResult<Product>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1002, contentResult.Content.ProductId);
        }

        [TestMethod]
        public void DeleteProductByID()
        {
            // Arrange
            var controller = new ShowroomController();
        
            // Act
            var actionResult = controller.DeleteProduct(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }


        [TestMethod]
        public void AddProduct()
        {
            // Arrange  
            var controller = new ShowroomController();
            Product product = new Product
            {
                ProductName = "pink",
                Quantity=5,
                Price=9087665
            };
            // Act  
            IHttpActionResult actionResult = controller.InsertProduct(product);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Product>;
            // Assert  
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
        /*

        [TestMethod]
        public void UpdateProduct()
        {
            // Arrange  
            var controller = new ShowroomController();
            Product prod= new Product { ProductId = 4,ProductName = "Truck"};
            // Act  
            IHttpActionResult actionResult = controller.UpdateProduct(prod);
            var contentResult = actionResult as NegotiatedContentResult<Product>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(System.Net.HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
        }
        */
    }
}
