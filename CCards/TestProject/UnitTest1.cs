using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCards.Controllers;
using CCards.Models;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new CardDetailController();

            var result = controller.GetCardDetails() as List<CardDetail>;
            Assert.AreEqual(testProducts.Count, result.Count);
        }
              

        [TestMethod]
        public async Task GetProductAsync_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new CardDetailController();

            var result = await controller.GetCardDetail("300044445555888") as OkNegotiatedContentResult<CardDetail>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testProducts[3].CardNo, result.Content.CardNo);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new CardDetailController();

            var result = controller.GetCardDetail("30004444555588fs1");
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<CardDetail> GetTestProducts()
        {
            var testCards = new List<CardDetail>();
            testCards.Add(new CardDetail { CardNo = "3000444455558881", Expiry = "062018"});
            testCards.Add(new CardDetail { CardNo = "3000444455558888", Expiry = "102018" });
            testCards.Add(new CardDetail { CardNo = "300044445555881", Expiry = "012018" });
            testCards.Add(new CardDetail { CardNo = "300044445555888", Expiry = "012019" });
            testCards.Add(new CardDetail { CardNo = "5000444455558881", Expiry = "012017" });
            testCards.Add(new CardDetail { CardNo = "5000444455558888", Expiry = "102027" });
            testCards.Add(new CardDetail { CardNo = "4000444455558881", Expiry = "012018" });
            testCards.Add(new CardDetail { CardNo = "4000444455558888", Expiry = "012020" });
            testCards.Add(new CardDetail { CardNo = "111155556666222", Expiry = "082016" });
            testCards.Add(new CardDetail { CardNo = "000233331111555", Expiry = "082018" });
            testCards.Add(new CardDetail { CardNo = "0001222233338888", Expiry = "012019" });

            return testCards;
        }
    }
}
