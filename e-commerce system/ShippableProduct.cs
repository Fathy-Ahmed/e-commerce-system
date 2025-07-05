namespace e_commerce_system
{
    public class ShippableProduct : Product, IShippable
    {
        public double Weight { get; set; }
        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
