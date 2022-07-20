namespace BlogsApp.Models
{
    public class Medicine
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public Medicine(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
