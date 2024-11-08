using System.Numerics;

namespace LotDesignerMicroservice.Domain.ValueObjects.BaseObjects
{
    /// <summary>
    /// Represents numeric object that always has not null value
    /// </summary>
    /// <typeparam name="T"> Object's numeric type </typeparam>
    public abstract class NumericValueObject<T>(T value, Action<T> validate) :
        ValueObject<T>(value, validate),
        IComparisonOperators<NumericValueObject<T>, NumericValueObject<T>, bool>,
        IEqualityOperators<NumericValueObject<T>, NumericValueObject<T>, bool>,
        IEquatable<NumericValueObject<T>>
        where T : struct, INumber<T>
    {
        public override int GetHashCode() => Value!.GetHashCode();

        public bool Equals(NumericValueObject<T>? other) => base.Equals(other);
        public override bool Equals(object? other) => base.Equals(other as ValueObject<T>);

        public static bool operator ==(NumericValueObject<T>? left, NumericValueObject<T>? right)
            => Equals(left, right);

        public static bool operator !=(NumericValueObject<T>? left, NumericValueObject<T>? right)
            => !Equals(left, right);

        public static bool operator <(NumericValueObject<T> left, NumericValueObject<T> right)
            => left.Value < right.Value;

        public static bool operator >(NumericValueObject<T> left, NumericValueObject<T> right)
            => left.Value > right.Value;

        public static bool operator <=(NumericValueObject<T> left, NumericValueObject<T> right)
            => left.Value <= right.Value;

        public static bool operator >=(NumericValueObject<T> left, NumericValueObject<T> right)
            => left.Value >= right.Value;
    }
}