using static System.Console;
namespace e_commerce_system
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Test();
            }
            catch (Exception ex)
            {
                WriteLine($"error: {ex.Message}");
            }
            finally
            {
                WriteLine("\n*** Thank you to using my shop ***");
            }

        }

        static void Test()
        {
            var cheese = new ExpirableShippableProduct()
            {
                Name = "Cheese",
                Price = 100,
                Quantity = 10,
                ExpiryDate = DateTime.Now.AddYears(1),
                Weight = 200
            };

            var biscuits = new ExpirableShippableProduct()
            {
                Name = "Biscuits",
                Price = 150,
                Quantity = 5,
                ExpiryDate = DateTime.Now.AddMonths(6),
                Weight = 700
            };

            var tv = new ShippableProduct()
            {
                Name = "TV",
                Price = 1000,
                Quantity = 10,
                Weight = 250
            };

            var scratchCard = new Product()
            {
                Name = "Mobile Scratch Card",
                Price = 10,
                Quantity = 50,
            };

            var customer1 = new Customer()
            {
                Name = "Fathy Ahmed",
                Balance = 90000
            };


            customer1.Cart.AddToCart(cheese, 2);
            customer1.Cart.AddToCart(biscuits, 1);
            customer1.Cart.AddToCart(scratchCard, 1);
            customer1.Checkout();

            // empty Cart
            var customer2 = new Customer { Name = "Jane", Balance = 1000 };
            customer2.Checkout();

            // less mony
            var customer3 = new Customer { Name = "Bob", Balance = 50 };
            customer3.Cart.AddToCart(tv, 1);
            customer3.Checkout();

            // out of stock
            var customer4 = new Customer { Name = "Alice", Balance = 2000 };
            customer4.Cart.AddToCart(cheese, 20);
        }
    }
}
