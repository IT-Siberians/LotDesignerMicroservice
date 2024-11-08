using LotDesignerMicroservice.Domain.ValueObjects.BaseObjects;
using LotDesignerMicroservice.Domain.ValueObjects.Constants;
using LotDesignerMicroservice.Domain.ValueObjects.Exceptions;

namespace LotDesignerMicroservice.Domain.ValueObjects.DateTimeObjects
{
    public sealed class TradeDuration(TimeSpan value) : ValueObject<TimeSpan>(value, Validate)
    {
        private static void Validate(TimeSpan value)
        {
            if (value < TradeDurationConstants.MIN_DURATION)
                throw new TradeDurationMinValueException(typeof(TradeDuration), value, TradeDurationConstants.MIN_DURATION);
            if (value > TradeDurationConstants.MAX_DURATION)
                throw new TradeDurationMaxValueException(typeof(TradeDuration), value, TradeDurationConstants.MAX_DURATION);
        }
    }
}
