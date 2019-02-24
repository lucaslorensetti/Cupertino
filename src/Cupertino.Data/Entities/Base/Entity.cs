using System;
using Cupertino.Core;

namespace Cupertino.Data.Entities
{
    public abstract class Entity : IEntity
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
