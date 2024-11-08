using System.Numerics;

namespace LotDesignerMicroservice.Domain.Entities.Base
{
    /// <summary>
    /// Base entity interface
    /// </summary>
    /// <typeparam name="TKey"> Identifier's type </typeparam>
    public abstract class Entity<TKey> :
        IEquatable<Entity<TKey>>,
        IEqualityOperators<Entity<TKey>, Entity<TKey>, bool>
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Entity's identifier
        /// </summary>
        public TKey Id { get; protected set; }

        public override bool Equals(object? other) => Equals(other);

        public bool Equals(Entity<TKey>? other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }

            return Equals(Id, other.Id);
        }

        public override int GetHashCode()
            => Id!.GetHashCode();

        public static bool operator ==(Entity<TKey>? left, Entity<TKey>? right)
            => Equals(left?.Id, right?.Id);

        public static bool operator !=(Entity<TKey>? left, Entity<TKey>? right)
            => !Equals(left?.Id, right?.Id);
    }
}
