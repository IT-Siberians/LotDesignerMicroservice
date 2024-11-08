using System.Numerics;

namespace LotDesignerMicroservice.Domain.ValueObjects.BaseObjects
{
    /// <summary>
    /// Represents string object that always has not null, not empty and not only white spaces string value
    /// </summary>
    public abstract class StringValueObject(string value, Action<string> validate)
        : ValueObject<string>(value, validate),
        IEqualityOperators<StringValueObject, StringValueObject, bool>,
        IEquatable<StringValueObject>
    {
        public override string? ToString() => Value!;

        public bool Equals(StringValueObject? other)
            => StringComparer.Ordinal.Equals(this, other);

        public override bool Equals(object? other)
            => StringComparer.Ordinal.Equals(this, other);

        public override int GetHashCode()
            => StringComparer.Ordinal.GetHashCode(this);

        public static bool operator ==(StringValueObject? left, StringValueObject? right)
            => StringComparer.Ordinal.Equals(left, right);

        public static bool operator !=(StringValueObject? left, StringValueObject? right)
            => !(left == right);
    }
}