namespace e_commerce_system
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual bool IsExpired() => false;
        public bool IsOutOfStock() => Quantity <= 0;


        // Operators Overloading
        public static bool operator ==(Product l, Product r)
            => l?.Equals(r) ?? r is null;
        public static bool operator !=(Product l, Product r)
            => !(l == r);


        public override bool Equals(object obj)
        {
            if (obj is not Product other) return false;
            return (Name == other.Name && Price == other.Price);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }

    }
}
