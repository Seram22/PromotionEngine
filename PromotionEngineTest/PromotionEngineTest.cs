using NUnit.Framework;
using PromotionEngine;
using System.Collections.Generic;

namespace PromotionEngineTest
{
    public class Tests
    {
        List<ProductList> products = new List<ProductList>();

        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("SingleItemCases")]
        public void Single_item_promotion(List<string> productList, int expectedTotalValue)
        {
            foreach (var product in productList)
            {
                ProductList productType = new ProductList(product);
                products.Add(productType);
            }

            int totalValue = PromotionEngine.PromotionEngine.GetTotalPrice(products);
            products.Clear();
            Assert.AreEqual(totalValue, expectedTotalValue);
        }

        [Test, TestCaseSource("SingleItemNegativeCases")]
        public void Single_item_promotion_Negative(List<string> productList, int expectedTotalValue)
        {
            foreach (var product in productList)
            {
                ProductList productType = new ProductList(product);
                products.Add(productType);
            }
            int totalValue = PromotionEngine.PromotionEngine.GetTotalPrice(products);
            products.Clear();
            Assert.AreNotEqual(totalValue, expectedTotalValue);
        }

        [Test, TestCaseSource("MultipleItemsCases")]
        public void Multiple_items_promotion(List<string> productList, int expectedTotalValue)
        {
            foreach (var product in productList)
            {
                ProductList productType = new ProductList(product);
                products.Add(productType);
            }
            int totalValue = PromotionEngine.PromotionEngine.GetTotalPrice(products);
            products.Clear();
            Assert.AreEqual(totalValue, expectedTotalValue);
        }


        [Test, TestCaseSource("MultipleItemsNegativeCases")]
        public void Multiple_items_promotion_Negative(List<string> productList, int expectedTotalValue)
        {
            foreach (var product in productList)
            {
                ProductList productType = new ProductList(product);
                products.Add(productType);
            }
            int totalValue = PromotionEngine.PromotionEngine.GetTotalPrice(products);
            products.Clear();
            Assert.AreNotEqual(totalValue, expectedTotalValue);
        }

        static object[] MultipleItemsCases =
        {
             new object[] { new List<string>(){ "A", "B", "C" }, 100 },
             new object[] { new List<string>(){ "A", "A", "A", "A", "A","B", "B", "B", "B", "B","C" }, 370 },
             new object[] { new List<string>(){ "A", "A", "A","B","B","B","B","B","C","D" }, 280 }

        };
        static object[] SingleItemCases =
        {
             new object[] { new List<string>(){"A", "A", "A"}, 130},
             new object[] { new List<string>(){"B", "B"}, 45},
             new object[] { new List<string>(){"C", "D"}, 30 }
        };

        static object[] MultipleItemsNegativeCases =
       {
             new object[] { new List<string>(){ "A", "B", "C" }, 115 },
             new object[] { new List<string>(){ "A", "A", "A", "A", "A","B", "B", "B", "B", "B","C" }, 375 },
             new object[] { new List<string>(){ "A", "A", "A","B","B","B","B","B","C","D" }, 300 }

        };
        static object[] SingleItemNegativeCases =
        {
             new object[] { new List<string>(){"A", "A", "A"}, 150},
             new object[] { new List<string>(){"B", "B"}, 50},
             new object[] { new List<string>(){"C", "D"}, 45 }
        };
    }
}