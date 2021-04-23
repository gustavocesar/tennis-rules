using System;

namespace Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
        }

        public int Id { get; private set; }

        public abstract bool IsValid();
    }
}