using System;
using System.Collections.Generic;

namespace Cupertino.Data.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }

        public ICollection<Feature> Features { get; set; }
    }
}
