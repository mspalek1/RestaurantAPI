namespace RestaurantAPI.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descritpion { get; set; }
        public decimal Price { get; set; }

        public int RetaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}