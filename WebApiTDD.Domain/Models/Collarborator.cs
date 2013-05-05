using System;

namespace WebApiTDD.Domain.Models
{
    public class Collarborator : Person
    {

        public int Id { get; set; }
        public Nullable<int> Manager_Id { get; set; }
        public Nullable<int> Department_Id { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
