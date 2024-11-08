using LotDesignerMicroservice.Domain.ValueObjects.BaseObjects;
using LotDesignerMicroservice.Domain.ValueObjects.Constants;
using LotDesignerMicroservice.Domain.ValueObjects.Exceptions;

namespace LotDesignerMicroservice.Domain.ValueObjects.NumericObjects
{
    /// <summary>
    /// Represents type of the entity's price
    /// </summary>
    public sealed class Price : NumericValueObject<decimal>
    {
        /// <summary>
        /// Represents type of the entity's price
        /// </summary>
        /// <param name="value"> Price value </param>
        public Price(decimal value) : base(value, Validate)
        {
            if (value % 0.01m != 0)
                Value = Math.Round(value, 2);
        }

        static void Validate(decimal value)
        {
            if (value < PriceConstants.MIN_VALUE)
                throw new NumericObjectMinValueException<decimal>(typeof(Price), value, PriceConstants.MIN_VALUE);

            if (value > PriceConstants.MAX_VALUE)
                throw new NumericObjectMaxValueException<decimal>(typeof(Price), value, PriceConstants.MAX_VALUE);
        }
    }
}