namespace e_commerce_system
{
    public class Customer
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public Cart Cart { get; set; } = new();

        public void Checkout()
        {
            Cart.Checkout(this);
        }
    }
}
