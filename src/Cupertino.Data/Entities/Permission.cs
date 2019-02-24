using System;

namespace Cupertino.Data.Entities
{
    public class Permission : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ScreenId { get; set; }
        public Screen Screen { get; set; }

        public Guid FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
