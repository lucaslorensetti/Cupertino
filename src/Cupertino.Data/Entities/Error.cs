using System;

namespace Cupertino.Data.Entities
{
    public class Error : Entity
    {
        public string Exception { get; set; }
        public DateTime When { get; set; }
    }
}
