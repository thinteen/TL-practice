namespace BlogsApp.Models
{
    public class Brand
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Brand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
