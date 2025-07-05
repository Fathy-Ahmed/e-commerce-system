namespace e_commerce_system
{
    public class ExpirableShippableProduct: ExpirableProduct, IShippable
    {
        public double Weight { get; set; }
        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
