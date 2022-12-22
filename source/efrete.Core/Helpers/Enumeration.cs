using System.Reflection;

namespace efrete.Core.Helpers
{
    public abstract class Enumeration<TType> : IComparable where TType : IComparable
    {
        public string Name { get; private set; }

        public TType Id { get; private set; }


        protected Enumeration(TType id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration<TType>  =>
        typeof(T).GetFields(BindingFlags.Public |
                        BindingFlags.Static |
                        BindingFlags.DeclaredOnly)
             .Select(f => f.GetValue(null))
             .Cast<T>();

        public override bool Equals(object? obj)
        {
            if (obj is not Enumeration<TType>  otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }
        public int CompareTo(object? other)
        {
            if (other is not null)
                return Id.CompareTo(((Enumeration<TType>)other).Id);
            else return -1;
        }

        protected abstract IEnumerable<object> GetEqualityComponents();
        
        public override int GetHashCode()
        {
            return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
        }
    }
}