namespace e_commerce_system
{
    public class ExpirableProduct: Product
    {
        public DateTime ExpiryDate { get; set; }
        public override bool IsExpired() => DateTime.Now > ExpiryDate;
    }
}
