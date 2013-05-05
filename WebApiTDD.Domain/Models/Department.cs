using System.Collections.Generic;

namespace WebApiTDD.Domain.Models
{
    public class Department
    {
        public Department()
        {
            this.Collarborators = new List<Collarborator>();
            this.Managers = new List<Manager>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Collarborator> Collarborators { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
