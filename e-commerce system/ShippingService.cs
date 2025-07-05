using static System.Console;

namespace e_commerce_system
{
    public static class ShippingService
    {
        private const decimal shippingFeesPerKg = 3.5m;
        public static List<(IShippable, int)> GetShippableProducts(List<CartItem> items) 
        {
            List<(IShippable, int)> shippableProducts = new();
            foreach (var item in items)
                if (item.Product is IShippable sh) shippableProducts.Add((sh, item.Quantity));

            return shippableProducts;
        }
        public static decimal CalculateShippingFees(List<CartItem> items)
        {
            decimal shippingFees = 0;
            var shippableProducts= GetShippableProducts(items);
            foreach (var product in shippableProducts)
            {
                shippingFees += ((decimal)product.Item1.GetWeight() * product.Item2 * shippingFeesPerKg);
            }
            return shippingFees;
        }
        public static void Ship(List<CartItem> items)
        {
            var shippableProducts= GetShippableProducts(items);

            if (shippableProducts.Count > 0)
            {
                WriteLine("\n** Shipment notice **");
                double totalWeights = 0;
                foreach (var item in shippableProducts)
                {
                    WriteLine($"{item.Item2}X {item.Item1.GetName()}        {item.Item2*item.Item1.GetWeight()}g");
                    totalWeights += item.Item1.GetWeight();
                }
                WriteLine($"Total package weight {totalWeights/1000.0:F1}Kg\n");
            }

        }

    }
}
