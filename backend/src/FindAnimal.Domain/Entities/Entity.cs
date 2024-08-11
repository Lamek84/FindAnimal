using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity() { }
        protected Entity(Guid id) 
        {
            Id = id;
        }

        public override bool Equals(object? obj) 
        {
           if(obj == null || obj is not Entity other) return false;

           if(ReferenceEquals(this, obj) == false) return false;

           if(GetType() != other.GetType()) return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity obj1, Entity obj2)
        {
            if (ReferenceEquals(obj1, null) && ReferenceEquals(obj2 ,null)) return true;
            if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null)) return false;
            
            return obj1.Equals(obj2); 
        }

        public static bool operator !=(Entity obj1, Entity obj2)
        {
            return !(obj1 == obj2);
        }

        public override int GetHashCode() 
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
