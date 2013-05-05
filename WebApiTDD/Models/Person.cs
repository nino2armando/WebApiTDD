
namespace WebApiTDD.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Department Department { get; set; }
    }
}