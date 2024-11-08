using LotDesignerMicroservice.Domain.ValueObjects.BaseObjects;
using LotDesignerMicroservice.Domain.ValueObjects.Constants;
using LotDesignerMicroservice.Domain.ValueObjects.Exceptions;

namespace LotDesignerMicroservice.Domain.ValueObjects.StringObjects
{
    /// <summary>
    /// Represents text object that always has not null, not empty and not only white spaces unlimited lenght string value
    /// </summary>
    /// <param name="value"> Description string value </param>
    public sealed class Text(string value) : StringValueObject(value, Validate)
    {
        static void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new StringObjectEmptyOrWhiteSpacesException(typeof(Text), value);

            if (value.Length < TextConstants.MIN_LENGHT)
                throw new StringObjectMinLenghtException(typeof(Text), value.Length, TextConstants.MIN_LENGHT);

            if (value.Length > TextConstants.MAX_LENGHT)
                throw new StringObjectMaxLenghtException(typeof(Text), value.Length, TextConstants.MAX_LENGHT);
        }
    }
}