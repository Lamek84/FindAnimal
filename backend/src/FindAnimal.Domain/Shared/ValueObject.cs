using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Shared
{
    public abstract class ValueObject
    {
        //GetEqualityComponents() возвращает только те компоненты, которые важны для сравнения на равенство.
        protected abstract IEnumerable<object> GetEqualityComponents();
        
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if(GetType() != obj.GetType()) return false;

            var valueObject = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents()) ;
        }

        public override int GetHashCode() =>
            GetEqualityComponents().Aggregate(default(int),(hashcode,value) =>
            HashCode.Combine(hashcode, value.GetHashCode()));

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

        public static bool operator ==(ValueObject? a, ValueObject? b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        /*GetAtomicValues() может возвращать все основные значения объекта, включая те, 
        которые могут не использоваться для сравнения на равенство, 
        но могут быть важны в других контекстах(например, при клонировании объекта).*/
        //protected abstract IEnumerable<object> GetAtomicValues();
        //private override bool Equals(object? obj)
        //{
        //    return other is not null && ValuesAreEqual(other);
        //}
        //private bool ValuesAreEqual(ValueObject other)
        //{
        //    return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        //}
        //public override int GetHashCode()
        //{
        //    return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
        //}
    }
}
