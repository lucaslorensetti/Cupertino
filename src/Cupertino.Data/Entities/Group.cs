using System.Collections.Generic;

namespace Cupertino.Data.Entities
{
    public class Group : Entity
    {
        public string Name { get; set; }

        public ICollection<Feature> Features { get; set; }
    }
}
