using System;

namespace Cupertino.Data.Entities
{
    public class Feature : Entity
    {
        public string Name { get; set; }

        public Guid ScreenId { get; set; }
        public Screen Screen { get; set; }
    }
}
