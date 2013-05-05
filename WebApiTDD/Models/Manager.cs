using System;
using System.Collections.Generic;

namespace WebApiTDD.Models
{
    public class Manager : Person
    {
        public Manager()
        {
            this.Collarborators = new List<Collarborator>();
        }

        public Nullable<int> Department_Id { get; set; }
        public virtual ICollection<Collarborator> Collarborators { get; set; }

    }
}
