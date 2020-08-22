using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PromotionEngine.PromoGenerator();
            }

        }
    }

    public static class PromotionEngine
    {
        public static void PromoGenerator()
        {
            List<ProductList> products = new List<ProductList>();

            Console.WriteLine("Enter the number of Items");
            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("Enter item-{0} from the product:A,B,C or D", i + 1);
                string item = Console.ReadLine();
                ProductList p = new ProductList(item);
                products.Add(p);
            }

            int totalPrice = GetTotalPrice(products);
            Console.WriteLine("Total price: {0}", totalPrice);
        }


        public static int GetTotalPrice(List<ProductList> products)
        {


            int counterofA = 0;
            int priceofA = 0;
            int counterofB = 0;
            int priceofB = 0;
            int CounterofC = 0;
            int priceofC = 0;
            int CounterofD = 0;
            int priceofD = 0;

            int offerQuantityA = 0;
            int offerPriceA = 0;
            int offerQuantityB = 0;
            int offerPriceB = 0;
            int offerPriceCD = 0;

            foreach (var pr in products)
            {
                if (pr.Id == "A" || pr.Id == "a")
                {
                    priceofA = (int)pr.Price;
                    counterofA = counterofA + 1;
                }
                if (pr.Id == "B" || pr.Id == "b")
                {
                    priceofB = (int)pr.Price;
                    counterofB = counterofB + 1;
                }
                if (pr.Id == "C" || pr.Id == "c")
                {
                    priceofC = (int)pr.Price;
                    CounterofC = CounterofC + 1;
                }
                if (pr.Id == "D" || pr.Id == "d")
                {
                    priceofD = (int)pr.Price;
                    CounterofD = CounterofD + 1;
                }
            }


            Promo promo = new Promo();
            foreach (var val in promo.promoCodesList)
            {
                if (val.PromoCode.ContainsKey("PromoA"))
                {
                    offerQuantityA = val.PromoCode["PromoA"];
                    offerPriceA = val.OfferPrice;
                }

                if (val.PromoCode.ContainsKey("PromoB"))
                {
                    offerQuantityB = val.PromoCode["PromoB"];
                    offerPriceB = val.OfferPrice;
                }

                if (val.PromoCode.ContainsKey("PromoCD"))
                {
                    offerPriceCD = val.OfferPrice;
                }

            }

            int totalPriceofA = (counterofA / offerQuantityA) * offerPriceA + (counterofA % offerQuantityA * priceofA);
            int totalPriceofB = (counterofB / offerQuantityB) * offerPriceB + (counterofB % offerQuantityB * priceofB);
            int totalPriceofC = (CounterofC * priceofC);
            int totalPriceofD = (CounterofD * priceofD);
            if (CounterofC == 1 && CounterofD == 1)
                return totalPriceofA + totalPriceofB + offerPriceCD;
            else
                return totalPriceofA + totalPriceofB + totalPriceofC + totalPriceofD;

        }
    }

    public class PromoCodes
    {
        public Dictionary<string, int> PromoCode = new Dictionary<string, int>();
        public int OfferPrice;
    }

    public class Promo
    {
        public List<PromoCodes> promoCodesList = new List<PromoCodes>();
        public Promo()
        {
            PromoCodes promoCodeA = new PromoCodes();
            promoCodeA.PromoCode.Add("PromoA", 3);
            promoCodeA.OfferPrice = 130;
            promoCodesList.Add(promoCodeA);

            PromoCodes promoCodeB = new PromoCodes();
            promoCodeB.PromoCode.Add("PromoB", 2);
            promoCodeB.OfferPrice = 45;
            promoCodesList.Add(promoCodeB);

            PromoCodes promoCodeCD = new PromoCodes();
            promoCodeCD.PromoCode.Add("PromoCD", 1);
            promoCodeCD.OfferPrice = 30;
            promoCodesList.Add(promoCodeCD);

        }
    }


    public class ProductList
    {

        public string Id { get; set; }
        public int Price { get; set; }


        public ProductList(string id)
        {
            this.Id = id;
            switch (id)
            {
                case "A":
                case "a":
                    this.Price = 50;

                    break;
                case "B":
                case "b":
                    this.Price = 30;

                    break;
                case "C":
                case "c":
                    this.Price = 20;

                    break;
                case "D":
                case "d":
                    this.Price = 15;
                    break;
            }
        }

    }
}
