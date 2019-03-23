using System;
using Cupertino.Core;

namespace Cupertino.Data.Entities
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}
