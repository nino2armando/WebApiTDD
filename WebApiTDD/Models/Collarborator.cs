using System;
using System.Collections.Generic;

namespace WebApiTDD.Models
{
    public class Collarborator : Person
    {

        public int ColaboratorId { get; set; }
        public string ManagerCode { get; set; }
        public Nullable<int> Manager_Id { get; set; }
        public Nullable<int> Department_Id { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
