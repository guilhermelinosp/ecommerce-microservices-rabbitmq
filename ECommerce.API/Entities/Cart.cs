namespace ECommerce.API.Entities
{
    public class Cart
    {
        public virtual CartHeader? CartHeader { get; set; }
        public virtual IEnumerable<CartDetail>? CartDetail { get; set; }
    }
}
