using static System.Console;

namespace e_commerce_system
{
    public class Cart
    {
        List<CartItem> items = new();
        
        public IReadOnlyList<CartItem> Items => items;

        public void AddToCart(Product product, int quantity)
        {
            // user enter non positive quantity
            if (quantity <= 0) throw new ArgumentOutOfRangeException("quantity must be > 0");
            // if there any Cart from this product
            if (product.IsOutOfStock()) throw new ArgumentOutOfRangeException($"this product out of stock");
            // if there any Cart from this product
            if (product.IsExpired()) throw new ArgumentOutOfRangeException($"this product is Expired");
            // if user need more than stock quantity
            if (quantity > product.Quantity) throw new ArgumentOutOfRangeException($"there is only {product.Quantity} from this product");

            var existItem = items.Find(e => e.Product == product);

            if (existItem is not null) // if it exist before increase just the quantity
            {
                if(existItem.Quantity + quantity > product.Quantity)
                    throw new ArgumentOutOfRangeException($"You need {existItem.Quantity + quantity} and there is only {product.Quantity} from this product");
                existItem.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public void Checkout(Customer customer)
        {
            if (items.Count <= 0)
            {
                WriteLine("Error: Cart is empty");
                return;
            }


            foreach (var item in items)
            {
                if (item.Product.IsExpired())
                {
                    WriteLine($"Error: {item.Product.Name} is expired");
                    return;
                }
                else if (item.Quantity > item.Product.Quantity)
                {
                    WriteLine($"Error: {item.Product.Name} is out of stock");
                    return;
                }
            }

            decimal subtotal = items.Sum(i => i.Quantity * i.Product.Price);
            decimal ShippingFees = ShippingService.CalculateShippingFees(items);
            decimal total = subtotal + ShippingFees;

            if (total > customer.Balance)
            {
                WriteLine($"Error: You have not enough money");
                return;
            }


            WriteLine($"*** Checkout ***\n");
            foreach (var item in items)
            {
                item.Product.Quantity -= item.Quantity;
            }

            customer.Balance -= total;

            if (ShippingFees > 0)
            {
                ShippingService.Ship(items);
            }



            WriteLine("** Checkout receipt **");
            foreach (var item in items)
            {
                WriteLine($"{item.Quantity}X {item.Product.Name}        {item.Quantity * item.Product.Price}");
            }
            WriteLine("----------------------");
            WriteLine($"Subtotal         {subtotal}");
            WriteLine($"Shipping         {ShippingFees}");
            WriteLine($"Amount         {total}");
            WriteLine($"Your Balance         {customer.Balance}\n\n");


        }

    }
}
